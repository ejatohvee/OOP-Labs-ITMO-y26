using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Meredian : Spaceship
{
    public Meredian(bool isPhotonDeflectorActivated)
        : base(new ImpulseETypeEngine(), new SecondClassDeflector(isPhotonDeflectorActivated), new SecondStrenghtClass(), null, ShipWeightOverallCharacteristics.MediumWeight, true)
    {
    }
}