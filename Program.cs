using GezginRobotProjesi;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Implementations.Map;
using GezginRobotProjesi.Implementations.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new ServiceCollection()
    .AddSingleton<GameMap, ConsoleMap>()
    .AddTransient<GameMenu, ConsoleMenu>()
    .BuildServiceProvider();


Application game = new Application(builder);

game.GameLoop().Wait();




