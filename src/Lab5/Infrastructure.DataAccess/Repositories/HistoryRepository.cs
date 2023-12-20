using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Models.Accounts;
using Lab5.Models.Operations;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<Operation> CheckHistory(Account account)
    {
        const string sql = """
                           SELECT operations_id, operation_type, balance_diff
                           FROM operations
                           WHERE account_id = :accountId
                           ORDER BY operations_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("accountId", account.Id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            long operationId = reader.GetInt64(0);
            AccountOperations operationType = Enum.Parse<AccountOperations>(reader.GetString(1));
            long balanceDiff = reader.GetInt64(2);

            yield return new Operation(account.Id, operationId, operationType, balanceDiff);
        }
    }

    public async Task SaveHistory(Account account, AccountOperations operationType, long balanceDiff)
    {
        const string sql = """
                            INSERT INTO operations (account_id, operation_type, balance_diff)
                            VALUES (:accountId, :operationType, :balanceDiff)
                            RETURNING operations_id
                            """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("accountId", account.Id);
        command.Parameters.AddWithValue("operationType", operationType.ToString());
        command.Parameters.AddWithValue("balanceDiff", balanceDiff);
    }
}