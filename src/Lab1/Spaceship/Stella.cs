using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Stella : Spaceship
{
    public Stella()
        : base(new ImpulseCTypeEngine(), new FirstClassDeflector(false), new FirstStrenghtClass(), new OmegaJumpEngine(), ShipWeightOverallCharacteristics.SmallWeight, false)
    {
    }
}