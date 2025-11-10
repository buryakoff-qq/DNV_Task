using CubeIntersection.Application.DTO_s;
using CubeIntersection.Domain.Entities;
using CubeIntersection.Domain.Services.Interfaces;

namespace CubeIntersection.Application.Services;


public sealed class CubeIntersectionAppService(ICubeIntersectionService domainService)
{
    public IntersectionResultDto Calculate(CubeInputDto first, CubeInputDto second)
    {
        var cubeA = new Cube(first.SideLength, new Position(first.X, first.Y, first.Z));
        var cubeB = new Cube(second.SideLength, new Position(second.X, second.Y, second.Z));

        var result = domainService.CalculateIntersection(cubeA, cubeB);

        return new IntersectionResultDto
        {
            Intersects = result.Intersects,
            Volume = result.Volume
        };
    }
}