using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;

public class Corpus
{
    public Corpus(Dimensions maxVideCartDimensions, IList<string> supportedMotherboardFormFactors, Dimensions dimensions)
    {
        MaxVideCartDimensions = maxVideCartDimensions;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
    }

    public Dimensions MaxVideCartDimensions { get; set; }
    public IList<string> SupportedMotherboardFormFactors { get; }
    public Dimensions Dimensions { get; set; }

    public ICorpusBuilder Direct(ICorpusBuilder corpusBuilder)
    {
        if (corpusBuilder is null) throw new ArgumentNullException(nameof(corpusBuilder));

        foreach (string motherboardFormFactors in SupportedMotherboardFormFactors)
        {
            corpusBuilder.AddSupportedMotherboardFormFactor(motherboardFormFactors);
        }

        return corpusBuilder.WithDimensions(Dimensions).WithMaxVideCartDimensions(MaxVideCartDimensions);
    }
}