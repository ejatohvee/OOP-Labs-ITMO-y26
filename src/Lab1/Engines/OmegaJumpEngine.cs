namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class OmegaJumpEngine : JumpEngine
{
    private const double JumpDistanceInLightYears = 25;
    private const double FuelConsumptionCoefficient = 5;

    public OmegaJumpEngine()
        : base(JumpDistanceInLightYears, FuelConsumptionCoefficient)
    {
    }
}