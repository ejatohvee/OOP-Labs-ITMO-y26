namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;

public interface ICorpusBuilderDirector
{
    ICorpusBuilder Direct(ICorpusBuilder builder);
}