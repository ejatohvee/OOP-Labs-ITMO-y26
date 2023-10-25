namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;

public interface IVideoCartBuilderDirector
{
    IVideoCartBuilder Direct(IVideoCartBuilder builder);
}