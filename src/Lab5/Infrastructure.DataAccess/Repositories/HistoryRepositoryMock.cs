using Lab5.Application.Abstractions.Repositories;
using Lab5.Models.Accounts;
using Lab5.Models.Operations;

namespace Infrastructure.DataAccess.Repositories;

public class HistoryRepositoryMock : IHistoryRepository
{
    public IAsyncEnumerable<Operation>? CheckHistory(Account account)
    {
        return null;
    }

    public Task SaveHistory(Account account, AccountOperations operationType, long balanceDiff)
    {
        return Task.CompletedTask;
    }
}