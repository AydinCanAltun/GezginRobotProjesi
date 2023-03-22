using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Abstractions;
using GezginRobotProjesi.Entity;

namespace GezginRobotProjesi.Interfaces
{
    public interface IPlayerRobotFactory
    {
        public PlayerRobot CreateInstance(Coordinate position);
    }
}