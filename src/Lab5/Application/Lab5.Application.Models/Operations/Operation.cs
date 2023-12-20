namespace Lab5.Models.Operations;

public record Operation(long AccountId, long Id, AccountOperations Type, long BalanceDiff);