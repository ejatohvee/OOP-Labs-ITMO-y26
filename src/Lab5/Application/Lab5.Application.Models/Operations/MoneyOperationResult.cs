namespace Lab5.Models.Operations;

public abstract record MoneyOperationResult
{
    private MoneyOperationResult() { }

    public sealed record Success : MoneyOperationResult;

    public sealed record NotEnoughMoney : MoneyOperationResult;

    public sealed record NotAuthorized : MoneyOperationResult;

    public sealed record InvalidAmount : MoneyOperationResult;
}