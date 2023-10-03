using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

public class FirstStrenghtClass : DefaultStrengthClass
{
    private double _protectionUnits;

    public FirstStrenghtClass()
        : base(1, 0)
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