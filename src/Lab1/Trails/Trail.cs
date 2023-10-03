using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trails;

public class Trail
{
    public Trail(IReadOnlyCollection<Environment> pathSegment)
    {
        PathSegment = pathSegment;
    }

    private IReadOnlyCollection<Environment> PathSegment { get; }

    public TrailState TrailResult(Spaceship.Spaceship spaceship)
    {
        foreach (Environment environment in PathSegment)
        {
            if (environment.CanMoveThrough(spaceship) is ShipState.ShipDestroyed)
            {
                return TrailState.ShipDestroyed;
            }
            else if (environment.CanMoveThrough(spaceship) is ShipState.CrewWasKilled)
            {
                return TrailState.CrewWasKilled;
            }
            else if (environment.CanMoveThrough(spaceship) is ShipState.ShipLost)
            {
                return TrailState.ShipLost;
            }
        }

        return TrailState.Success;
    }
}