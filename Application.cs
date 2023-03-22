using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi
{
    public class Application
    {
        private readonly Menu _menu;
        List<Coordinate> Visited {get; set;}
        public GameMap Map {get; set;}

        public Application(Menu menu){
            Console.TreatControlCAsInput = true;
            _menu = menu;
            Visited = new List<Coordinate>();
        }

        public async void GameLoop(){
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