namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class GammaJumpEngine : JumpEngine
{
    private const double JumpDistanceInLightYears = 35;
    private const double FuelConsumptionCoefficient = 10;
    public GammaJumpEngine()
        : base(JumpDistanceInLightYears, FuelConsumptionCoefficient)
    {
    }
}