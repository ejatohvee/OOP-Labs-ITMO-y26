using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IRandomAccessMemoryBuilder
{
    IRandomAccessMemoryBuilder WithFreeMemoryAmount(double freeMemoryAmount);
    IRandomAccessMemoryBuilder AddSupportedJedecVoltagePair(JedecVoltagePair jedecVoltagePair);
    IRandomAccessMemoryBuilder AddXmpProfile(XmpProfile xmpProfile);
    IRandomAccessMemoryBuilder WithFormFactor(string formFactor);
    IRandomAccessMemoryBuilder WithDdrStandard(string ddr);
    IRandomAccessMemoryBuilder WithPowerConsumption(double powerConsumption);
}