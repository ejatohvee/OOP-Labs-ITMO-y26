using Lab5.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    void UpdateBalance(Account account, long money);

    Task<Account?> GetAccountByName(string name);
}