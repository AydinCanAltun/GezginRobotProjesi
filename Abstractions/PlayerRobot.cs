using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GezginRobotProjesi.Abstractions
{
    public abstract class PlayerRobot
    {
        public Coordinate CurrentPosition {get; set;}
        public List<Coordinate> VisitedCoordinates {get; set;}
        protected List<Coordinate> VisibleBlocks {get; set;}

        public PlayerRobot(Coordinate startingPosition){
            CurrentPosition = startingPosition;
            VisitedCoordinates = new List<Coordinate>();
            VisibleBlocks = new List<Coordinate>();
        }

        public abstract void ShowGameEndingMessage();
        public virtual void Move()
        {
            VisitedCoordinates.Add(CurrentPosition);
        }
        public void Move(Coordinate newPosition) {
            VisitedCoordinates.Add(CurrentPosition);
            CurrentPosition = newPosition;
        }
        public abstract List<Coordinate> ShortestPath();
        
        public void SetPosition(Coordinate position){
            CurrentPosition = position;
        }

        private void AddVisited(int x, int y) {
            Coordinate coordinate = new Coordinate(x, y);
            VisitedCoordinates.Add(coordinate);
        }

        public void SetVisibleBlocks(List<Coordinate> newVisibleBlocks){
            VisibleBlocks = newVisibleBlocks;
        }

    }
}