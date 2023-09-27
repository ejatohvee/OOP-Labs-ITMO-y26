namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(int damage, bool killCrew)
    {
        Damage = damage;
        KillCrew = killCrew;
    }

    public int Damage { get; }
    public bool KillCrew { get; }
}