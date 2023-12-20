using Lab5.Application.Contracts.Admins;
using Lab5.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create an account";

    public async Task Run()
    {
        string name = AnsiConsole.Ask<string>("Enter name");
        int pin = AnsiConsole.Ask<int>("Enter PIN");

        AdminOperationResult result = await _adminService.CreateAccount(name, pin).ConfigureAwait(false);

        string message = result switch
        {
            AdminOperationResult.Success => "Account created",
            AdminOperationResult.Failed => "Fail creating account",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}