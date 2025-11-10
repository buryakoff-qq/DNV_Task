using CubeIntersection.Domain.Entities;
using CubeIntersection.Domain.ValueObjects;

namespace CubeIntersection.Domain.Services.Interfaces;

public interface ICubeIntersectionService
{
    IntersectionResult CalculateIntersection(Cube firstCube, Cube secondCube);
}