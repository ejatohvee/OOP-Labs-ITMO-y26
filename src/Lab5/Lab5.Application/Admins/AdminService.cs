using Application.Accounts;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Admins;
using Lab5.Models.Accounts;
using Lab5.Models.Operations;

namespace Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IHistoryRepository _historyRepository;
    private readonly CurrentAccountManager? _currentAccountManager;

    public AdminService(IAccountRepository accountRepository, IAdminRepository adminRepository, IHistoryRepository historyRepository, CurrentAccountManager? currentAccountManager)
    {
        _accountRepository = accountRepository;
        _adminRepository = adminRepository;
        _historyRepository = historyRepository;
        _currentAccountManager = currentAccountManager;
    }

    public async Task<AdminOperationResult> CreateAccount(string name, int pin)
    {
        Account? existingAccount = await _accountRepository.GetAccountByName(name).ConfigureAwait(false);

        if (existingAccount != null)
        {
            return new AdminOperationResult.Failed();
        }

        if (_currentAccountManager != null)
        {
            _currentAccountManager.Account = await _adminRepository.CreateAccount(name, pin).ConfigureAwait(false);

            await _historyRepository.SaveHistory(_currentAccountManager.Account, AccountOperations.DepositMoney, 0)
                .ConfigureAwait(false);
        }

        return new AdminOperationResult.Success();
    }
}