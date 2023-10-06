using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Avgur : Spaceship
{
    public Avgur(bool isPhotonDeflectorActivated)
        : base(new ImpulseETypeEngine(), new ThirdClassDeflector(isPhotonDeflectorActivated), new ThirdStrenghtClass(), new AlphaJumpEngine(), ShipWeightOverallCharacteristics.SmallWeight, false)
    {
    }
}