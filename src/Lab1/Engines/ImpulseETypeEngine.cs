namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseETypeEngine : ImpulseEngine
{
    private int _speed;
    private int _fuelconsumption;

    public override int CountSpeed()
    {
        _speed = 2 * 10;
        return _speed;
    }

    public override int FuelConsumption(int distance)
    {
        _fuelconsumption = 2 * distance;
        return _fuelconsumption;
    }
}