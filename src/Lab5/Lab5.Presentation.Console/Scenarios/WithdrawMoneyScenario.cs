using Lab5.Application.Contracts.Accounts;
using Lab5.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw money";

    public Task Run()
    {
        long moneyAmount = AnsiConsole.Ask<long>("Enter money amount");

        MoneyOperationResult result = _accountService.WithdrawMoney(moneyAmount);

        string message = result switch
        {
            MoneyOperationResult.Success => "Successful withdraw",
            MoneyOperationResult.NotEnoughMoney => "Not enough money on balance",
            MoneyOperationResult.InvalidAmount => "Invalid amount of money",
            MoneyOperationResult.NotAuthorized => "You are not authorized",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
        return Task.CompletedTask;
    }
}