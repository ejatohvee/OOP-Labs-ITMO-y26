using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class PassageShipTests
{
    [Fact]
    public void CheckTrailPleasureShuttleMoveThroughHighDensityNebulaFailed()
    {
        var pleasureShuttle = new PleasureShuttle();
        var environment = new HighDensityNebula(null, DistanceOfPathSegment.Huge);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.ShipLost;
        TrailState trailState = trail.TrailResult(pleasureShuttle);

        Assert.Equal(expected, trailState);
    }

    [Fact]
    public void CheckTrailAvgurMoveThroughHighDensityNebulaFailed()
    {
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);
        var environment = new HighDensityNebula(null, DistanceOfPathSegment.Huge);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.ShipLost;
        TrailState trailState = trail.TrailResult(avgur);

        Assert.Equal(expected, trailState);
    }

    [Fact]
    public void CheckTrailVaclasMoveThroughHighDensityNebulaWithAntimatterOutbreakPhotonDeflectorDisabledFailed()
    {
        const bool isPhotonDeflectorActivated = false;
        var vaclas = new Vaclas(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new[] { new AntimatterOutbreak() };
        var environment = new HighDensityNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.CrewWasKilled;
        TrailState trailState = trail.TrailResult(vaclas);

        Assert.Equal(expected, trailState);
    }

    [Fact]
    public void CheckTrailVaclasMoveThroughHighDensityNebulaWithAntimatterOutbreakPhotonDeflectorEnabledSuccess()
    {
        const bool isPhotonDeflectorActivated = true;
        var vaclas = new Vaclas(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new[] { new AntimatterOutbreak() };
        var environment = new HighDensityNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.Success;
        TrailState trailState = trail.TrailResult(vaclas);

        Assert.Equal(expected, trailState);
    }

    [Fact]
    public void CheckTrailVaclasMoveThroughNitrideParticlesNebulaWithCosmicWhaleDestroyed()
    {
        const bool isPhotonDeflectorActivated = false;
        var vaclas = new Vaclas(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new[] { new CosmicWhales() };
        var environment = new NitrideParticlesNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.ShipDestroyed;
        TrailState trailState = trail.TrailResult(vaclas);

        Assert.Equal(expected, trailState);
    }

    [Fact]
    public void CheckTrailAvgurMoveThroughNitrideParticlesNebulaWithCosmicWhaleDeflectorDamaged()
    {
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new[] { new CosmicWhales() };
        var environment = new NitrideParticlesNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.ShieldLost;
        TrailState trailState = trail.TrailResult(avgur);

        Assert.Equal(expected, trailState);
    }

    [Fact]
    public void CheckTrailMeredianMoveThroughNitrideParticlesNebulaWithCosmicWhaleDeflectorSuccess()
    {
        const bool isPhotonDeflectorActivated = false;
        var meredian = new Meredian(isPhotonDeflectorActivated);
        IReadOnlyCollection<Obstacle> obstacles = new[] { new CosmicWhales() };
        var environment = new NitrideParticlesNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environments.Environments> pathSegment = new List<Environments.Environments> { environment };
        var trail = new Trail(pathSegment);

        TrailState expected = TrailState.Success;
        TrailState trailState = trail.TrailResult(meredian);

        Assert.Equal(expected, trailState);
    }
}