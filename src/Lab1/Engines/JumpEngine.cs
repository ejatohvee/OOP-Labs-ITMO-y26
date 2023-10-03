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

    private double PriceOfFlight { get; set; }

    public double MoneyConsumption(double distance)
    {
        PriceOfFlight = distance * FuelConsumptionCoefficient;
        return PriceOfFlight;
    }
}