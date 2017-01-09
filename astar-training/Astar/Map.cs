using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar_training.Astar
{
    class Map
    {
        public enum Tile { Ground, Wall, Entry, Exit };
        private Tile[,] _map;

        public Map(int preset = 1)
        {
            switch (preset)
            {
                case 1: default:
                    _map = loadMapPreset1();
                    break;
                case -1:
                    _map = loadRandomMap();
                    break;
            }
        }

        // No walls, only ground
        private Tile[,] loadMapPreset1()
        {
            return new Tile[10,10] {
                { Tile.Entry,  Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Exit }
            };
        }

        private Tile[,] loadRandomMap()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Tile[,] randomMap =  new Tile[10, 10];

            // We set an entry at the start and an exit at the end
            randomMap[0, 0] = Tile.Entry;
            randomMap[randomMap.GetLength(0) - 1, randomMap.GetLength(1) - 1] = Tile.Exit;

            // The rest is random
            for (int i = 1; i < randomMap.GetLength(0); i++)
            {
                for (int j = 0; j < randomMap.GetLength(1) - 1; j++)
                {
                    randomMap[i, j] = (Tile) rnd.Next(0, 2);
                }
            }
            return randomMap;
        }

        public void Draw()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    switch (_map[i, j])
                    {
                        case Tile.Ground:
                            Console.Write("x");
                            break;
                        case Tile.Wall:
                            Console.Write("#");
                            break;
                        case Tile.Entry:
                            Console.Write("B");
                            break;
                        case Tile.Exit:
                            Console.Write("E");
                            break;
                    }
                    if (j == _map.GetLength(0) - 1)
                        Console.Write("\n");
                }
            }
        }
    }
}
