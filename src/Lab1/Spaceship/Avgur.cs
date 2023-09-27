using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

public class Avgur : Spaceship
{
    private ShipWeightOverallCharacteristics SmallWeight;
    private bool _antiNeutrinoEmitter;

    public Avgur()
        : base(new ImpulseETypeEngine(), new ThirdClassDeflector(false), new ThirdStrenghtClass(), new AlphaJumpEngine())
    {
    }
}