namespace Lab5.Models.Accounts;

public record Balance
{
    public Balance(long value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Balance cannot be negative", nameof(value));
        }

        Value = value;
    }

    public long Value { get; }
}