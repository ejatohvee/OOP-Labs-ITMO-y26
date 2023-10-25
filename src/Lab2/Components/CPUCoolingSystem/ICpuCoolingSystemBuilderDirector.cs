namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CPUCoolingSystem;

public interface ICpuCoolingSystemBuilderDirector
{
    ICpuCoolingSystemBuilder Direct(ICpuCoolingSystemBuilderDirector builder);
}