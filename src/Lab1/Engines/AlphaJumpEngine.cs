namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class AlphaJumpEngine : JumpEngine
{
    private const double JumpDistanceInLightYears = 15;
    private const double FuelConsumptionCoefficient = 1;

    public AlphaJumpEngine()
        : base(JumpDistanceInLightYears, FuelConsumptionCoefficient)
    {
    }
}