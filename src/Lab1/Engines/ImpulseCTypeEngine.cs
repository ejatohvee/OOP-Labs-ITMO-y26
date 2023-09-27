namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseCTypeEngine : ImpulseEngine
{
    private int _speed;
    private int _fuelconsumption;

    public override int CountSpeed()
    {
        _speed = 10;
        return _speed;
    }

    public override int FuelConsumption(int distance)
    {
        _fuelconsumption = 1 * distance;
        return _fuelconsumption;
    }
}