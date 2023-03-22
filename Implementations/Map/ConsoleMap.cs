using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;

namespace GezginRobotProjesi.Implementations.Map
{
    public class ConsoleMap : GameMap
    {
        public ConsoleMap() : base(){ }
        public ConsoleMap(List<List<Block>> map) : base(map){}
        public override void Draw()
        {
            Console.Clear();
            Console.ResetColor();
            int height = this.Playground.Count;
            int width = height > 0 ? this.Playground[0].Count : 0;
            Console.WriteLine(string.Format("Başlangıç Noktası: ({0},{1})", this.StartingPosition.X, this.StartingPosition.Y));
            Console.WriteLine(string.Format("Bitiş Noktası: ({0},{1})", this.EndingPosition.X, this.EndingPosition.Y));
            for(int i=0; i<height; i++) {
                for(int j=0; j<width; j++) {
                    SetBackgroundColor(this.Playground[i][j]);
                    Console.Write(string.Format(" {0} ", ((int)this.Playground[i][j].Type)));
                }
                Console.ResetColor();
                Console.Write("\n");
            }
            Console.ReadKey();
        }

        private void SetBackgroundColor(Block block){
            if(block.Type == BlockType.Path){
                Console.BackgroundColor = block.IsVisible ? ConsoleColor.Green : ConsoleColor.DarkGreen;
            }else{
                if(block.IsMoveble){
                    Console.BackgroundColor = ConsoleColor.Red;
                }else{
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
            }
            if(block.Position.IsEqual(this.StartingPosition) || block.Position.IsEqual(this.EndingPosition)){
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            if(block.Position.IsEqual(Player.CurrentPosition)){
                Console.BackgroundColor = ConsoleColor.Magenta;
            }

        }
    }
}