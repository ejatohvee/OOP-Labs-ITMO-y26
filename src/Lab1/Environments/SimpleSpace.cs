using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class SimpleSpace : Environments
{
    public SimpleSpace(IReadOnlyCollection<Obstacle>? obstacles, DistanceOfPathSegment distance)
        : base(obstacles, distance)
    {
    }

    public override ShipState CanMoveThrough(Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        if (spaceship.ImpulseEngine is null)
        {
            return ShipState.ShipLost;
        }

        return base.CanMoveThrough(spaceship);
    }
}
