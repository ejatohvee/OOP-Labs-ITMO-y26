using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public record struct ProtectionUnits
{
    public ProtectionUnits(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Value cannot be negative", nameof(value));
        }

        Value = value;
    }

    public double Value { get; }

    public static ProtectionUnits operator -(ProtectionUnits units, double value)
    {
        double resultValue = units.Value - value;

        return new ProtectionUnits(resultValue);
    }

    public static ProtectionUnits operator +(ProtectionUnits unitOne, ProtectionUnits unitTwo)
    {
        double resultValue = unitOne.Value + unitTwo.Value;

        return new ProtectionUnits(resultValue);
    }

    public static ProtectionUnits Subtract(ProtectionUnits units, double value)
    {
        double resultValue = units.Value - value;

        return new ProtectionUnits(resultValue);
    }

    public static ProtectionUnits Add(ProtectionUnits unitOne, ProtectionUnits unitTwo)
    {
        double resultValue = unitOne.Value + unitTwo.Value;

        return new ProtectionUnits(resultValue);
    }
}