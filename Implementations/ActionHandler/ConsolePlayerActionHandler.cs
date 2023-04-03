using prolab21.Abstractions;
using prolab21.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab21.Implementations.ActionHandler
{
    public class ConsolePlayerActionHandler : PlayerActionHandler
    {
        public override void AskForAction()
        {
            try
            {
                Console.Write("1) Bir adım ilerle, 2) Sonuna kadar git, 3) Oyunu Sonlandır");
                ConsoleKeyInfo input = Console.ReadKey();
                int action;
                if (char.IsDigit(input.KeyChar) && int.TryParse(input.KeyChar.ToString(), out action))
                {
                    SetTakenAction(action);
                }
                else
                {
                    Console.Write("Hatalı giriş yaptınız! Lütfen tekrar deneyiniz!");
                    ResetAction();
                }
            }
            catch (Exception ex)
            {
                Console.Write(string.Format("Hatalı giriş yaptınız! Lütfen tekrar deneyiniz!"));
                ResetAction();
            }
        }

        public override void SetTakenAction(int action)
        {
            if(action > 0 && action < 4)
            {
                SetTakenAction((PlayerAction)action);
            }
            else
            {
                ResetAction();
            }
            
        }

        public override void WaitForInput()
        {
            Console.ReadKey();
        }
    }
}
