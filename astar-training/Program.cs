using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using astar_training.Astar;

namespace astar_training
{
    class Program
    {
        static void Main(string[] args)
        {
            Tile[,] map = MapUtils.GenerateMapPreset2();
            Pathfinder pathfinder = new Pathfinder(map);

            Console.WriteLine("Map without path");
            MapUtils.Draw(map);
            Console.WriteLine("\nMap with path");
            pathfinder.Draw();
            Console.ReadKey();
        }
    }
}
