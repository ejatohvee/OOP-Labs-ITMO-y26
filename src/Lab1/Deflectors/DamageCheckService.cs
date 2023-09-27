using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;
namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DamageCheckService
{
    private ProtectionUnits _totalProtectionUnitsAmount;
    private ProtectionUnits _deflectorProtectionUnits;
    private ProtectionUnits _protectionProtectionUnits;

    public void TotalProtectionAmount(DefaultDeflector deflector, DefaultStrengthClass protection)
    {
        ArgumentNullException.ThrowIfNull(deflector);
        ArgumentNullException.ThrowIfNull(protection);
        _deflectorProtectionUnits = deflector.ProtectionUnits;
        _protectionProtectionUnits = protection.ProtectionUnits;
        _totalProtectionUnitsAmount = deflector.ProtectionUnits + protection.ProtectionUnits;
    }

    public ShipState DamageCheck()
    {
        if (_totalProtectionUnitsAmount.Value is 0)
        {
            return ShipState.Destroyed;
        }
        else if (_deflectorProtectionUnits.Value > 0 && _totalProtectionUnitsAmount.Value == _protectionProtectionUnits.Value)
        {
            return ShipState.DeflectorDestroyed;
        }

        return ShipState.DamageIsNotCritical;
    }
}