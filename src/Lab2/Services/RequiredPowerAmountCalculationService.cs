using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class RequiredPowerAmountCalculationService
{
    public static double RequiredPowerAmountCalculate(PersonalComputer personalComputer)
    {
        double requiredPowerAmount = 0;
        requiredPowerAmount += personalComputer.Cpu.PowerConsumption;
        if (personalComputer.WiFiAdapter != null) requiredPowerAmount += personalComputer.WiFiAdapter.PowerConsumption;
        requiredPowerAmount += personalComputer.RandomAccessMemories.Sum(randomAccessMemory => randomAccessMemory.PowerConsumption);
        if (personalComputer.VideoCarts is not null)
            requiredPowerAmount += personalComputer.VideoCarts.Sum(videoCart => videoCart.PowerConsumption);
        if (personalComputer.Ssds is not null)
            requiredPowerAmount += personalComputer.Ssds.Sum(ssd => ssd.PowerConsumption);
        if (personalComputer.Hdds is not null)
            requiredPowerAmount += personalComputer.Hdds.Sum(hdd => hdd.PowerConsumption);
        return requiredPowerAmount;
    }
}