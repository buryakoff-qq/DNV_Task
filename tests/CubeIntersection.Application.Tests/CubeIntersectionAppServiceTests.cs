using CubeIntersection.Application.DTO_s;
using CubeIntersection.Application.Services;
using CubeIntersection.Domain.Services;

namespace CubeIntersection.Application.Tests;

public sealed class CubeIntersectionAppServiceTests
{
    private readonly CubeIntersectionAppService _sut;

    public CubeIntersectionAppServiceTests()
    {
        var domainService = new CubeIntersectionDomainService();
        _sut = new CubeIntersectionAppService(domainService);
    }

    [Fact]
    public void ShouldReturnIntersection_WhenValidData()
    {
        var first = new CubeInputDto { SideLength = 2, X = 0, Y = 0, Z = 0 };
        var second = new CubeInputDto { SideLength = 2, X = 1, Y = 0, Z = 0 };

        var result = _sut.Calculate(first, second);

        Assert.True(result.Intersects);
        Assert.True(result.Volume > 0);
    }

    [Fact]
    public void ShouldReturnNoIntersection_WhenCubesDoNotOverlap()
    {
        var first = new CubeInputDto { SideLength = 2, X = 0, Y = 0, Z = 0 };
        var second = new CubeInputDto { SideLength = 2, X = 5, Y = 0, Z = 0 };

        var result = _sut.Calculate(first, second);

        Assert.False(result.Intersects);
        Assert.Equal(0, result.Volume);
    }

    [Fact]
    public void ShouldThrow_WhenInvalidSideLength()
    {
        var first = new CubeInputDto { SideLength = 0, X = 0, Y = 0, Z = 0 };
        var second = new CubeInputDto { SideLength = 2, X = 0, Y = 0, Z = 0 };

        Assert.Throws<ArgumentException>(() => _sut.Calculate(first, second));
    }
    [Fact]
    public void ShouldHandleCubeInsideAnother()
    {
        var first = new CubeInputDto { SideLength = 4, X = 0, Y = 0, Z = 0 };
        var second = new CubeInputDto { SideLength = 2, X = 0, Y = 0, Z = 0 };

        var result = _sut.Calculate(first, second);

        Assert.True(result.Intersects);
        Assert.Equal(8, result.Volume);
    }
}