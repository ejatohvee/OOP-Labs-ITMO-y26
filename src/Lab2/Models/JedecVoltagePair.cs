namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class JedecVoltagePair
{
    public JedecVoltagePair(double jedec, double voltage)
    {
        Jedec = jedec;
        Voltage = voltage;
    }

    public double Jedec { get; }
    public double Voltage { get; }
}