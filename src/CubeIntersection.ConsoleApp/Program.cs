using CubeIntersection.Application.Services;
using CubeIntersection.ConsoleApp.Commands;
using CubeIntersection.Domain.Services;


var domainService = new CubeIntersectionDomainService();
var appService = new CubeIntersectionAppService(domainService);

var readCube = new ReadCubeCommand();
var calculate = new CalculateIntersectionCommand(appService);
var print = new PrintResultCommand();

var first = readCube.Execute("first");
var second = readCube.Execute("second");
var result = calculate.Execute(first, second);

print.Execute(result);