using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Motherboard
{
    public Motherboard(string cpuSocket, double pcieLinesAmount, double sataPortsAmount, Chipset chipset, string ddr, double ramTablesAmount, string formFactor, Bios bios, bool wiFiModule)
    {
        CpuSocket = cpuSocket;
        PcieLinesAmount = pcieLinesAmount;
        SataPortsAmount = sataPortsAmount;
        Chipset = chipset;
        Ddr = ddr;
        RamTablesAmount = ramTablesAmount;
        FormFactor = formFactor;
        Bios = bios;
        WiFiModule = wiFiModule;
    }

    public string CpuSocket { get; set; }
    public double PcieLinesAmount { get; set; }
    public double SataPortsAmount { get; set; }
    public Chipset Chipset { get; set; }
    public string Ddr { get; set; }
    public double RamTablesAmount { get; set; }
    public string FormFactor { get; set; }
    public Bios Bios { get; set; }
    public bool WiFiModule { get; set; }

    public IMotherboardBuilder Direct(IMotherboardBuilder motherboardBuilder)
    {
        if (motherboardBuilder is null) throw new ArgumentNullException(nameof(motherboardBuilder));

        return motherboardBuilder.WithDdrStandard(Ddr).WithFormFactor(FormFactor).WithChipset(Chipset).WithBios(Bios)
            .WithSocket(CpuSocket).WithPcieLinesAmount(PcieLinesAmount).WithSataPortsAmount(SataPortsAmount)
            .WithRamTablesAmount(RamTablesAmount).WithWiFiModule(WiFiModule);
    }
}