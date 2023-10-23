using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PersonalComputerAssemblingTests
{
    [Fact]
    public void AssemblingWithCompatiblAaccessoriesBuildPersonalComputerSuccessfulResult()
    {
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen9 = new Cpu("AMD Ryzen 9 5900X", 3.7, 12, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI9 = new Cpu("Intel Core i9-10900K", 3.7, 10, "LGA 1200", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, 125, 250);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI9, amdRyzen9 });
        var asusPrimeZ490A = new Motherboard("LGA 1200", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var kingstonHyperXFuryDdr43200 = new RandomAccessMemory(
            32.0,
            new List<JedecVoltagePair>
            {
                new JedecVoltagePair(2666, 1.2),
                new JedecVoltagePair(3200, 1.35),
            },
            new List<XmpProfile>
            {
                new XmpProfile("16", 16, 3200),
                new XmpProfile("18", 18, 2666),
            },
            "DIMM",
            "DDR4",
            1.2);
        var samsung970EvoNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3080 = new VideoCart(new Dimensions(11.2, 4.4), 10.0, "PCIe 4.0", 1710, 320.0);
        var corsairRM850x850 = new PowerUnit(850);
        var cpuCoolingSystem = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510AtxMidTower = new Corpus(new Dimensions(37.5, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(46.7, 42.4));
        var repository = new Repository();
        repository.Motherboards.Add(asusPrimeZ490A);
        repository.Cpus.Add(intelCoreI9);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(cpuCoolingSystem);
        repository.RandomAccessMemories.Add(kingstonHyperXFuryDdr43200);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3080);
        repository.Ssds.Add(samsung970EvoNVMe);
        repository.Corpuses.Add(nzxtH510AtxMidTower);
        repository.PowerUnits.Add(corsairRM850x850);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510AtxMidTower)).WithPowerUnit(repository.PowerUnits.FirstOrDefault(corsairRM850x850))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile)).WithCpu(repository.Cpus.FirstOrDefault(intelCoreI9)).AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoNVMe)).WithMotherboard(repository.Motherboards.FirstOrDefault(asusPrimeZ490A))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault()).AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(kingstonHyperXFuryDdr43200)).WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(cpuCoolingSystem));

        PersonalComputerBuildResult result = personalComputerBuilder.Build();

        Assert.IsType<PersonalComputerBuildResult.Success>(result);
    }

    [Fact]
    public void AssemblingWithHigherPowerConsumingBuildPersonalComputerSuccessWithGuaranteeWarning()
    {
        int newPowerConsumptionForVideoCart = 540;
        int newPowerConsumptionForCpu = 350;
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen9 = new Cpu("AMD Ryzen 9 5900X", 3.7, 12, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI9 = new Cpu("Intel Core i9-10900K", 3.7, 10, "LGA 1200", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, 125, newPowerConsumptionForCpu);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI9, amdRyzen9 });
        var asusPrimeZ490A = new Motherboard("LGA 1200", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var kingstonHyperXFuryDdr43200 = new RandomAccessMemory(
            32.0,
            new List<JedecVoltagePair>
            {
                new JedecVoltagePair(2666, 1.2),
                new JedecVoltagePair(3200, 1.35),
            },
            new List<XmpProfile>
            {
                new XmpProfile("16", 16, 3200),
                new XmpProfile("18", 18, 2666),
            },
            "DIMM",
            "DDR4",
            1.2);
        var samsung970EvoNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3080 = new VideoCart(new Dimensions(11.2, 4.4), 10.0, "PCIe 4.0", 1710, newPowerConsumptionForVideoCart);
        var corsairRM850x850 = new PowerUnit(850);
        var cpuCoolingSystem = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510AtxMidTower = new Corpus(new Dimensions(37.5, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(46.7, 42.4));
        var repository = new Repository();
        repository.Motherboards.Add(asusPrimeZ490A);
        repository.Cpus.Add(intelCoreI9);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(cpuCoolingSystem);
        repository.RandomAccessMemories.Add(kingstonHyperXFuryDdr43200);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3080);
        repository.Ssds.Add(samsung970EvoNVMe);
        repository.Corpuses.Add(nzxtH510AtxMidTower);
        repository.PowerUnits.Add(corsairRM850x850);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510AtxMidTower)).WithPowerUnit(repository.PowerUnits.FirstOrDefault(corsairRM850x850))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile)).WithCpu(repository.Cpus.FirstOrDefault(intelCoreI9)).AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoNVMe)).WithMotherboard(repository.Motherboards.FirstOrDefault(asusPrimeZ490A))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault()).AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(kingstonHyperXFuryDdr43200)).WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(cpuCoolingSystem));

        PersonalComputerBuildResult result = personalComputerBuilder.Build();

        Assert.IsType<PersonalComputerBuildResult.SuccessWithWarrantyDisclaimer>(result);
    }

    [Fact]
    public void AssemblingWithHigherHeatGeneratingBuildPersonalComputerSuccessWithGuaranteeWarning()
    {
        int newCpuHeatGeneration = 170;
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen9 = new Cpu("AMD Ryzen 9 5900X", 3.7, 12, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI9 = new Cpu("Intel Core i9-10900K", 3.7, 10, "LGA 1200", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, newCpuHeatGeneration, 250);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI9, amdRyzen9 });
        var asusPrimeZ490A = new Motherboard("LGA 1200", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var kingstonHyperXFuryDdr43200 = new RandomAccessMemory(
            32.0,
            new List<JedecVoltagePair>
            {
                new JedecVoltagePair(2666, 1.2),
                new JedecVoltagePair(3200, 1.35),
            },
            new List<XmpProfile>
            {
                new XmpProfile("16", 16, 3200),
                new XmpProfile("18", 18, 2666),
            },
            "DIMM",
            "DDR4",
            1.2);
        var samsung970EvoNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3080 = new VideoCart(new Dimensions(11.2, 4.4), 10.0, "PCIe 4.0", 1710, 320.0);
        var corsairRM850x850 = new PowerUnit(850);
        var cpuCoolingSystem = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510AtxMidTower = new Corpus(new Dimensions(37.5, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(46.7, 42.4));
        var repository = new Repository();
        repository.Motherboards.Add(asusPrimeZ490A);
        repository.Cpus.Add(intelCoreI9);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(cpuCoolingSystem);
        repository.RandomAccessMemories.Add(kingstonHyperXFuryDdr43200);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3080);
        repository.Ssds.Add(samsung970EvoNVMe);
        repository.Corpuses.Add(nzxtH510AtxMidTower);
        repository.PowerUnits.Add(corsairRM850x850);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510AtxMidTower)).WithPowerUnit(repository.PowerUnits.FirstOrDefault(corsairRM850x850))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile)).WithCpu(repository.Cpus.FirstOrDefault(intelCoreI9)).AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoNVMe)).WithMotherboard(repository.Motherboards.FirstOrDefault(asusPrimeZ490A))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault()).AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(kingstonHyperXFuryDdr43200)).WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(cpuCoolingSystem));

        PersonalComputerBuildResult result = personalComputerBuilder.Build();

        Assert.IsType<PersonalComputerBuildResult.SuccessWithWarrantyDisclaimer>(result);
    }

    [Fact]
    public void AssemblingWithInappropriateCpuGBuildPersonalComputerСomponentsDontFitEachOtherWithMessage()
    {
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen9 = new Cpu("AMD Ryzen 9 5900X", 3.7, 12, "AM4", false, new List<double> { 3200, 2933, 3800, 4000, 4400 }, 105, 105);
        var intelCorei510400 = new Cpu("Intel Core i5-10400", 2.9, 6, "LGA 1151", true, new List<double> { 2666, 2400 }, 65, 85);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCorei510400, amdRyzen9 });
        var asusPrimeZ490A = new Motherboard("LGA 1200", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var kingstonHyperXFuryDdr43200 = new RandomAccessMemory(
            32.0,
            new List<JedecVoltagePair>
            {
                new JedecVoltagePair(2666, 1.2),
                new JedecVoltagePair(3200, 1.35),
            },
            new List<XmpProfile>
            {
                new XmpProfile("16", 16, 3200),
                new XmpProfile("18", 18, 2666),
            },
            "DIMM",
            "DDR4",
            1.2);
        var samsung970EvoNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3080 = new VideoCart(new Dimensions(11.2, 4.4), 10.0, "PCIe 4.0", 1710, 320.0);
        var corsairRM850x850 = new PowerUnit(850);
        var cpuCoolingSystem = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510AtxMidTower = new Corpus(new Dimensions(37.5, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(46.7, 42.4));
        var repository = new Repository();
        repository.Motherboards.Add(asusPrimeZ490A);
        repository.Cpus.Add(intelCorei510400);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(cpuCoolingSystem);
        repository.RandomAccessMemories.Add(kingstonHyperXFuryDdr43200);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3080);
        repository.Ssds.Add(samsung970EvoNVMe);
        repository.Corpuses.Add(nzxtH510AtxMidTower);
        repository.PowerUnits.Add(corsairRM850x850);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510AtxMidTower)).WithPowerUnit(repository.PowerUnits.FirstOrDefault(corsairRM850x850))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile)).WithCpu(repository.Cpus.FirstOrDefault(intelCorei510400)).AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoNVMe)).WithMotherboard(repository.Motherboards.FirstOrDefault(asusPrimeZ490A))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault()).AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(kingstonHyperXFuryDdr43200)).WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(cpuCoolingSystem));

        PersonalComputerBuildResult result = personalComputerBuilder.Build();
        string factMessage = result.Comment;
        string expectedMessage = "Motherboards' socket differs from СPU socket.";

        Assert.Equal(expectedMessage, factMessage);
    }
}