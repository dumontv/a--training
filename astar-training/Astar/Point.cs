using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar_training.Astar
{
    public class Point
    {
        public int _x;
        public int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public static bool operator== (Point a, Point b)
        {
            return (a._x == b._x && a._y == b._y);
        }

        public static bool operator!= (Point a, Point b)
        {
            return !(a == b);
        }
    }
}
