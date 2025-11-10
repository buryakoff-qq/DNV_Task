namespace CubeIntersection.Domain.ValueObjects;


public sealed class IntersectionResult(bool intersects, double volume)
{
    public bool Intersects { get; } = intersects;
    public double Volume { get; } = volume;

    public override string ToString() =>
        Intersects ? $"Intersection volume: {Volume:F2}" : "No intersection";
}