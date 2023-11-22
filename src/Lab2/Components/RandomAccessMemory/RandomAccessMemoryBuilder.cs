using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class RandomAccessMemoryBuilder : IRandomAccessMemoryBuilder
{
    private double _freeMemoryAmount;
    private List<JedecVoltagePair> _supportedJedecVoltagePairs = new();
    private List<XmpProfile> _availableXmpProfiles = new();
    private string? _formFactor;
    private string? _ddr;
    private double _powerConsumption;

    public IRandomAccessMemoryBuilder WithFreeMemoryAmount(double freeMemoryAmount)
    {
        _freeMemoryAmount = freeMemoryAmount;
        return this;
    }

    public IRandomAccessMemoryBuilder AddSupportedJedecVoltagePair(JedecVoltagePair jedecVoltagePair)
    {
        _supportedJedecVoltagePairs.Add(jedecVoltagePair);
        return this;
    }

    public IRandomAccessMemoryBuilder AddXmpProfile(XmpProfile xmpProfile)
    {
        _availableXmpProfiles.Add(xmpProfile);
        return this;
    }

    public IRandomAccessMemoryBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRandomAccessMemoryBuilder WithDdrStandard(string ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IRandomAccessMemoryBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RandomAccessMemory Build()
    {
        return new RandomAccessMemory(
            _freeMemoryAmount,
            _supportedJedecVoltagePairs ?? throw new ArgumentNullException(nameof(_supportedJedecVoltagePairs)),
            _availableXmpProfiles ?? throw new ArgumentNullException(nameof(_availableXmpProfiles)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _powerConsumption);
    }
}