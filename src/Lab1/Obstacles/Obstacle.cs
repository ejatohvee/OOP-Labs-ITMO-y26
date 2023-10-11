namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(double damage, bool killCrew)
    {
        Damage = damage;
        KillCrew = killCrew;
    }

    public double Damage { get; }
    public bool KillCrew { get; }
}