using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class Environments
{
    protected Environments(IReadOnlyCollection<Obstacle>? obstacles, DistanceOfPathSegment distance)
    {
        Obstacles = obstacles ?? new List<Obstacle>();
        Distance = distance.GetDistance();
    }

    public double Distance { get; }
    private IReadOnlyCollection<Obstacle> Obstacles { get; }

    public virtual ShipState CanMoveThrough(Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        switch (DamageCheckService.DamageCheck(Obstacles, spaceship))
        {
            case ShipState.ShipDestroyed:
                return ShipState.ShipDestroyed;
            case ShipState.CrewWasKilled:
                return ShipState.CrewWasKilled;
            case ShipState.DeflectorDestroyed:
                return ShipState.DeflectorDestroyed;
            default:
                return ShipState.Normal;
        }
    }
}