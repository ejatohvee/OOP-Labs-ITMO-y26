using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Hdd
{
    public Hdd(double capacity, double spindleRotationSpeed, double powerConsumption)
    {
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public double Capacity { get; set; }
    public double SpindleRotationSpeed { get; set; }
    public double PowerConsumption { get; set; }

    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        if (hddBuilder is null) throw new ArgumentNullException(nameof(hddBuilder));

        return hddBuilder.WithCapacity(Capacity).WithSpindleRotationSpeed(SpindleRotationSpeed)
            .WithPowerConsumption(PowerConsumption);
    }
}