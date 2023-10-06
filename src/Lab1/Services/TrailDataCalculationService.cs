using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class TrailDataCalculationService
{
    public static double TimeSpend(double distance, Spaceship.Spaceship spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        if (spaceship.ImpulseEngine != null)
        {
            return distance / spaceship.ImpulseEngine.Speed;
        }

        throw new InvalidOperationException("No ImpulseEngine");
    }

    public static double MoneySpend(Environments.Environments environment, double distance, Spaceship.Spaceship spaceship, double fuelCost)
    {
        ArgumentNullException.ThrowIfNull(spaceship);
        ArgumentNullException.ThrowIfNull(spaceship.ImpulseEngine);

        if (environment is HighDensityNebula && spaceship.JumpEngine != null)
        {
            return spaceship.JumpEngine.FuelConsumption(distance) * fuelCost;
        }

        if (environment is NitrideParticlesNebula && spaceship.ImpulseEngine is ImpulseETypeEngine)
        {
            return ((spaceship.ImpulseEngine.FuelConsumption(distance) * fuelCost) / 1.5) + spaceship.ImpulseEngine.FuelConsumptionPerStart;
        }

        return (spaceship.ImpulseEngine.FuelConsumption(distance) * fuelCost) + spaceship.ImpulseEngine.FuelConsumptionPerStart;
    }
}