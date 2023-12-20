using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Models.Accounts;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account> CreateAccount(string name, int pin)
    {
        const string sql = """
                           INSERT INTO accounts (account_name, account_pin, account_balance)
                           VALUES (:accountName, :newPin, :accountBalance)
                           RETURNING account_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        long newAccountId = (long)(await command.ExecuteScalarAsync().ConfigureAwait(false) ?? throw new InvalidOperationException());

        command.Parameters.AddWithValue("accountId", newAccountId);
        command.Parameters.AddWithValue("accountName", name);
        command.Parameters.AddWithValue("accountPin", pin);
        command.Parameters.AddWithValue("accountBalance", 0);

        return new Account(newAccountId, name, pin, new Balance(0));
    }
}