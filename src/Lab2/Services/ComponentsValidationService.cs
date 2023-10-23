using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class ComponentsValidationService
{
    public static ValidationResults PersonalComputerValidation(PersonalComputer personalComputer)
    {
        if (personalComputer is null) throw new ArgumentNullException(nameof(personalComputer));

        int pciePortsRequiredQuantity = PcieAndSataPortsRequiredQuantityCalculationService.PciePortsRequiredQuantityCalculator(personalComputer);
        int sataPortsRequiredQuantity = PcieAndSataPortsRequiredQuantityCalculationService.SataPortsRequiredQuantityCalculator(personalComputer);
        double requiredPowerAmount = RequiredPowerAmountCalculationService.RequiredPowerAmountCalculate(personalComputer);
        double permissibleExcessPowerInWatts = 60;

        if (personalComputer.Motherboard.PcieLinesAmount < pciePortsRequiredQuantity)
        {
            return new ValidationResults.ValidationError("Not enough SATA ports in motherboard.");
        }

        if (personalComputer.Motherboard.SataPortsAmount < sataPortsRequiredQuantity)
        {
            if (personalComputer.Ssds is not null)
            {
                foreach (Ssd ssd in personalComputer.Ssds)
                {
                    if (ssd.ConnectionType is not { SataConnection: true, PcieConnection: true }) continue;
                    if (!(personalComputer.Motherboard.PcieLinesAmount > pciePortsRequiredQuantity)) continue;
                    sataPortsRequiredQuantity -= 1;
                    pciePortsRequiredQuantity += 1;
                }
            }

            if (personalComputer.Motherboard.SataPortsAmount < sataPortsRequiredQuantity)
            {
                return new ValidationResults.ValidationError("Not enough SATA ports in motherboard.");
            }
        }

        if (personalComputer.PowerUnit.PeakLoad + permissibleExcessPowerInWatts < requiredPowerAmount)
        {
            return new ValidationResults.ValidationError("Insufficient power of the power unit.");
        }

        if (personalComputer.PowerUnit.PeakLoad < requiredPowerAmount && personalComputer.PowerUnit.PeakLoad + permissibleExcessPowerInWatts > requiredPowerAmount)
        {
            return new ValidationResults.WarrantyValidationError("Required power slightly exceeds the power of the power unit.");
        }

        if (personalComputer.Motherboard.CpuSocket != personalComputer.Cpu.CpuSocket)
        {
            return new ValidationResults.ValidationError("Motherboards' socket differs from СPU socket.");
        }

        if (personalComputer.Motherboard.Chipset.XmpProfile != personalComputer.XmpProfile)
        {
            return new ValidationResults.ValidationError("Motherboards' chipset doesn't support this XMP profile.");
        }

        if (personalComputer.RandomAccessMemories.Select(randomAccessMemory => randomAccessMemory.SupportedJedecVoltagePairs
                .Any(pair1 => personalComputer.Motherboard.Chipset.AvailableMemoryFrequencies
                    .Any(pair2 => pair1.Jedec == pair2))).Any(hasCommonElements => !hasCommonElements))
        {
            return new ValidationResults.ValidationError("No common memory frequencies between RAM and motherboard.");
        }

        if (personalComputer.Motherboard.Bios.Type != personalComputer.Bios.Type)
        {
            return new ValidationResults.ValidationError("This type of Bios not supported by motherboard.");
        }

        if (personalComputer.Motherboard.Bios.Version != personalComputer.Bios.Version)
        {
            return new ValidationResults.ValidationError("This version of Bios not supported by motherboard.");
        }

        if (personalComputer.Motherboard.RamTablesAmount < personalComputer.RandomAccessMemories.Count)
        {
            return new ValidationResults.ValidationError("Too many RAMs connected to motherboard.");
        }

        if (personalComputer.RandomAccessMemories.All(randomAccessMemory => personalComputer.Motherboard.Ddr != randomAccessMemory.Ddr))
        {
            return new ValidationResults.ValidationError("Different DDR standards between motherboard and RAM.");
        }

        if (personalComputer.Corpus.SupportedMotherboardFormFactors.All(supportedMotherboardFactor => personalComputer.Motherboard.FormFactor != supportedMotherboardFactor))
        {
            return new ValidationResults.ValidationError("Motherboards' form-factor not fits in corpus.");
        }

        if (personalComputer.VideoCarts != null)
        {
            if (personalComputer.VideoCarts.Any(videoCart => Dimensions.Сomparison(personalComputer.Corpus.MaxVideCartDimensions, videoCart.Dimensions)))
            {
                return new ValidationResults.ValidationError("Video card cannot fit into the corpus.");
            }
        }

        if (personalComputer.Motherboard.WiFiModule && personalComputer.WiFiAdapter is not null)
        {
            return new ValidationResults.ValidationError("Network equipment conflict.");
        }

        if (personalComputer.Bios.SupportedProcessors.All(supportedProcessor => personalComputer.Cpu != supportedProcessor))
        {
            return new ValidationResults.ValidationError("None of the supported CPUs are compatible with the installed CPU.");
        }

        if (!personalComputer.Cpu.VideoCore && personalComputer.VideoCarts is null)
        {
            return new ValidationResults.ValidationError("Computer cannot output the image due to the lack of a graphics core.");
        }

        if (personalComputer.Cpu.Tdp > personalComputer.CpuCoolingSystem.Tpd)
        {
            return new ValidationResults.WarrantyValidationError(
                "Amount of heat generated by the CPU exceeds the amount dissipated by the cooling system.");
        }

        if (personalComputer.RandomAccessMemories.SelectMany(randomAccessMemory => randomAccessMemory.AvailableXmpProfiles).All(xmpProfile => xmpProfile.Timings != personalComputer.XmpProfile.Timings))
        {
            return new ValidationResults.ValidationError("XMP/A-XMP Profile does not match any supported RAM XMP Profiles.");
        }

        return new ValidationResults.SuccessValidation();
    }
}