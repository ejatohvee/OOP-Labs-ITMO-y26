using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class PcieAndSataPortsRequiredQuantityCalculationService
{
    public static int PciePortsRequiredQuantityCalculator(PersonalComputer personalComputer)
    {
        int videoCartsConnections = 0;
        int wiFiAdapterConnections = 0;
        int ssdsPcieConnections = 0;

        if (personalComputer.VideoCarts is not null)
        {
            videoCartsConnections += personalComputer.VideoCarts.Count;
        }

        if (personalComputer.Ssds is not null)
        {
            ssdsPcieConnections += personalComputer.Ssds.Count(ssd => ssd.ConnectionType.PcieConnection);
        }

        if (personalComputer.WiFiAdapter is not null)
        {
            wiFiAdapterConnections += 1;
        }

        return videoCartsConnections + wiFiAdapterConnections + ssdsPcieConnections;
    }

    public static int SataPortsRequiredQuantityCalculator(PersonalComputer personalComputer)
    {
        int ssdsSataConnections = 0;
        int hddsSataConnections = 0;

        if (personalComputer.Ssds is not null)
        {
            ssdsSataConnections += personalComputer.Ssds.Count(ssd => ssd.ConnectionType.SataConnection);
        }

        if (personalComputer.Hdds is not null)
        {
            hddsSataConnections += personalComputer.Hdds.Count;
        }

        return ssdsSataConnections + hddsSataConnections;
    }
}