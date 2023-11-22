namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class SecondClassDeflector : DefaultDeflector
{
    private const double AsteroidsAmountDeflectorCanWithstand = 10;
    private const double MeteoritesAmountDeflectorCanWithstand = 3;

    public SecondClassDeflector(bool photonicDeflectorActivated)
        : base(AsteroidsAmountDeflectorCanWithstand, MeteoritesAmountDeflectorCanWithstand, photonicDeflectorActivated)
    {
    }
}