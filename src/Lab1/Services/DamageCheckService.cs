using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class DamageCheckService
{
    public static ShipState DamageCheck(IReadOnlyCollection<Obstacle> obstacles, Spaceship.Spaceship spaceship)
    {
        ArgumentNullException.ThrowIfNull(obstacles);
        ArgumentNullException.ThrowIfNull(spaceship);

        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle is CosmicWhales && spaceship.AntiNeutrinoEmitter) continue;
            if (spaceship.DefaultDeflector != null && !spaceship.DefaultDeflector.IsDeflectorDestroyed)
            {
                switch (spaceship.DefaultDeflector.TakeDamage(obstacle))
                {
                    case ShipState.DeflectorDestroyed:
                    {
                        spaceship.DefaultDeflector.IsDeflectorDestroyed = true;
                        return ShipState.DeflectorDestroyed;
                    }

                    case ShipState.CrewWasKilled:
                        return ShipState.CrewWasKilled;

                    case ShipState.ShipDestroyed:
                        return ShipState.ShipDestroyed;
                }
            }
            else
            {
                if (spaceship.DefaultStrengthClass.TakeDamage(obstacle) == ShipState.ShipDestroyed)
                {
                    return ShipState.ShipDestroyed;
                }

                if (obstacle.KillCrew)
                {
                    return ShipState.CrewWasKilled;
                }
            }
        }

        return ShipState.Normal;
    }
}