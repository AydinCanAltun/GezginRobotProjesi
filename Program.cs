using GezginRobotProjesi;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;
Console.WriteLine("URL 1 MAP");
Response<List<List<Block>>> map = await Maze.CreateMap(Constant.MapUrls[0]);
if(map.IsSuccess){
    int height = map.Result.Count;
    for(int i=0; i<height; i++){
        int width = map.Result[i].Count;
        for(int j=0; j<width; j++){
            char c;
            if(map.Result[i][j].IsMoveble){
                c = map.Result[i][j].Type == BlockType.Path ? 'c' : 'a';
            }else{
                c = 'w';
            }
            Console.Write(string.Format("{0} ", c));
        }
        Console.Write('\n');
    }
}else{
    Console.WriteLine(map.ErrorMessage);
}

Console.WriteLine("---------------");
Console.WriteLine("URL 2 MAP");
Response<List<List<Block>>> map2 = await Maze.CreateMap(Constant.MapUrls[0]);
if(map2.IsSuccess){
    int height = map2.Result.Count;
    for(int i=0; i<height; i++){
        int width = map2.Result[i].Count;
        for(int j=0; j<width; j++){
            char c;
            if(map.Result[i][j].IsMoveble){
                c = map2.Result[i][j].Type == BlockType.Path ? 'c' : 'a';
            }else{
                c = 'w';
            }
            Console.Write(string.Format("{0} ", c));
        }
        Console.Write('\n');
    }
}else{
    Console.WriteLine(map2.ErrorMessage);
}