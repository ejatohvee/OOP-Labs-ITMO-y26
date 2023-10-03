using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class Environment
{
    protected Environment(IReadOnlyCollection<Obstacle> obstacles, DistanceOfPathSegment distance)
    {
        Obstacles = obstacles;
        Distance = distance.GetDistance();
    }

    public IReadOnlyCollection<Obstacle> Obstacles { get; }
    public int Distance { get; }

    public abstract ShipState CanMoveThrough(Spaceship.Spaceship? spaceship);
}