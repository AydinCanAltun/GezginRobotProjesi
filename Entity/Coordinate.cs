using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prolab21.Entity
{
    public class Coordinate
    {
        public int X {get; set;}
        public int Y {get; set;}

        public Coordinate(int xPosition, int yPosition) {
            this.X = xPosition;
            this.Y = yPosition;
        }
    }
}