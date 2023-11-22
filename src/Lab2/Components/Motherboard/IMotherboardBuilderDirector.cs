namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IMotherboardBuilderDirector
{
    IMotherboardBuilder Direct(IMotherboardBuilder builder);
}