namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseCTypeEngine : ImpulseEngine
{
    private const double SpeedInLightYearsPerHour = 100;
    private const double FuelConsumptionCoefficient = 1;

    public ImpulseCTypeEngine()
        : base(SpeedInLightYearsPerHour, FuelConsumptionCoefficient)
    {
    }
}