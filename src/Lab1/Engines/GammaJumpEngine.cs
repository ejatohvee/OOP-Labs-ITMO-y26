namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class GammaJumpEngine : JumpEngine
{
    private int _speed;
    private int _fuelconsumption;

    public override int CountSpeed()
    {
        _speed = 2 * 100;
        return _speed;
    }

    public override int FuelConsumption(int distance)
    {
        _fuelconsumption = distance * distance;
        return _fuelconsumption;
    }
}