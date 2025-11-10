using CubeIntersection.Application.DTO_s;

namespace CubeIntersection.ConsoleApp.Commands;

public sealed class ReadCubeCommand
{
    public CubeInputDto Execute(string label)
    {
        Console.WriteLine($"Enter {label} cube:");

        Console.Write("  Side length: ");
        var side = double.Parse(Console.ReadLine()!);

        Console.Write("  Center X: ");
        var x = double.Parse(Console.ReadLine()!);

        Console.Write("  Center Y: ");
        var y = double.Parse(Console.ReadLine()!);

        Console.Write("  Center Z: ");
        var z = double.Parse(Console.ReadLine()!);

        return new CubeInputDto { SideLength = side, X = x, Y = y, Z = z };
    }
}