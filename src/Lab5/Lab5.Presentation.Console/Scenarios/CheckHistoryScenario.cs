using Lab5.Application.Contracts.History;
using Lab5.Models.Accounts;
using Lab5.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class CheckHistoryScenario : IScenario
{
    private readonly IHistoryService _historyService;

    public CheckHistoryScenario(IHistoryService historyService)
    {
        _historyService = historyService;
    }

    public string Name => "Operations history";

    public async Task Run()
    {
        Account account = AnsiConsole.Ask<Account>("Enter your account");

        IAsyncEnumerable<Operation>? result = _historyService.CheckHistory(account);

        if (result != null)
        {
            await foreach (Operation operation in result)
            {
                AnsiConsole.WriteLine(
                    $"Operation ID: {operation.AccountId}, Operation type: {operation.Type}, Amount: {operation.BalanceDiff}");
            }
        }

        AnsiConsole.Ask<string>("Ok");
    }
}