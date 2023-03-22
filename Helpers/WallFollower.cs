using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;

namespace GezginRobotProjesi.Helpers
{
    public class WallFollower
    {
        public GameMap GameMap {get; set;}
        public PlayerRobot Player {get; set;}

        public WallFollower(GameMap gameMap, PlayerRobot player){
            this.GameMap = gameMap;
            this.Player = player;
        }

        public Coordinate NextPosition(){
            if(!Player.VisitedCoordinates.Any()){
                return GameMap.Playground[Player.CurrentPosition.X+1][Player.CurrentPosition.Y].Position;
            }
            Direction currentDirection = GetDirection();
            Direction[] priorities = GetPriority(currentDirection);
            Coordinate newPosition = GetNextMoveBasedOnPriorities(priorities);
            return newPosition;
        }

        private Coordinate GetNextMoveBasedOnPriorities(Direction[] priorities){
            Coordinate newPosition = new Coordinate(-1, -1);
            foreach(Direction priority in priorities){
                newPosition = GetNextPositionByDirection(priority);
                if(newPosition.IsEqual(GameMap.EndingPosition)){
                    return newPosition;
                }
                if(GameMap.CanMove(newPosition)){
                    return newPosition;
                }
            }
            return newPosition;
        }

        private Coordinate GetNextPositionByDirection(Direction turnTo){
            Coordinate newPosition;
            if(turnTo == Direction.North){
                newPosition = new Coordinate(Player.CurrentPosition.X - 1, Player.CurrentPosition.Y);
            }else if(turnTo == Direction.South){
                newPosition = new Coordinate(Player.CurrentPosition.X + 1, Player.CurrentPosition.Y);
            }else if(turnTo == Direction.East){
                newPosition = new Coordinate(Player.CurrentPosition.X,Player.CurrentPosition.Y + 1);
            }else{
                newPosition = new Coordinate(Player.CurrentPosition.X, Player.CurrentPosition.Y - 1);
            }
            return newPosition;
        }

        private Direction GetDirection(){
            Coordinate previousPosition = Player.VisitedCoordinates.Last();
            int deltaHeight = Player.CurrentPosition.X - previousPosition.X;
            int deltaWidth = Player.CurrentPosition.Y - previousPosition.Y;

            if(deltaHeight == 1){
                return Direction.South;
            }
            if(deltaHeight == -1){
                return Direction.North;
            }
            if(deltaWidth == 1){
                return Direction.East;
            }
            return Direction.West;
        }

        private Direction[] GetPriority(Direction currenctDirection){
            if(currenctDirection == Direction.North){
                return Constant.Priorities[0];
            }

            if(currenctDirection == Direction.South){
                return Constant.Priorities[1];
            }

            if(currenctDirection == Direction.East){
                return Constant.Priorities[2];
            }

            return Constant.Priorities[3];
        }
    }
}