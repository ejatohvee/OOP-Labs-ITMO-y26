using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Cpu
{
    public Cpu(string modelName, double coreFrequency, double coreAmount, string socket, bool videoCore, IList<double> memoryFrequencies, double tdp, double powerConsumption)
    {
        ModelName = modelName;
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        CpuSocket = socket;
        VideoCore = videoCore;
        MemoryFrequencies = memoryFrequencies;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string ModelName { get; set; }
    public double CoreFrequency { get; set; }
    public double CoreAmount { get; set; }
    public string CpuSocket { get; set; }
    public bool VideoCore { get; set; }
    public IList<double> MemoryFrequencies { get; }
    public double Tdp { get; set; }
    public double PowerConsumption { get; set; }

    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        if (cpuBuilder is null) throw new ArgumentNullException(nameof(cpuBuilder));

        foreach (double frequency in MemoryFrequencies)
        {
            cpuBuilder.AddMemoryFrequency(frequency);
        }

        return cpuBuilder.WithCoreFrequency(CoreFrequency).WithCoreAmount(CoreAmount).WithSocket(CpuSocket)
            .WithVideoCoreAvailability(VideoCore).WithTdpAmount(Tdp).WithPowerConsumption(PowerConsumption);
    }
}