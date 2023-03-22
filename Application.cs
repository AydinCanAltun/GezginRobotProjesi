using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace GezginRobotProjesi
{
    public class Application
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly GameMenu _menu;
        List<Coordinate> Visited {get; set;}
        public GameMap Map {get; set;}
        private readonly Maze _maze;

        public Application(ServiceProvider serviceProvider){
            Console.TreatControlCAsInput = true;
            _serviceProvider = serviceProvider;
            _menu = _serviceProvider.GetRequiredService<GameMenu>();
            _menu.SetServiceProvider(_serviceProvider);
            Visited = new List<Coordinate>();
            _maze = new Maze();
        }

        public async Task GameLoop(){
            while (true) {
                _menu.Draw();
                if(_menu.GetTakenAction() == 0){
                    Console.WriteLine("Bay bay");
                    break;
                }
                if(_menu.GetTakenAction() == 1){
                    Response<GameMap> gameMap = await _menu.CreateMapFromUrl();
                    StartGame(gameMap);
                }
                if(_menu.GetTakenAction() == 2){
                    Response<MapSize> mapSize = _menu.AskMapSize();
                    if(mapSize.IsSuccess){
                        Response<GameMap> gameMap = _menu.CreateLabyrinth(mapSize.Result.Height, mapSize.Result.Width);
                        StartGame(gameMap);
                    }
                }

                if(_menu.GetTakenAction() == 3){
                    _menu.SwitchMapUrl();
                }
            }
        }

        public void StartGame(Response<GameMap> gameMap){
            if(gameMap.IsSuccess){
                this.Map = gameMap.Result;
                gameMap.Result.Draw();
            }else{
                _menu.ShowError(gameMap.ErrorMessage);
            }
        }

    }
}