namespace CubeIntersection.Domain.Entities;

public sealed class Position(double x, double y, double z)
{
    public double X { get; } = x;
    public double Y { get; } = y;
    public double Z { get; } = z;
}