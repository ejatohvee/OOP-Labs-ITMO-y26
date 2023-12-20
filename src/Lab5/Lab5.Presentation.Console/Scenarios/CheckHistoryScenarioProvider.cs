using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;

namespace Lab5.Presentation.Console.Scenarios;

public class CheckHistoryScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public CheckHistoryScenarioProvider(IAccountService service, ICurrentAccountService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new WithdrawMoneyScenario(_service);
        return true;
    }
}