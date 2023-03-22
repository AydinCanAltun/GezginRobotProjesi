using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi.Implementations.Robot
{
    public class WallFollowerRobot : PlayerRobot
    {
        public WallFollowerRobot(Coordinate startingPosition) : base(startingPosition) {
        }

        public override void ShowGameEndingMessage()
        {
            Console.ResetColor();
            Console.WriteLine("Oyun sonlandırılıyor...");
        }

        public override void WaitForAction()
        {
            try{
                ConsoleKeyInfo input = Console.ReadKey();
                int action;
                if(char.IsDigit(input.KeyChar) && int.TryParse(input.KeyChar.ToString(), out action)){
                    takenAction = action;
                }else{
                    Console.WriteLine("Hatalı giriş yaptınız! Lütfen tekrar deneyiniz!");
                    takenAction = -1;
                } 
            }catch(Exception ex){
                Console.WriteLine(string.Format("Hatalı giriş yaptınız! Lütfen tekrar deneyiniz!"));
                takenAction = -1;
            }
        }

        public override Coordinate WantsToMove()
        {
            throw new NotImplementedException();
        }
    }
}