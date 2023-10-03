using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Vaclas : Spaceship
{
    public Vaclas()
        : base(new ImpulseETypeEngine(), new FirstClassDeflector(false), new FirstStrenghtClass(), new GammaJumpEngine(), ShipWeightOverallCharacteristics.MediumWeight, false)
    {
    }
}