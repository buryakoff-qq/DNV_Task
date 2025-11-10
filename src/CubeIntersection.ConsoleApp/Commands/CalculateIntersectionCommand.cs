using CubeIntersection.Application.DTO_s;
using CubeIntersection.Application.Services;

namespace CubeIntersection.ConsoleApp.Commands;

public sealed class CalculateIntersectionCommand(CubeIntersectionAppService appService)
{
    public IntersectionResultDto Execute(CubeInputDto first, CubeInputDto second)
        => appService.Calculate(first, second);
}