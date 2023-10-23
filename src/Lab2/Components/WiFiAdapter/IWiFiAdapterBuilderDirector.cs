namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public interface IWiFiAdapterBuilderDirector
{
    IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder builder);
}