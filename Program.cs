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
Console.WriteLine("Labirent MAP");
Response<List<List<Block>>> map3 = Maze.CreateMap(27, 33);
if(map.IsSuccess){
    MazeHelper.PrintMaze(map3.Result);
}else{
    Console.WriteLine(map3.ErrorMessage);
}


