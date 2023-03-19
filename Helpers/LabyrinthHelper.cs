using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;

namespace GezginRobotProjesi.Helpers
{
    public static class LabyrinthHelper
    {
        public static List<List<Block>> SetMap(Labyrinth entity) {
            List<List<Block>> map = SetBasicMap(entity.Heigth, entity.Width);
            SetBlockAsPath(map, entity.StartingPoint);
            List<Block> walls = GetSurroundingWalls(entity.Heigth, entity.Width, entity.StartingPoint);
            SetBlocksToMap(map, walls);
            CreateLabyrinth(entity.Heigth, entity.Width, map);
            SetAllUnvisitedBlockAsBasic(map);
            return map;
        }

        private static List<List<Block>> SetBasicMap(int height, int width){
            List<List<Block>> map = new List<List<Block>>();
            for(int i=0; i<height; i++){
                List<Block> row = new List<Block>();
                for(int j=0; j<width; j++){
                    Coordinate position = new Coordinate(i, j);
                    BlockType type = BlockType.Unvisited;
                    Block block = new Block(position, type, false, false);
                    row.Add(block);
                }
                map.Add(row);
            }
            return map;
        }

        private static void SetBlockAsPath(List<List<Block>> map, Coordinate position){
            map[position.X][position.Y].Type = BlockType.Path;
            map[position.X][position.Y].IsMoveble = true;
        }

        private static List<Block> GetSurroundingWalls(int height, int width, Coordinate position){
            List<Block> walls = new List<Block>();
            if(position.X != 0){
                walls.Add(new Block(new Coordinate(position.X - 1, position.Y), BlockType.Basic, false, false));
            }
            if(position.X != height - 1){
                walls.Add(new Block(new Coordinate(position.X + 1, position.Y), BlockType.Basic, false, false));
            }
            if(position.Y != 0){
                walls.Add(new Block(new Coordinate(position.X, position.Y - 1), BlockType.Basic, false, false));
            }
            if(position.Y != width - 1){
                walls.Add(new Block(new Coordinate(position.X, position.Y + 1), BlockType.Basic, false, false));
            }
            return walls;
        }

        private static void SetBlocksToMap(List<List<Block>> map, List<Block> blocks){
            int blockLen = blocks.Count;
            for(int i=0; i<blockLen; i++){
                Block block = blocks[i];
                Coordinate position = block.Position;
                map[position.X][position.Y] = block;
            }
        }

        private static void CreateLabyrinth(int height, int width, List<List<Block>> map){
            Random r = new Random();
            List<Block> walls = MazeHelper.GetObstacles(map, BlockType.Unvisited).Where(x => x.Type == BlockType.Basic).ToList();
            while(walls.Any()){
                Block randomWall = walls[r.Next(0, walls.Count)];
                if(randomWall.Position.Y != 0){
                    if(map[randomWall.Position.X][randomWall.Position.Y - 1].Type == BlockType.Unvisited && map[randomWall.Position.X][randomWall.Position.Y + 1].Type == BlockType.Path){
                        int surroundingPaths = CountSurroundingPaths(map, randomWall.Position);
                        if(surroundingPaths < 2){
                            SetBlockAsPath(map, randomWall.Position);
                            List<Block> newWalls = GetSurroundingWalls(height, width, randomWall.Position);
                            walls.AddIfNotExists<Block>(newWalls);
                        }
                        walls.Remove(randomWall);
                        continue;
                    }
                }
                if(randomWall.Position.X != 0){
                    if(map[randomWall.Position.X - 1][randomWall.Position.Y].Type == BlockType.Unvisited && map[randomWall.Position.X + 1][randomWall.Position.Y].Type == BlockType.Path){
                        int surroundingPaths = CountSurroundingPaths(map, randomWall.Position);
                        if(surroundingPaths < 2){
                            SetBlockAsPath(map, randomWall.Position);
                            List<Block> newWalls = GetSurroundingWalls(height, width, randomWall.Position);
                            walls.AddIfNotExists<Block>(newWalls);
                        }
                        walls.Remove(randomWall);
                        continue;
                    }
                }
                if(randomWall.Position.X != height - 1){
                    if(map[randomWall.Position.X + 1][randomWall.Position.Y].Type == BlockType.Unvisited && map[randomWall.Position.X - 1][randomWall.Position.Y].Type == BlockType.Path){
                        int surroundingPaths = CountSurroundingPaths(map, randomWall.Position);
                        if(surroundingPaths < 2){
                            SetBlockAsPath(map, randomWall.Position);
                            List<Block> newWalls = GetSurroundingWalls(height, width, randomWall.Position);
                            walls.AddIfNotExists<Block>(newWalls);
                        }
                        walls.Remove(randomWall);
                        continue;
                    }
                }
                if(randomWall.Position.Y != width - 1){
                    if(map[randomWall.Position.X][randomWall.Position.Y + 1].Type == BlockType.Unvisited && map[randomWall.Position.X][randomWall.Position.Y - 1].Type == BlockType.Path){
                        int surroundingPaths = CountSurroundingPaths(map, randomWall.Position);
                        if(surroundingPaths < 2){
                            SetBlockAsPath(map, randomWall.Position);
                            List<Block> newWalls = GetSurroundingWalls(height, width, randomWall.Position);
                            walls.AddIfNotExists<Block>(newWalls);
                        }
                        walls.Remove(randomWall);
                        continue;
                    }
                }
                walls.Remove(randomWall);
            }
        }

        private static int CountSurroundingPaths(List<List<Block>> map, Coordinate position){
            int paths = 0;
            if(map[position.X - 1][position.Y].Type == BlockType.Path){
                paths++;
            }
            if(map[position.X + 1][position.Y].Type == BlockType.Path){
                paths++;
            }
            if(map[position.X][position.Y - 1].Type == BlockType.Path){
                paths++;
            }
            if(map[position.X][position.Y + 1].Type == BlockType.Path){
                paths++;
            }
            return paths;
        }

        private static void SetAllUnvisitedBlockAsBasic(List<List<Block>> map){
            foreach(List<Block> blocks in map){
                foreach(Block unvisited in blocks.Where(x => x.Type == BlockType.Unvisited)){
                    map[unvisited.Position.X][unvisited.Position.Y].Type = BlockType.Basic;
                }
            }
        }

    }
}