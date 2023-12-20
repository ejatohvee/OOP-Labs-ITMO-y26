using Lab5.Application.Contracts.Accounts;
using Lab5.Models.Accounts;

namespace Application.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}