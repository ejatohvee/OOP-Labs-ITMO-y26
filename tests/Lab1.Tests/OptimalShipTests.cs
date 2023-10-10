using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class OptimalShipTests
{
    [Fact]
    public void FindOptimalGoThroughSimpleSpacePleasureShuttleAndVaclasPleasureSuttleMoreOptimal()
    {
        const bool isPhotonDeflectorActivated = false;
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new List<Obstacle>();
        IReadOnlyCollection<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { pleasureShuttle, vaclas };
        var environment = new SimpleSpace(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        Spaceship.Spaceship expected = pleasureShuttle;
        Spaceship.Spaceship? spaceship = OptimalShipFinderService.OptimalShip(spaceships, trail, 4);

        Assert.Equal(expected, spaceship);
    }

    [Fact]
    public void FindOptimalGoThroughHighDensityNebulaAvgurAndStellaChooseStella()
    {
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);
        var stella = new Stella(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new List<Obstacle>();
        IReadOnlyCollection<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { avgur, stella };
        var environment = new HighDensityNebula(obstacles, DistanceOfPathSegment.Middle);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        Spaceship.Spaceship expected = stella;
        Spaceship.Spaceship? spaceship = OptimalShipFinderService.OptimalShip(spaceships, trail, 4);

        Assert.Equal(expected, spaceship);
    }

    [Fact]
    public void FindOptimalGoThroughNitrideParticlesNebulaPleasureShuttleAndVaclasChooseVaclas()
    {
        const bool isPhotonDeflectorActivated = false;
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new List<Obstacle>();
        IReadOnlyCollection<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { pleasureShuttle, vaclas };
        var environment = new NitrideParticlesNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        Spaceship.Spaceship expected = vaclas;
        Spaceship.Spaceship? spaceship = OptimalShipFinderService.OptimalShip(spaceships, trail, 4);

        Assert.Equal(expected, spaceship);
    }

    [Fact]
    public void FindOptimalGoThroughHighDensityNebulaStellaAndAvgurChooseAvgur()
    {
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);
        var stella = new Stella(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new List<Obstacle> { new SmallAsteroids(), new SmallAsteroids(), new Meteorites() };
        IReadOnlyCollection<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { avgur, stella };
        var environment = new HighDensityNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        Spaceship.Spaceship? expected = avgur;
        Spaceship.Spaceship? spaceship = OptimalShipFinderService.OptimalShip(spaceships, trail, 4);

        Assert.Equal(expected, spaceship);
    }
}