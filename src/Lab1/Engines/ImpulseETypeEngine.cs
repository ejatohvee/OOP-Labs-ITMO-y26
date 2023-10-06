namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseETypeEngine : ImpulseEngine
{
    private const double SpeedInLightYearsPerHour = 40;
    private const double FuelConsumptionCoefficient = 5;
    private const double FuelConsumptionPerStartAmount = 4;

    public ImpulseETypeEngine()
        : base(SpeedInLightYearsPerHour, FuelConsumptionCoefficient, FuelConsumptionPerStartAmount)
    {
    }
}