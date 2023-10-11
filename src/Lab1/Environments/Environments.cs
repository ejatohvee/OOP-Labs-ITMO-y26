using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class Environments
{
    protected Environments(IReadOnlyCollection<Obstacle> obstacles, DistanceOfPathSegment distance)
    {
        Obstacles = obstacles;
        Distance = distance.GetDistance();
    }

    public double Distance { get; }
    private IReadOnlyCollection<Obstacle> Obstacles { get; }

    public virtual ShipState CanMoveThrough(Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        return DamageCheckService.DamageCheck(Obstacles, spaceship);
    }
}