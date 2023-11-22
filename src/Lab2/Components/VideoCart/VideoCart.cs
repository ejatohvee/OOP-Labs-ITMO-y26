using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;

public class VideoCart
{
    public VideoCart(Dimensions dimensions, double videoMemoryAmount, string pcieVersion, double chipFrequency, double powerConsumption)
    {
        Dimensions = dimensions;
        VideoMemoryAmount = videoMemoryAmount;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Dimensions Dimensions { get; set; }
    public double VideoMemoryAmount { get; set; }
    public string PcieVersion { get; set; }
    public double ChipFrequency { get; set; }
    public double PowerConsumption { get; set; }

    public IVideoCartBuilder Direct(IVideoCartBuilder videoCartBuilder)
    {
        if (videoCartBuilder is null) throw new ArgumentNullException(nameof(videoCartBuilder));

        return videoCartBuilder.WithDimensions(Dimensions).VideoMemoryAmount(VideoMemoryAmount)
            .WithPcieVersion(PcieVersion).WithChipFrequency(ChipFrequency).WithPowerConsumption(PowerConsumption);
    }
}