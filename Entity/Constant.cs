using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GezginRobotProjesi.Entity.Enums;

namespace GezginRobotProjesi.Entity
{
    public static class Constant
    {
        public static List<string> MapUrls = new List<string> {
            "http://bilgisayar.kocaeli.edu.tr/prolab2/url1.txt",
            "http://bilgisayar.kocaeli.edu.tr/prolab2/url2.txt"
        };

        public static MapSize MinimumSize = new MapSize(10, 10);
        public static MapSize MaximumSize = new MapSize(100, 100);

/*
        public static Direction[][] Priorities = new Direction[][]{
            new Direction[] {Direction.West, Direction.North, Direction.East, Direction.South},
            new Direction[] {Direction.East, Direction.South, Direction.West, Direction.North},
            new Direction[] {Direction.North, Direction.East, Direction.South, Direction.West},
            new Direction[] {Direction.South, Direction.West, Direction.North, Direction.East}
        };
*/
        public static Direction[][] Priorities = new Direction[][]{
            new Direction[] {Direction.East, Direction.North, Direction.West, Direction.South},
            new Direction[] {Direction.West, Direction.South, Direction.East, Direction.North},
            new Direction[] {Direction.South, Direction.East, Direction.North, Direction.West},
            new Direction[] {Direction.North, Direction.West, Direction.South, Direction.East}
        };

    }
}