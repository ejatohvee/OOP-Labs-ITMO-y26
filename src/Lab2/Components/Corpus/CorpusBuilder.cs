using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;

public abstract class CorpusBuilder : ICorpusBuilder
{
    private readonly List<string> _supportedMotherboardFormFactors = new();
    private Dimensions? _maxVideCartDimensions;
    private Dimensions? _dimensions;

    public ICorpusBuilder WithMaxVideCartDimensions(Dimensions maxVideCartDimensions)
    {
        _maxVideCartDimensions = maxVideCartDimensions;
        return this;
    }

    public ICorpusBuilder AddSupportedMotherboardFormFactor(string supportedMotherboardFormFactor)
    {
        _supportedMotherboardFormFactors.Add(supportedMotherboardFormFactor);
        return this;
    }

    public ICorpusBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public Corpus Build()
    {
        return new Corpus(
            _maxVideCartDimensions ?? throw new ArgumentNullException(nameof(_maxVideCartDimensions)),
            _supportedMotherboardFormFactors,
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }
}