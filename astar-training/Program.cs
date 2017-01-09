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
            Map map = new Map(2);
            Pathfinder pathfinder = new Pathfinder(map);

            Console.WriteLine("Map without path");
            map.Draw();
            Console.WriteLine("\nMap with path");
            pathfinder.Draw();
            Console.ReadKey();
        }
    }
}
