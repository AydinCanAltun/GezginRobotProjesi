using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace GezginRobotProjesi.Abstractions
{
    public abstract class PlayerRobot
    {
        public Coordinate CurrentPosition {get; set;}
        public List<Coordinate> VisitedCoordinates {get; set;}

        public PlayerRobot(Coordinate startingPosition){
            CurrentPosition = startingPosition;
            VisitedCoordinates = new List<Coordinate>();
        }

        public abstract void Move();

        public void SetPosition(Coordinate position){
            CurrentPosition = position;
        }

        private void AddVisited(int x, int y) {
            Coordinate coordinate = new Coordinate(x, y);
            VisitedCoordinates.Add(coordinate);
        }

    }
}