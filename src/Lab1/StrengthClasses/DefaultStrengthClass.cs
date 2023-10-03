using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

public abstract class DefaultStrengthClass
{
    protected DefaultStrengthClass(double asteroidsAmount, double meteoritesAmount)
    {
        if (asteroidsAmount < 0 || meteoritesAmount < 0)
        {
            throw new ArgumentException("Can't calculate negative values");
        }

        ProtectionUnits = new ProtectionUnits(asteroidsAmount * meteoritesAmount);
    }

    public ProtectionUnits ProtectionUnits { get; set; }
    public abstract void TakeDamage(IEnumerable<Obstacles.Obstacle> damageSources);
}