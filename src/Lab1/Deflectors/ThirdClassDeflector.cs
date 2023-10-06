using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class ThirdClassDeflector : DefaultDeflector
{
    public ThirdClassDeflector(bool photonicDeflectorActivated)
        : base(40, 10, photonicDeflectorActivated)
    {
    }

    public override ShipState TakeDamage(Obstacle obstacle)
    {
        return obstacle is CosmicWhales ? ShipState.DeflectorDestroyed : base.TakeDamage(obstacle);
    }
}