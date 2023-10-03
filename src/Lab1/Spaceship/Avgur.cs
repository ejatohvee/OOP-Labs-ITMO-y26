using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Avgur : Spaceship
{
    public Avgur()
        : base(new ImpulseETypeEngine(), new ThirdClassDeflector(false), new ThirdStrenghtClass(), new AlphaJumpEngine(), ShipWeightOverallCharacteristics.SmallWeight, false)
    {
    }
}