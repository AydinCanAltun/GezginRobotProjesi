using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi.Abstractions
{
    public abstract class Menu
    {
        protected int takenAction  {get; set;}
        protected int currentUrlId {get; set;}
        public abstract void Draw();
        protected abstract void TakeAction();
        public abstract Response<MapSize> AskMapSize();
        public abstract void ShowError(string errorMessage);

        public Menu(){
            takenAction = -1;
            currentUrlId = 0;
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

        

        public async Task<Response<GameMap>> CreateMapFromUrl(){
            Response<GameMap> gameMap = new Response<GameMap>();
            try
            {
                Response<List<List<Block>>> map = await Maze.CreateMap(Constant.MapUrls[currentUrlId]);
                gameMap.IsSuccess = map.IsSuccess;
                if (map.IsSuccess)
                {
                    gameMap.Result = new ConsoleMap(map.Result);
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
            Response<List<List<Block>>> map = Maze.CreateMap(height, width);
            gameMap.IsSuccess = map.IsSuccess;
            if(gameMap.IsSuccess){
                gameMap.Result = new ConsoleMap(map.Result);
            }
            gameMap.ErrorMessage = gameMap.IsSuccess ? string.Empty : map.ErrorMessage;
            return gameMap;
        }
    }
}