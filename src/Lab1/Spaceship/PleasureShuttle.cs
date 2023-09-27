using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class PleasureShuttle : Spaceship
{
    private ShipWeightOverallCharacteristics SmallWeight;
    private bool _antiNeutrinoEmitter;
    public PleasureShuttle()
        : base(new ImpulseCTypeEngine(), null, new FirstStrenghtClass(), null)
    {
    }
}