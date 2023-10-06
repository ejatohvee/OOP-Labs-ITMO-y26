using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trails;

public class Trail
{
    public Trail(IReadOnlyCollection<Environments.Environments> pathSegments)
    {
        PathSegments = pathSegments;
    }

    public IReadOnlyCollection<Environments.Environments> PathSegments { get; }

    public TrailData TrailStatistic(Spaceship.Spaceship spaceship, double fuelCost)
    {
        ArgumentNullException.ThrowIfNull(spaceship);
        double totalTimeAmount = 0;
        double totalMoneySpend = 0;

        foreach (Environments.Environments environment in PathSegments)
        {
            totalTimeAmount += TrailDataCalculationService.TimeSpend(environment.Distance, spaceship);
            totalMoneySpend += totalTimeAmount * TrailDataCalculationService.MoneySpend(environment, environment.Distance, spaceship, fuelCost);
        }

        return new TrailData(totalTimeAmount, totalMoneySpend);
    }

    public TrailState TrailResult(Spaceship.Spaceship spaceship)
    {
        foreach (Environments.Environments environment in PathSegments)
        {
            ShipState result = environment.CanMoveThrough(spaceship);
            switch (result)
            {
                case ShipState.ShipDestroyed:
                    return TrailState.ShipDestroyed;
                case ShipState.CrewWasKilled:
                    return TrailState.CrewWasKilled;
                case ShipState.ShipLost:
                    return TrailState.ShipLost;
                case ShipState.DeflectorDestroyed:
                    return TrailState.ShieldLost;
                default:
                    return TrailState.Success;
            }
        }

        return TrailState.Success;
    }
}