using prolab21;
using prolab21.Entity;
using prolab21.Entity.Enums;

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
