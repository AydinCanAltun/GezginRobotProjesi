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
        private bool isGameOver {get; set;}
        protected int takenAction {get; set;}

        public PlayerRobot(Coordinate startingPosition){
            CurrentPosition = startingPosition;
            VisitedCoordinates = new List<Coordinate>();
            isGameOver = false;
            takenAction = -1;
        }

        public abstract void WaitForAction();
        public abstract Coordinate WantsToMove();
        public abstract void ShowGameEndingMessage();

        public void Move(Coordinate nextPosition, bool shouldWaitAnotherAction){
            VisitedCoordinates.Add(CurrentPosition);
            CurrentPosition = nextPosition;
            if(shouldWaitAnotherAction){
                takenAction = -1;
            }
        }
        
        public void SetPosition(Coordinate position){
            CurrentPosition = position;
        }

        public bool ShouldFinishGame(){
            return isGameOver;
        }

        public void SetIsGameOver(bool isGameOver){
            this.isGameOver = isGameOver;
        }

        private void AddVisited(int x, int y) {
            Coordinate coordinate = new Coordinate(x, y);
            VisitedCoordinates.Add(coordinate);
        }

        public int GetAction(){
            return takenAction;
        }

    }
}