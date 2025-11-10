namespace CubeIntersection.Domain.Entities;

public sealed class Cube
{
    private double SideLength { get; }
    private Position Center { get; }

    public Cube(double sideLength, Position center)
    {
        if (sideLength <= 0)
            throw new ArgumentException("Side length must be positive.");

        SideLength = sideLength;
        Center = center;
    }

    private double Half => SideLength / 2.0;

    public (double Min, double Max) RangeX() => (Center.X - Half, Center.X + Half);
    public (double Min, double Max) RangeY() => (Center.Y - Half, Center.Y + Half);
    public (double Min, double Max) RangeZ() => (Center.Z - Half, Center.Z + Half);
}