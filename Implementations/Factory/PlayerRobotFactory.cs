using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Implementations.Robot;
using GezginRobotProjesi.Interfaces;

namespace GezginRobotProjesi.Implementations.Factory
{
    public class PlayerRobotFactory : IPlayerRobotFactory
    {
        public PlayerRobot CreateInstance(Coordinate position)
        {
            return new PledgeRobot(position);
        }
    }
}