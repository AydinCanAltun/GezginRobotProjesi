using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;
using GezginRobotProjesi.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GezginRobotProjesi.Abstractions
{
    public abstract class GameMap
    {
        public List<List<Block>> Playground {get; set;}
        public Coordinate StartingPosition {get; set;}
        public Coordinate EndingPosition {get; set;}

        public GameMap(List<List<Block>> map){
            this.Playground = map;
            this.StartingPosition = new Coordinate(0, 0);
            this.EndingPosition = new Coordinate(0, 0);
            int height = map.Count;
            int width = height > 0 ? map[0].Count : 0;
            for(int i=0; i<width; i++){
                if(map[1][i].Type == BlockType.Path){
                    this.StartingPosition = new Coordinate(0, i);
                    LabyrinthHelper.SetBlockAsPath(map, this.StartingPosition);
                    break;
                }
            }
            for(int j=width-1; j>-1; j--){
                if(map[height-2][j].Type == BlockType.Path){
                    this.EndingPosition = new Coordinate(height-1, j);
                    LabyrinthHelper.SetBlockAsPath(map, this.EndingPosition);
                    break;
                }
            }
        }

        public abstract void Draw(List<Coordinate> visited, Coordinate robotPosition);

        public bool IsGameOver(Coordinate robotPosition){
            return EndingPosition.IsEqual(robotPosition);
        }

        public bool CanMove(Coordinate position){
            int height = Playground.Count;
            int width = height > 0 ? Playground[0].Count : 0;
            if(position.X >= 0 && position.Y >= 0){
                return position.X < height && position.Y < width && Playground[position.X][position.Y].IsMoveble; 
            }
            return false;
        }

    }
}