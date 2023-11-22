namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Dimensions
{
    private double height;
    private double lenght;

    public Dimensions(double height, double lenght)
    {
        this.height = height;
        this.lenght = lenght;
    }

    public static bool Сomparison(Dimensions dimensionOne, Dimensions dimensionTwo)
    {
        if (dimensionOne.height != dimensionTwo.height || dimensionOne.height != dimensionTwo.height)
        {
            return false;
        }

        return true;
    }
}