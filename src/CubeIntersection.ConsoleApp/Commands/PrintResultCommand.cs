using CubeIntersection.Application.DTO_s;

namespace CubeIntersection.ConsoleApp.Commands;

public sealed class PrintResultCommand
{
    public void Execute(IntersectionResultDto result)
    {
        Console.WriteLine($"\nIntersect: {result.Intersects}");
        Console.WriteLine($"Volume: {result.Volume:F2}");
    }
}