namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class AlphaJumpEngine : JumpEngine
{
    private int _speed;
    private int _fuelconsumption;

    public override int CountSpeed()
    {
        _speed = 1 * 100;
        return _speed;
    }

    public override int FuelConsumption(int distance)
    {
        _fuelconsumption = 1 * distance;
        return _fuelconsumption;
    }
}