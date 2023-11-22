using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trails;

public class TrailData
{
    public TrailData(double totalTimeAmount, double totalMoneySpend)
    {
        TimeSpended = totalTimeAmount;
        Money = totalMoneySpend;
    }

    public TrailState TrailState { get; }

    public double TimeSpended { get; }
    public double Money { get; }
}