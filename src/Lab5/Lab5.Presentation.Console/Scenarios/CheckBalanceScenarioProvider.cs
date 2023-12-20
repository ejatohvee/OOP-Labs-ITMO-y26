using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;

namespace Lab5.Presentation.Console.Scenarios;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public CheckBalanceScenarioProvider(IAccountService service, ICurrentAccountService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new WithdrawMoneyScenario(_service);
        return true;
    }
}