using Lab5.Models.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    MoneyOperationResult WithdrawMoney(long money);

    MoneyOperationResult DepositMoney(long money);

    Task<long?> CheckBalance(string name, int pin);
}