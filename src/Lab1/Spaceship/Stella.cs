using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Stella : Spaceship
{
    public Stella(bool isPhotonDeflectorActivated)
        : base(new ImpulseCTypeEngine(), new FirstClassDeflector(isPhotonDeflectorActivated), new FirstStrenghtClass(), new OmegaJumpEngine(), ShipWeightOverallCharacteristics.SmallWeight, false)
    {
    }
}