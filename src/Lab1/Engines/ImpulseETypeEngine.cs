namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseETypeEngine : ImpulseEngine
{
    private const double SpeedInLightYearsPerHour = 200;
    private const double FuelConsumptionCoefficient = 10;

    public ImpulseETypeEngine()
        : base(SpeedInLightYearsPerHour, FuelConsumptionCoefficient)
    {
    }
}