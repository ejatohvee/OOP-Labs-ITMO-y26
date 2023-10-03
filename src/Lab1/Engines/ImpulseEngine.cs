namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class ImpulseEngine : IEngine
{
    protected ImpulseEngine(double speed, double fuelConsumptionCoefficient)
    {
        Speed = speed;
        FuelConsumptionCoefficient = fuelConsumptionCoefficient;
    }

    private double FuelConsumptionCoefficient { get; }

    private double PriceOfFlight { get; set; }

    private double Speed { get; }

    public double MoneyConsumption(double distance)
    {
        PriceOfFlight = distance * FuelConsumptionCoefficient;
        return PriceOfFlight;
    }
}
