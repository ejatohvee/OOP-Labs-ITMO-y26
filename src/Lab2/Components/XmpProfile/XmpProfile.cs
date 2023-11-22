using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class XmpProfile
{
    public XmpProfile(string timings, double voltage, double frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timings { get; set; }
    public double Voltage { get; set; }
    public double Frequency { get; set; }

    public IXmpProfileBuilder Direct(IXmpProfileBuilder xmpProfileBuilder)
    {
        if (xmpProfileBuilder is null) throw new ArgumentNullException(nameof(xmpProfileBuilder));

        return xmpProfileBuilder.WithTimings(Timings).WithVoltage(Voltage).WithFrequency(Frequency);
    }
}