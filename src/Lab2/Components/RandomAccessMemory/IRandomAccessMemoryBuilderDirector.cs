namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IRandomAccessMemoryBuilderDirector
{
    IRandomAccessMemoryBuilder Direct(IRandomAccessMemoryBuilder builder);
}