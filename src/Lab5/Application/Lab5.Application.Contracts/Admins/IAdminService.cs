using Lab5.Models.Operations;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminService
{
    Task<AdminOperationResult> CreateAccount(string name, int pin);
}