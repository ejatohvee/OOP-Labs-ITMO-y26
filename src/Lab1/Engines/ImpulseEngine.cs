namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class ImpulseEngine : IEngine
{
    public abstract int CountSpeed();
    public abstract int FuelConsumption(int distance);
}
