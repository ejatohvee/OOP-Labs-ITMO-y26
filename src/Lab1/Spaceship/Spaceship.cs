using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public abstract class Spaceship
{
    protected Spaceship(ImpulseEngine impulseEngine, DefaultDeflector? deflector, DefaultStrengthClass strengthClass, JumpEngine? jumpEngine)
    {
        ImpulseEngine = impulseEngine;
        DefaultDeflector = deflector;
        DefaultStrengthClass = strengthClass;
        JumpEngine = jumpEngine;
    }

    public ImpulseEngine ImpulseEngine { get; }
    public JumpEngine? JumpEngine { get; }

    public DefaultDeflector? DefaultDeflector { get; }

    public DefaultStrengthClass DefaultStrengthClass { get; }
}