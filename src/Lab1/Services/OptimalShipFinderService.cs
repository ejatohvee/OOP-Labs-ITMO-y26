using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class OptimalShipFinderService
{
    public OptimalShipFinderService(IReadOnlyCollection<Spaceship.Spaceship> spaceships)
    {
        Spaceships = spaceships;
    }

    private IReadOnlyCollection<Spaceship.Spaceship> Spaceships { get; }

    public static Spaceship.Spaceship? OptimalShip(IReadOnlyCollection<Spaceship.Spaceship> spaceships, Trail trail, double fuelCost)
    {
        ArgumentNullException.ThrowIfNull(spaceships);

        Spaceship.Spaceship? optimalSpaceship = null;
        double minMoney = double.MaxValue;

        foreach (Spaceship.Spaceship spaceship in spaceships)
        {
            if (trail == null) continue;
            TrailState trailState = trail.TrailResult(spaceship);
            if (trailState is TrailState.ShipDestroyed or TrailState.CrewWasKilled or TrailState.ShipLost) continue;

            TrailData trailData = trail.TrailStatistic(spaceship, fuelCost);

            if (!(trailData.Money < minMoney)) continue;
            optimalSpaceship = spaceship;
            minMoney = trailData.Money;
        }

        return optimalSpaceship;
    }
}