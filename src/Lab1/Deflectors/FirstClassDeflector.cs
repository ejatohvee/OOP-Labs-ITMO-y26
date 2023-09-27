namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class FirstClassDeflector : DefaultDeflector
{
    public FirstClassDeflector(bool photonicDeflectorActivated)
        : base(2, 1, photonicDeflectorActivated)
    {
    }
}