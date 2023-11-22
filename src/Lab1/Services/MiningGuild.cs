namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class MiningGuild
{
    public MiningGuild(double fuelCost)
    {
        FuelCost = fuelCost;
    }

    public static double FuelCost { get; private set; }
}