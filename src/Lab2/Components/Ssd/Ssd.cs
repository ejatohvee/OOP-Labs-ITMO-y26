using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;

public class Ssd
{
    public Ssd(SsdConnectionType connectionType, double capacity, double maxWorkSpeed, double powerConsumption)
    {
        ConnectionType = connectionType;
        Capacity = capacity;
        MaxWorkSpeed = maxWorkSpeed;
        PowerConsumption = powerConsumption;
    }

    public SsdConnectionType ConnectionType { get; set; }
    public double Capacity { get; set; }
    public double MaxWorkSpeed { get; set; }
    public double PowerConsumption { get; set; }
}