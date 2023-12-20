using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Models.Accounts;
using Lab5.Models.Operations;

namespace Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly CurrentAccountManager _currentAccountManager;
    private readonly IHistoryRepository _historyRepository;

    public AccountService(IAccountRepository repository, CurrentAccountManager currentAccountManager, IHistoryRepository historyRepository)
    {
        _accountRepository = repository;
        _currentAccountManager = currentAccountManager;
        _historyRepository = historyRepository;
    }

    public MoneyOperationResult WithdrawMoney(long money)
    {
        if (_currentAccountManager.Account is null)
        {
            return new MoneyOperationResult.NotAuthorized();
        }

        if (_currentAccountManager.Account.Balance.Value < money)
        {
            return new MoneyOperationResult.NotEnoughMoney();
        }

        _currentAccountManager.Account = _currentAccountManager.Account with { Balance = new Balance(_currentAccountManager.Account.Balance.Value - money) };

        _accountRepository.UpdateBalance(
            _currentAccountManager.Account, money);

        _historyRepository.SaveHistory(_currentAccountManager.Account, AccountOperations.WithdrawMoney, -money);

        return new MoneyOperationResult.Success();
    }

    public MoneyOperationResult DepositMoney(long money)
    {
        if (_currentAccountManager.Account is null)
        {
            return new MoneyOperationResult.NotAuthorized();
        }

        if (money <= 0)
        {
            return new MoneyOperationResult.InvalidAmount();
        }

        _currentAccountManager.Account = _currentAccountManager.Account with { Balance = new Balance(_currentAccountManager.Account.Balance.Value + money) };

        _accountRepository.UpdateBalance(_currentAccountManager.Account, money);

        _historyRepository.SaveHistory(_currentAccountManager.Account, AccountOperations.DepositMoney, money);

        return new MoneyOperationResult.Success();
    }

    public async Task<long?> CheckBalance(string name, int pin)
    {
        Account? account = await _accountRepository.GetAccountByName(name).ConfigureAwait(false);

        if (account != null && account.Pin == pin)
        {
            return account.Balance.Value;
        }

        return null;
    }
}