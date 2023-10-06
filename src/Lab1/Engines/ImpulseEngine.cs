namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class ImpulseEngine : IEngine
{
    protected ImpulseEngine(double speed, double fuelConsumptionCoefficient, double fuelConsumptionPerStart)
    {
        Speed = speed;
        FuelConsumptionCoefficient = fuelConsumptionCoefficient;
        FuelConsumptionPerStart = fuelConsumptionPerStart;
    }

    public double Speed { get; }
    public double FuelConsumptionPerStart { get; }

    private double FuelConsumptionCoefficient { get; }

    private double FuelConsumed { get; set; }

    public double FuelConsumption(double distance)
    {
        FuelConsumed = distance * FuelConsumptionCoefficient;
        return FuelConsumed;
    }
}
