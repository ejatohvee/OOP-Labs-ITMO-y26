using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class DefaultDeflector : IDeflector
{
    protected DefaultDeflector(int asteroidsAmount, int meteoritesAmount, bool photonicDeflectorActivated)
    {
        if (asteroidsAmount < 0 || meteoritesAmount < 0)
        {
            throw new ArgumentException("Can't calculate negative values");
        }

        PhotonicShield = 0;
        ProtectionUnits = new ProtectionUnits(asteroidsAmount * meteoritesAmount);

        if (photonicDeflectorActivated)
        {
            PhotonicShield = 3;
        }
    }

    public int PhotonicShield { get; set; }
    public ProtectionUnits ProtectionUnits { get; set; }
    public ShipState TakeDamage(IEnumerable<Obstacles.Obstacle> damageSources)
    {
        ArgumentNullException.ThrowIfNull(damageSources);

        foreach (Obstacles.Obstacle obstacle in damageSources)
        {
            ProtectionUnits -= obstacle.Damage;
            if (obstacle is not AntimatterOutbreak) continue;
            if (PhotonicShield is not 0)
            {
                PhotonicShield -= 1;
            }
            else
            {
                return ShipState.CrewWasKilled;
            }
        }

        return ShipState.Normal;
    }
}