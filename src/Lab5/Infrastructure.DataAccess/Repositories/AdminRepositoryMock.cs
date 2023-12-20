using Lab5.Application.Abstractions.Repositories;
using Lab5.Models.Accounts;

namespace Infrastructure.DataAccess.Repositories;

public class AdminRepositoryMock : IAdminRepository
{
    private IList<Account> _accounts;

    public AdminRepositoryMock(IList<Account> accounts)
    {
        _accounts = accounts;
    }

    public Task<Account> CreateAccount(string name, int pin)
    {
        _accounts.Add(new Account(_accounts[^1].Id + 1, name, pin, new Balance(0)));
        return (Task<Account>)Task.CompletedTask;
    }
}