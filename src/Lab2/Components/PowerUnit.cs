namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class PowerUnit
{
    public PowerUnit(double peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public double PeakLoad { get; set; }
}