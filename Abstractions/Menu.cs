using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi.Abstractions
{
    public abstract class Menu
    {
        private int currentUrlId = 0;
        protected int width {get; set;}
        protected int height {get; set;}
        public abstract void Draw();

        public void SwitchMapUrl(){
            currentUrlId = currentUrlId == 0 ? 1 : 0;
        }

        public async Task<Response<List<List<Block>>>> CreateMapFromUrl(){
            return await Maze.CreateMap(Constant.MapUrls[currentUrlId]);
        }

        public Response<List<List<Block>>> CreateLabyrinth(){
            return Maze.CreateMap(width, height);
        }
    }
}