using Lab5.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Account> CreateAccount(string name, int pin);
}