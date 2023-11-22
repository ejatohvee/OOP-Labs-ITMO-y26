using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class RandomAccessMemory
{
    public RandomAccessMemory(double freeMemoryAmount, IList<JedecVoltagePair> jedecVoltagePairs, IList<XmpProfile> xmpProfile, string formFactor, string ddr, double powerConsumption)
    {
        FreeMemoryAmount = freeMemoryAmount;
        SupportedJedecVoltagePairs = jedecVoltagePairs;
        AvailableXmpProfiles = xmpProfile;
        FormFactor = formFactor;
        Ddr = ddr;
        PowerConsumption = powerConsumption;
    }

    public double FreeMemoryAmount { get; set; }
    public IList<JedecVoltagePair> SupportedJedecVoltagePairs { get; }
    public IList<XmpProfile> AvailableXmpProfiles { get; }
    public string FormFactor { get; set; }
    public string Ddr { get; set; }
    public double PowerConsumption { get; set; }

    public IRandomAccessMemoryBuilder Direct(IRandomAccessMemoryBuilder randomAccessMemoryBuilder)
    {
        if (randomAccessMemoryBuilder is null) throw new ArgumentNullException(nameof(randomAccessMemoryBuilder));

        foreach (JedecVoltagePair jedecVoltagePair in SupportedJedecVoltagePairs)
        {
            randomAccessMemoryBuilder.AddSupportedJedecVoltagePair(jedecVoltagePair);
        }

        foreach (XmpProfile xmpProfile in AvailableXmpProfiles)
        {
            randomAccessMemoryBuilder.AddXmpProfile(xmpProfile);
        }

        return randomAccessMemoryBuilder.WithFreeMemoryAmount(FreeMemoryAmount).WithFormFactor(FormFactor).WithDdrStandard(Ddr).WithPowerConsumption(PowerConsumption);
    }
}