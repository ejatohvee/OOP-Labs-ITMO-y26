using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Meredian : Spaceship
{
    private ShipWeightOverallCharacteristics MediumWeight;
    private bool _antiNeutrinoEmitter = true;

    public Meredian()
        : base(new ImpulseETypeEngine(), new SecondClassDeflector(false), new SecondStrenghtClass(), null)
    {
    }
}