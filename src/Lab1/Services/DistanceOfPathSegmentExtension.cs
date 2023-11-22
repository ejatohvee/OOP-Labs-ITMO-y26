using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class DistanceOfPathSegmentExtension
{
    public static int GetDistance(this DistanceOfPathSegment distance)
    {
        return distance switch
        {
            DistanceOfPathSegment.Small => 10,
            DistanceOfPathSegment.Middle => 20,
            DistanceOfPathSegment.Huge => 30,
            _ => throw new ArgumentOutOfRangeException(nameof(distance), distance, null),
        };
    }
}