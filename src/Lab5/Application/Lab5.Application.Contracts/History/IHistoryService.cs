using Lab5.Models.Accounts;
using Lab5.Models.Operations;

namespace Lab5.Application.Contracts.History;

public interface IHistoryService
{
    IAsyncEnumerable<Operation>? CheckHistory(Account account);
}