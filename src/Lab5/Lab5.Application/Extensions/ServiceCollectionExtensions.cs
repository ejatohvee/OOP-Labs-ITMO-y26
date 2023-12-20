using Application.Accounts;
using Lab5.Application.Contracts.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        return collection;
    }
}