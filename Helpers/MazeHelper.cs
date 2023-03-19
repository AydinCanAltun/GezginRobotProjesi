using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prolab21.Entity;
using prolab21.Entity.Enums;

namespace prolab21.Helpers
{
    public static class MazeHelper
    {
        public static List<List<Block>> SetMap(string mapAsString){
            List<List<Block>> map = new List<List<Block>>();
            string[] mapLines = mapAsString.Split('\n');
            int mapHeight = mapLines.Length;
            for(int i=0; i<mapHeight; i++){
                char[] mapDepth = mapLines[i].ToCharArray();
                int mapWidth = mapDepth.Length;
                List<Block> column = new List<Block>();
                for(int j=0; j<mapWidth; j++){
                    Coordinate position = new Coordinate(i, j);
                    BlockType type = GetBlockType(mapDepth[j]);
                    Block block = new Block(position, type, type == BlockType.Path, false);
                    column.Add(block);
                }
                map.Add(column);
            }
            return RandomizeObstacle(map);
        }

        private static BlockType GetBlockType(char c){
            if(c == '0'){
                return BlockType.Path;
            }
            if(c == '1'){
                return BlockType.Basic;
            }
            if(c == '2'){
                return BlockType.Intermediary;
            }
            if(c == '3'){
                return BlockType.Advanced;
            }
            return BlockType.Path;
        }

        private static List<List<Block>> RandomizeObstacle(List<List<Block>> map){
            List<Block> obstacles = GetObstacles(map);
            List<Coordinate> visited = new List<Coordinate>();
            int obstacleLen = obstacles.Count;
            for(int i=0; i<obstacleLen; i++) {
                if(visited.Any(v => v.X == obstacles[i].Position.X && v.Y == obstacles[i].Position.Y)){
                    continue;
                }
                Random r = new Random();
                int movebleBlockCount = r.Next(1, 4);
                
                List<Coordinate> gonnaBeVisited = GetObstacleGroup(obstacles[i]);
                visited.AddRange(gonnaBeVisited);
                List<Coordinate> turnToMoveble = gonnaBeVisited.OrderBy(x => r.Next()).Take(movebleBlockCount).ToList();
                for(int j=0; j<movebleBlockCount; j++){
                    map[turnToMoveble[j].X][turnToMoveble[j].Y].IsMoveble = true;
                }
            }
            return map;
        }

        private static List<Coordinate> GetObstacleGroup(Block currentBlock){
            List<Coordinate> result = new List<Coordinate>();
            int currentX = currentBlock.Position.X;
            int currentY = currentBlock.Position.Y;
            int maxX = 0;
            int maxY = 0;
            if(currentBlock.Type == BlockType.Advanced){
                maxX = currentX + 3;
                maxY = currentY + 3;
            }
            if(currentBlock.Type == BlockType.Intermediary){
                maxX = currentX + 2;
                maxY = currentY + 2;
            }
            List<Block> obstacleGroup = new List<Block>();
            for(int x = currentX; x < maxX; x++) {
                for(int y = currentY; y < maxY; y++) {
                    result.Add(new Coordinate(x, y));
                }
            }
            return result;
        }

        private static List<Block> GetObstacles(List<List<Block>> map) {
            List<Block> obstacles = new List<Block>();
            int mapHeight = map.Count;
            for(int i=0; i<mapHeight; i++) {
                List<Block> obstacleColumn = map[i].Where(x => x.IsMoveble == false && x.Type != BlockType.Basic).ToList();
                obstacles.AddRange(obstacleColumn);
            }
            return obstacles;
        }
    }
}