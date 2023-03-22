using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi.Implementations.Robot
{
    public class PledgeRobot : PlayerRobot
    {
        public PledgeRobot(Coordinate startingPosition) : base(startingPosition) {
        }

        public override void Move() {
            throw new NotImplementedException();
        }
    }
}