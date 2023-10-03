using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class DamageCheckService
{
    private ProtectionUnits _totalProtectionUnitsAmount;
    private ProtectionUnits _deflectorProtectionUnits;
    private ProtectionUnits _protectionProtectionUnits;

    public ProtectionUnits TotalProtectionAmount(DefaultDeflector? deflector, DefaultStrengthClass protection)
    {
        ArgumentNullException.ThrowIfNull(deflector);
        ArgumentNullException.ThrowIfNull(protection);
        _deflectorProtectionUnits = deflector.ProtectionUnits;
        _protectionProtectionUnits = protection.ProtectionUnits;
        _totalProtectionUnitsAmount = deflector.ProtectionUnits + protection.ProtectionUnits;
        return _totalProtectionUnitsAmount;
    }

    public ShipState DamageCheck(Obstacle obstacle, DefaultDeflector? deflector, DefaultStrengthClass protection)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        TotalProtectionAmount(deflector, protection);
        _totalProtectionUnitsAmount -= obstacle.Damage;
        if (obstacle.KillCrew)
        {
            return ShipState.CrewWasKilled;
        }
        else if (_totalProtectionUnitsAmount.Value <= 0)
        {
            return ShipState.ShipDestroyed;
        }
        else if (deflector is not null && obstacle.Damage >= _deflectorProtectionUnits.Value)
        {
            return ShipState.DeflectorDestroyed;
        }
        else if (obstacle is CosmicWhales)
        {
            return deflector is not null ? ShipState.DeflectorDestroyed : ShipState.ShipDestroyed;
        }

        return ShipState.DamageIsNotCritical;
    }
}