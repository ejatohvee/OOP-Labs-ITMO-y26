using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;

public interface ICorpusBuilder
{
    ICorpusBuilder WithMaxVideCartDimensions(Dimensions maxVideCartDimensions);
    ICorpusBuilder AddSupportedMotherboardFormFactor(string supportedMotherboardFormFactor);
    ICorpusBuilder WithDimensions(Dimensions dimensions);
}