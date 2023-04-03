using GezginRobotProjesi;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Implementations.Factory;
using GezginRobotProjesi.Implementations.Menu;
using GezginRobotProjesi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using prolab21.Abstractions;
using prolab21.Implementations.ActionHandler;

var builder = new ServiceCollection()
    .AddSingleton<IPlayerRobotFactory, PlayerRobotFactory>()
    .AddSingleton<IGameMapFactory, GameMapFactory>()
    .AddSingleton<GameMenu, ConsoleMenu>()
    .AddSingleton<PlayerActionHandler, ConsolePlayerActionHandler>()
    .BuildServiceProvider();

Application game = new Application(builder);

game.GameLoop().Wait();




