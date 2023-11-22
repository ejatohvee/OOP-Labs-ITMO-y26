namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseCTypeEngine : ImpulseEngine
{
    private const double SpeedInLightYearsPerHour = 10;
    private const double FuelConsumptionCoefficient = 1;
    private const double FuelConsumptionPerStartAmount = 2;

    public ImpulseCTypeEngine()
        : base(SpeedInLightYearsPerHour, FuelConsumptionCoefficient, FuelConsumptionPerStartAmount)
    {
    }
}