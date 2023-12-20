using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class CheckBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check balance";

    public async Task Run()
    {
        string name = AnsiConsole.Ask<string>("Enter your name");
        int pin = AnsiConsole.Ask<int>("Enter PIN");

        long? balanceValue = await _accountService.CheckBalance(name, pin).ConfigureAwait(false);

        AnsiConsole.WriteLine($"Your balance {balanceValue}");

        AnsiConsole.Ask<string>("Ok");
    }
}