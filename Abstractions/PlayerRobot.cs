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
        private int takenAction {get; set;}
        protected List<Coordinate> VisibleBlocks {get; set;}

        public PlayerRobot(Coordinate startingPosition){
            CurrentPosition = startingPosition;
            VisitedCoordinates = new List<Coordinate>();
            takenAction = -1;
            VisibleBlocks = new List<Coordinate>();
        }

        public abstract void WaitForAction();
        public abstract void ShowGameEndingMessage();
        public abstract void Move();
        
        public void SetPosition(Coordinate position){
            CurrentPosition = position;
        }

        private void AddVisited(int x, int y) {
            Coordinate coordinate = new Coordinate(x, y);
            VisitedCoordinates.Add(coordinate);
        }

        public int GetAction(){
            return takenAction;
        }

        public void SetVisibleBlocks(List<Coordinate> newVisibleBlocks){
            VisibleBlocks = newVisibleBlocks;
        }

        public void ResetAction(){
            takenAction = -1;
        }

        protected void SetTakenAction(int action){
            takenAction = action;
        }

        public void ValidateAction(){
            if(takenAction != 1 && takenAction != 2 && takenAction != 3){
                ResetAction();
                ConsoleHelper.ClearLast2Lines();
            }
        }

    }
}