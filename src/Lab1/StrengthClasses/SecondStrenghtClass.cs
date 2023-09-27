using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

public class SecondStrenghtClass : DefaultStrengthClass
{
    private int _protectionUnits;

    public SecondStrenghtClass()
        : base(5, 2)
    {
    }

    public override void TakeDamage(IEnumerable<Obstacle> damageSources)
    {
        ArgumentNullException.ThrowIfNull(damageSources);

        foreach (Obstacles.Obstacle obstacle in damageSources)
        {
            _protectionUnits -= obstacle.Damage;
        }
    }
}