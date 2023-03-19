using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prolab21.Entity;

namespace prolab21
{
    public class Robot
    {
        public Coordinate CurrentPosition {get; set;}
        public List<Coordinate> VisitedCoordinates {get; set;}

        public Robot(int x, int y){
            CurrentPosition = new Coordinate(x, y);
            VisitedCoordinates = new List<Coordinate>();
        }

        public void Move() {

        }

        private void AddVisited(int x, int y) {
            Coordinate coordinate = new Coordinate(x, y);
            VisitedCoordinates.Add(coordinate);
        }

    }
}