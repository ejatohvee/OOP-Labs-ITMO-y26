using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public abstract class Spaceship
{
    protected Spaceship(ImpulseEngine? impulseEngine, DefaultDeflector? deflector, DefaultStrengthClass strengthClass, JumpEngine? jumpEngine, ShipWeightOverallCharacteristics shipWeight, bool antiNeutrinoEmitter)
    {
        ImpulseEngine = impulseEngine;
        DefaultDeflector = deflector;
        DefaultStrengthClass = strengthClass;
        JumpEngine = jumpEngine;
        ShipWeight = shipWeight;
        AntiNeutrinoEmitter = antiNeutrinoEmitter;
    }

    public ImpulseEngine? ImpulseEngine { get; }
    public JumpEngine? JumpEngine { get; }

    public DefaultDeflector? DefaultDeflector { get; }

    public DefaultStrengthClass DefaultStrengthClass { get; }

    public ShipWeightOverallCharacteristics ShipWeight { get; }

    public bool AntiNeutrinoEmitter { get; }
}