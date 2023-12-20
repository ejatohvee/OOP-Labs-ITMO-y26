using Lab5.Presentation.Console.Scenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckHistoryScenarioProvider>();

        return collection;
    }
}