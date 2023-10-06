using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

public abstract class DefaultStrengthClass
{
    protected DefaultStrengthClass(double asteroidsAmount, double meteoritesAmount)
    {
        if (asteroidsAmount < 0 || meteoritesAmount < 0)
        {
            throw new ArgumentException("Can't calculate negative values");
        }

        ProtectionUnits = new ProtectionUnits(asteroidsAmount * meteoritesAmount * 10);
    }

    public ProtectionUnits ProtectionUnits { get; set; }
    public ShipState TakeDamage(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        ProtectionUnits -= obstacle.Damage;
        return ProtectionUnits.Value <= 0 ? ShipState.ShipDestroyed : ShipState.DamageIsNotCritical;
    }
}