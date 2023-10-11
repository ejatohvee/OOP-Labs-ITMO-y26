using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class DamageCheckService
{
    public static ShipState DamageCheck(IReadOnlyCollection<Obstacle> obstacles, Spaceship.Spaceship spaceship)
    {
        ArgumentNullException.ThrowIfNull(obstacles);
        ArgumentNullException.ThrowIfNull(spaceship);

        if (obstacles.Any(obstacle => spaceship.AntiNeutrinoEmitter is false && obstacle is CosmicWhales))
        {
            return spaceship.DefaultDeflector is ThirdClassDeflector ? ShipState.DeflectorDestroyed : ShipState.ShipDestroyed;
        }

        if (obstacles.Any(obstacle => spaceship.DefaultDeflector is not null && spaceship.DefaultDeflector.TakeDamage(obstacle) == ShipState.DeflectorDestroyed))
        {
            return ShipState.DeflectorDestroyed;
        }

        if (obstacles.Any(obstacle => spaceship.DefaultDeflector is not null && obstacle.KillCrew && spaceship.DefaultDeflector.TakeDamage(obstacle) == ShipState.CrewWasKilled))
        {
                return ShipState.CrewWasKilled;
        }

        return obstacles.Any(obstacle => spaceship.DefaultDeflector is not null && spaceship.DefaultDeflector.TakeDamage(obstacle) == ShipState.DeflectorDestroyed && spaceship.DefaultStrengthClass.TakeDamage(obstacle) == ShipState.ShipDestroyed) ? ShipState.ShipDestroyed : ShipState.Normal;
    }
}