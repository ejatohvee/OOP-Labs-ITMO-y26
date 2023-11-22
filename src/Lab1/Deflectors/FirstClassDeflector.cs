namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class FirstClassDeflector : DefaultDeflector
{
    private const double AsteroidsAmountDeflectorCanWithstand = 2;
    private const double MeteoritesAmountDeflectorCanWithstand = 1;
    public FirstClassDeflector(bool photonicDeflectorActivated)
        : base(AsteroidsAmountDeflectorCanWithstand, MeteoritesAmountDeflectorCanWithstand, photonicDeflectorActivated)
    {
    }
}