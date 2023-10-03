using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class HighDensityNebula : Environment
{
    public HighDensityNebula(IReadOnlyCollection<Obstacle> obstacles, DistanceOfPathSegment distance)
        : base(obstacles, distance)
    {
    }

    public override ShipState CanMoveThrough(Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);
        var damageChecker = new DamageCheckService();

        if (spaceship.JumpEngine is null || Distance > spaceship.JumpEngine.JumpDistance)
        {
            return ShipState.ShipLost;
        }
        else
        {
            foreach (Obstacle obstacle in Obstacles)
            {
                if (damageChecker.DamageCheck(obstacle, spaceship.DefaultDeflector, spaceship.DefaultStrengthClass) is ShipState.ShipDestroyed)
                {
                    return ShipState.ShipDestroyed;
                }
                else if (damageChecker.DamageCheck(obstacle, spaceship.DefaultDeflector, spaceship.DefaultStrengthClass)
                         is ShipState.CrewWasKilled)
                {
                    return ShipState.CrewWasKilled;
                }
            }
        }

        return ShipState.Normal;
    }
}