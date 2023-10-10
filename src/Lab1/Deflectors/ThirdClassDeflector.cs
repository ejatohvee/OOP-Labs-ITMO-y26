using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class ThirdClassDeflector : DefaultDeflector
{
    private const double AsteroidsAmountDeflectorCanWithstand = 40;
    private const double MeteoritesAmountDeflectorCanWithstand = 10;

    public ThirdClassDeflector(bool photonicDeflectorActivated)
        : base(AsteroidsAmountDeflectorCanWithstand, MeteoritesAmountDeflectorCanWithstand, photonicDeflectorActivated)
    {
    }

    public override ShipState TakeDamage(Obstacle obstacle)
    {
        return obstacle is CosmicWhales ? ShipState.DeflectorDestroyed : base.TakeDamage(obstacle);
    }
}