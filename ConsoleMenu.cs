using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;

namespace GezginRobotProjesi
{
    public class ConsoleMenu : Menu
    {
        private readonly ConsoleColor defaultBackgroundColor;
        private readonly ConsoleColor defaultForegroundColor;

        public ConsoleMenu():base(){
            defaultBackgroundColor = Console.BackgroundColor;
            defaultForegroundColor = Console.ForegroundColor;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}