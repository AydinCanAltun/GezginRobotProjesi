using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity.Enums;
using GezginRobotProjesi.Helpers;

namespace GezginRobotProjesi.Entity
{
    public class Labyrinth
    {
        public int Heigth {get; set;}
        public int Width {get; set;}
        public Coordinate StartingPoint {get; set;}
        public Coordinate EndingPoint {get; set;}

        public Labyrinth(int heigth, int width){
            this.Heigth = heigth;
            this.Width = width;
            Random r = new Random();
            Corners corner = r.GetEnumValue<Corners>();
            if(corner == Corners.LeftTop){
                this.StartingPoint = new Coordinate(1, 1);
                this.EndingPoint = new Coordinate(heigth - 2, width - 2);
            }else if(corner == Corners.LeftBottom){
                this.StartingPoint = new Coordinate(heigth - 2, 1);
                this.EndingPoint = new Coordinate(1, width - 2);
            }else if(corner == Corners.RightTop){
                this.StartingPoint = new Coordinate(1, width - 2);
                this.EndingPoint = new Coordinate(heigth - 2, 1);
            }else{
                this.StartingPoint = new Coordinate(heigth - 2, width - 2);
                this.EndingPoint = new Coordinate(1, 1);
            }
        }

    }

}