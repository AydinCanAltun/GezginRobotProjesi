using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;

namespace GezginRobotProjesi.Implementations.Robot
{
    public class WallFollowerRobot : PlayerRobot
    {
        private readonly WallFollowerRule handRule;
        private readonly Direction[][] rightHandRule;
        private readonly Direction[][] leftHandRule;
        public WallFollowerRobot(WallFollowerRule handRule, Coordinate startingPosition) : base(startingPosition) {
            this.handRule = handRule;
            rightHandRule = new Direction[][] {
                new Direction[] {Direction.East, Direction.North, Direction.West, Direction.South},
                new Direction[] {Direction.West, Direction.South, Direction.East, Direction.North},
                new Direction[] {Direction.South, Direction.East, Direction.North, Direction.West},
                new Direction[] {Direction.North, Direction.West, Direction.South, Direction.East}
            };
            leftHandRule = new Direction[][]{
                new Direction[] {Direction.West, Direction.North, Direction.East, Direction.South},
                new Direction[] {Direction.East, Direction.South, Direction.West, Direction.North},
                new Direction[] {Direction.North, Direction.East, Direction.South, Direction.West},
                new Direction[] {Direction.South, Direction.West, Direction.North, Direction.East}
            };
        }

        public override void Move()
        {
            if (!VisitedCoordinates.Any()){
                VisitedCoordinates.Add(CurrentPosition);
                CurrentPosition = VisibleBlocks.First();
            }else{
                Direction facing = GetDirection();
                Direction[] priorities = GetPriorities(facing);
                VisitedCoordinates.Add(CurrentPosition);
                CurrentPosition = DecideNextMove(priorities);
            }
            VisibleBlocks = new List<Coordinate>();
        }

        public override void ShowGameEndingMessage()
        {
            Console.ResetColor();
            Console.WriteLine("Oyun sonlandırılıyor...");
        }

        public override void WaitForAction()
        {
            try{
                Console.Write("1) Bir adım ilerle, 2) Sonuna kadar git, 3) Oyunu Sonlandır");
                ConsoleKeyInfo input = Console.ReadKey();
                int action;
                if(char.IsDigit(input.KeyChar) && int.TryParse(input.KeyChar.ToString(), out action)){
                    SetTakenAction(action);
                }else{
                    Console.Write("Hatalı giriş yaptınız! Lütfen tekrar deneyiniz!");
                    ResetAction();
                } 
            }catch(Exception ex){
                Console.Write(string.Format("Hatalı giriş yaptınız! Lütfen tekrar deneyiniz!"));
                ResetAction();
            }
        }

        private Direction GetDirection(){
            Coordinate previousPosition = VisitedCoordinates.Last();
            int deltaHeight = CurrentPosition.X - previousPosition.X;
            int deltaWidth = CurrentPosition.Y - previousPosition.Y;
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

        private Direction[] GetPriorities(Direction facing){
            if(handRule == WallFollowerRule.LeftHand){
                return GetPrioritiesBasedOnHandRule(facing, leftHandRule);
            }
            return GetPrioritiesBasedOnHandRule(facing, rightHandRule);
        }

        private Coordinate DecideNextMove(Direction[] priorities){
            Coordinate newPosition = new Coordinate(-1, -1);
            foreach(Direction priority in priorities){
                newPosition = GetNextPositionByDirection(priority);
                if(VisibleBlocks.Any(vb => vb.X == newPosition.X && vb.Y == newPosition.Y)){
                    return newPosition;
                }
            }
            return newPosition;
        }

        private Coordinate GetNextPositionByDirection(Direction turnTo){
            Coordinate newPosition;
            if(turnTo == Direction.North){
                newPosition = new Coordinate(CurrentPosition.X - 1, CurrentPosition.Y);
            }else if(turnTo == Direction.South){
                newPosition = new Coordinate(CurrentPosition.X + 1, CurrentPosition.Y);
            }else if(turnTo == Direction.East){
                newPosition = new Coordinate(CurrentPosition.X, CurrentPosition.Y + 1);
            }else{
                newPosition = new Coordinate(CurrentPosition.X, CurrentPosition.Y - 1);
            }
            return newPosition;
        }

        private Direction[] GetPrioritiesBasedOnHandRule(Direction facing, Direction[][] handRule){
            if(facing == Direction.North){
                return handRule[0];
            }

            if(facing == Direction.South){
                return handRule[1];
            }

            if(facing == Direction.East){
                return handRule[2];
            }

            return handRule[3];
        }

    }
}