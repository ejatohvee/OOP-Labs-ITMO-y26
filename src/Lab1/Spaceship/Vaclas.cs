using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Vaclas : Spaceship
{
    public Vaclas(bool isPhotonDeflectorActivated)
        : base(new ImpulseETypeEngine(), new FirstClassDeflector(isPhotonDeflectorActivated), new FirstStrenghtClass(), new GammaJumpEngine(), ShipWeightOverallCharacteristics.MediumWeight, false)
    {
    }
}