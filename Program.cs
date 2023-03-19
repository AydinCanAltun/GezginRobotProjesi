using GezginRobotProjesi;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;
using GezginRobotProjesi.Helpers;

Console.WriteLine("URL 1 MAP");
Response<List<List<Block>>> map = await Maze.CreateMap(Constant.MapUrls[0]);
if(map.IsSuccess){
    MazeHelper.PrintMaze(map.Result);
}else{
    Console.WriteLine(map.ErrorMessage);
}

Console.WriteLine("---------------");
Console.WriteLine("URL 2 MAP");
Response<List<List<Block>>> map2 = await Maze.CreateMap(Constant.MapUrls[0]);
if(map2.IsSuccess){
    MazeHelper.PrintMaze(map2.Result);
}else{
    Console.WriteLine(map2.ErrorMessage);
}

Console.WriteLine("---------------");
Console.WriteLine("Labirent Başlangıç MAP");
Labyrinth entity = new Labyrinth(27,33);
Console.WriteLine("Başlangıç Noktası: ({0},{1}), Bitiş Noktası: ({2},{3})", entity.StartingPoint.X, entity.StartingPoint.Y, entity.EndingPoint.X, entity.EndingPoint.Y);
Response<List<List<Block>>> labyrnth = Maze.CreateMap(entity);
if(labyrnth.IsSuccess){
    MazeHelper.PrintMaze(labyrnth.Result);
}else{
    Console.WriteLine(labyrnth.ErrorMessage);
}

