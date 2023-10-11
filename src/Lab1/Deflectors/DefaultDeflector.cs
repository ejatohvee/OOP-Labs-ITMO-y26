using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class DefaultDeflector : IDeflector
{
    protected DefaultDeflector(double asteroidsAmount, double meteoritesAmount, bool photonicDeflectorActivated)
    {
        if (asteroidsAmount < 0 || meteoritesAmount < 0)
        {
            throw new ArgumentException("Can't calculate negative values");
        }

        PhotonicShield = 0;
        ProtectionUnits = new ProtectionUnits(asteroidsAmount * meteoritesAmount * 10);

        if (photonicDeflectorActivated)
        {
            PhotonicShield = 3;
        }
    }

    public bool IsDeflectorDestroyed { get; set; }

    private double PhotonicShield { get; set; }
    private ProtectionUnits ProtectionUnits { get; set; }
    public virtual ShipState TakeDamage(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        switch (obstacle)
        {
            case AntimatterOutbreak:
            {
                if (PhotonicShield > 0)
                {
                    PhotonicShield -= 1;
                    return ShipState.DamageIsNotCritical;
                }

                return ShipState.CrewWasKilled;
            }

            case CosmicWhales:
            {
                return ShipState.ShipDestroyed;
            }

            default:
                ProtectionUnits = ProtectionUnits.SubtractValue(ProtectionUnits, obstacle.Damage);
                if (ProtectionUnits.Value <= 0)
                {
                    IsDeflectorDestroyed = true;
                    return ShipState.DeflectorDestroyed;
                }

                return ShipState.DamageIsNotCritical;
        }
    }
}