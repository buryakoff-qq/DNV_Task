using CubeIntersection.Domain.Entities;
using CubeIntersection.Domain.Services.Interfaces;
using CubeIntersection.Domain.ValueObjects;

namespace CubeIntersection.Domain.Services;

public sealed class CubeIntersectionDomainService : ICubeIntersectionService
{
    public IntersectionResult CalculateIntersection(Cube a, Cube b)
    {
        var overlapX = Overlap(a.RangeX(), b.RangeX());
        var overlapY = Overlap(a.RangeY(), b.RangeY());
        var overlapZ = Overlap(a.RangeZ(), b.RangeZ());

        var intersects = overlapX > 0 && overlapY > 0 && overlapZ > 0;
        var volume = intersects ? overlapX * overlapY * overlapZ : 0;

        return new IntersectionResult(intersects, volume);
    }

    private static double Overlap((double Min, double Max) rangeA, (double Min, double Max) rangeB)
    {
        var start = Math.Max(rangeA.Min, rangeB.Min);
        var end = Math.Min(rangeA.Max, rangeB.Max);
        var overlap = end - start;               

        return overlap > 0 ? overlap : 0;
    }

}