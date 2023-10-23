namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record SsdConnectionType()
{
    public bool PcieConnection { get; set; }
    public bool SataConnection { get; set; }
}