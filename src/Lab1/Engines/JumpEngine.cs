namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class JumpEngine : IEngine
{
    protected JumpEngine(double jumpDistance, double fuelConsumptionCoefficient)
    {
        JumpDistance = jumpDistance;
        FuelConsumptionCoefficient = fuelConsumptionCoefficient;
    }

    public double JumpDistance { get; }

    private double FuelConsumptionCoefficient { get; }

    private double FuelConsumed { get; set; }

    public double FuelConsumption(double distance)
    {
        FuelConsumed = distance * FuelConsumptionCoefficient;
        return FuelConsumed;
    }
}