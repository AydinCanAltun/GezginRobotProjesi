using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Implementations.Map;
using Microsoft.Extensions.DependencyInjection;

namespace GezginRobotProjesi.Abstractions
{
    public abstract class GameMenu
    {
        private ServiceProvider _serviceProvider;
        protected int takenAction  {get; set;}
        protected int currentUrlId {get; set;}
        public abstract void Draw();
        protected abstract void TakeAction();
        public abstract Response<MapSize> AskMapSize();
        public abstract void ShowError(string errorMessage);
        private Maze _maze;

        public GameMenu(){
            takenAction = -1;
            currentUrlId = 0;
            _maze = new Maze();
        }

        protected void SetTakenAction(int action){
            takenAction = action;
        }

        public int GetTakenAction(){
            return takenAction;
        }

        public void SwitchMapUrl(){
            currentUrlId = currentUrlId == 0 ? 1 : 0;
        }

        public void SetServiceProvider(ServiceProvider serviceProvider){
            _serviceProvider = serviceProvider;
        }
        

        public async Task<Response<GameMap>> CreateMapFromUrl(){
            Response<GameMap> gameMap = new Response<GameMap>();
            try
            {
                Response<List<List<Block>>> map = await _maze.CreateMap(Constant.MapUrls[currentUrlId]);
                gameMap.IsSuccess = map.IsSuccess;
                if (map.IsSuccess)
                {
                    gameMap.Result = _serviceProvider.GetRequiredService<GameMap>();
                    gameMap.Result.SetGameMap(map.Result);
                }
                gameMap.ErrorMessage = gameMap.IsSuccess ? string.Empty : map.ErrorMessage;
            }catch(Exception ex)
            {
                gameMap.IsSuccess = false;
                gameMap.ErrorMessage = string.Format("Beklenmeyen bir hata oluştu! Hata mesajı: {0}", ex.Message);
            }
            
            return gameMap;
        }
        
        public Response<GameMap> CreateLabyrinth(int height, int width){
            Response<GameMap> gameMap = new Response<GameMap>();
            Response<List<List<Block>>> map = _maze.CreateMap(height, width);
            gameMap.IsSuccess = map.IsSuccess;
            if(gameMap.IsSuccess){
                gameMap.Result = _serviceProvider.GetRequiredService<GameMap>();
                gameMap.Result.SetGameMap(map.Result);
            }
            gameMap.ErrorMessage = gameMap.IsSuccess ? string.Empty : map.ErrorMessage;
            return gameMap;
        }
    }
}