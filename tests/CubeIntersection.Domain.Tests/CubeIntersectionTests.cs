using CubeIntersection.Domain.Entities;
using CubeIntersection.Domain.Services;

namespace CubeIntersection.Tests;

public class CubeIntersectionTests
{
   [Fact]
   public void ShouldNotIntersect()
   {
      var service = new CubeIntersectionDomainService();

      var cubeA = new Cube(2, new Position(0, 0, 0));
      var cubeB = new Cube(2, new Position(5, 0, 0));

      var result = service.CalculateIntersection(cubeA, cubeB);

      Assert.False(result.Intersects);
      Assert.Equal(0, result.Volume);
   }
   
   [Fact]
   public void ShouldTouchOnly()
   {
      var service = new CubeIntersectionDomainService();

      var cubeA = new Cube(2, new Position(0, 0, 0));
      var cubeB = new Cube(2, new Position(2, 0, 0));

      var result = service.CalculateIntersection(cubeA, cubeB);

      Assert.False(result.Intersects);
      Assert.Equal(0, result.Volume);
   }
   [Fact]
   public void ShouldIntersect()
   {
      var service = new CubeIntersectionDomainService();

      var cubeA = new Cube(2, new Position(0, 0, 0));
      var cubeB = new Cube(2, new Position(1, 0, 0));

      var result = service.CalculateIntersection(cubeA, cubeB);

      Assert.True(result.Intersects);
      Assert.Equal(4, result.Volume);
   }

   [Fact]
   public void ShouldBeFullyInside()
   {
      var service = new CubeIntersectionDomainService();

      var cubeA = new Cube(4, new Position(0, 0, 0));
      var cubeB = new Cube(2, new Position(0, 0, 0));

      var result = service.CalculateIntersection(cubeA, cubeB);

      Assert.True(result.Intersects);
      Assert.Equal(8, result.Volume);
   }
   
}