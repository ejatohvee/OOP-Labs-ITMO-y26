using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record ImportanceLevels
{
    public ImportanceLevels(int level)
    {
        if (level <= 0)
        {
            throw new ArgumentException("Importance level value can't be negative.");
        }

        Level = level;
    }

    public int Level { get; set; }
}