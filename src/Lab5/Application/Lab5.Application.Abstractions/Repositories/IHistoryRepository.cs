using Lab5.Models.Accounts;
using Lab5.Models.Operations;

namespace Lab5.Application.Abstractions.Repositories;

public interface IHistoryRepository
{
    IAsyncEnumerable<Operation>? CheckHistory(Account account);
    Task SaveHistory(Account account, AccountOperations operationType, long balanceDiff);
}