﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar_training.Astar
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point a, Point b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    }
}
