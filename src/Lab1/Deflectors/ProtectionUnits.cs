using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public record struct ProtectionUnits // обьект значения
{
    public ProtectionUnits(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Value cannot be negative", nameof(value));
        }

        Value = value;
    }

    public int Value { get; }

    public static ProtectionUnits operator -(ProtectionUnits units, int value)
    {
        int resultValue = units.Value - value;

        return new ProtectionUnits(resultValue);
    }

    public static ProtectionUnits operator +(ProtectionUnits unitOne, ProtectionUnits unitTwo)
    {
        int resultValue = unitOne.Value + unitTwo.Value;

        return new ProtectionUnits(resultValue);
    }

    public static ProtectionUnits Subtract(ProtectionUnits units, int value)
    {
        int resultValue = units.Value - value;

        return new ProtectionUnits(resultValue);
    }

    public static ProtectionUnits Add(ProtectionUnits unitOne, ProtectionUnits unitTwo)
    {
        int resultValue = unitOne.Value + unitTwo.Value;

        return new ProtectionUnits(resultValue);
    }
}