using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class OptimalShipFinderService
{
    public OptimalShipFinderService(IReadOnlyCollection<Spaceship> spaceships)
    {
        Spaceships = spaceships;
    }

    private IReadOnlyCollection<Spaceship> Spaceships { get; }

    public static Spaceship? OptimalShip(IReadOnlyCollection<Spaceship> spaceships, Trail trail, double fuelCost)
    {
        ArgumentNullException.ThrowIfNull(spaceships);

        return spaceships
            .Where(spaceship => true)
            .Select(spaceship => new
            {
                Spaceship = spaceship,
                TrailState = trail.TrailResult(spaceship),
                TrailData = trail.TrailStatistic(spaceship, fuelCost),
            })
            .Where(result => result.TrailState != TrailState.ShipDestroyed && result.TrailState != TrailState.CrewWasKilled && result.TrailState != TrailState.ShipLost)
            .OrderBy(result => result.TrailData.Money)
            .Select(result => result.Spaceship)
            .FirstOrDefault();
    }
}