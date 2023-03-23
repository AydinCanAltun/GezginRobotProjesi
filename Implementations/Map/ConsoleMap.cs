using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace GezginRobotProjesi.Implementations.Map
{
    public class ConsoleMap : GameMap
    {
        public ConsoleMap(List<List<Block>> map) : base(map){ }
        public override void Draw(List<Coordinate> visited, Coordinate robotPosition)
        {
            Console.Clear();
            Console.ResetColor();
            int height = this.Playground.Count;
            int width = height > 0 ? this.Playground[0].Count : 0;
            Console.WriteLine(string.Format("Başlangıç Noktası: ({0},{1})", this.StartingPosition.X, this.StartingPosition.Y));
            Console.WriteLine(string.Format("Bitiş Noktası: ({0},{1})", this.EndingPosition.X, this.EndingPosition.Y));
            for(int i=0; i<height; i++) {
                for(int j=0; j<width; j++) {
                    SetBackgroundColor(this.Playground[i][j], visited, robotPosition);
                    Console.Write(string.Format(" {0} ", ((int)this.Playground[i][j].Type)));
                }
                Console.ResetColor();
                Console.Write("\n");
            }
        }

        private void SetBackgroundColor(Block currentBlock, List<Coordinate> visitedBlocks, Coordinate robotPosition){
            if(currentBlock.Type == BlockType.Path){
                Console.BackgroundColor = currentBlock.IsVisible ? ConsoleColor.Green : ConsoleColor.DarkGreen;
            }else{
                if(currentBlock.IsMoveble){
                    Console.BackgroundColor = ConsoleColor.Red;
                }else{
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
            }
            if(currentBlock.Position.IsEqual(this.StartingPosition) || currentBlock.Position.IsEqual(this.EndingPosition)){
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            if(visitedBlocks.Any(c => c.X == currentBlock.Position.X && c.Y == currentBlock.Position.Y)){
                Console.BackgroundColor = ConsoleColor.White;
            }

            if(currentBlock.Position.IsEqual(robotPosition)){
                Console.BackgroundColor = ConsoleColor.Magenta;
            }
        }
    }
}