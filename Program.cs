using GezginRobotProjesi;
using GezginRobotProjesi.Entity;

Console.WriteLine("Test");

Response<List<List<Block>>> map = Maze.CreateMap(27, 33);
if(map.IsSuccess){
    ConsoleMap consoleMap = new ConsoleMap(map.Result);
    consoleMap.Draw();
}else{
    Console.WriteLine(map.ErrorMessage);
}


Response<List<List<Block>>> map2 = await Maze.CreateMap(Constant.MapUrls[0]);
if(map.IsSuccess){
    ConsoleMap consoleMap = new ConsoleMap(map2.Result);
    consoleMap.Draw();
}else{
    Console.WriteLine(map.ErrorMessage);
}

