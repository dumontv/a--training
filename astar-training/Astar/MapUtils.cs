using System;

namespace astar_training.Astar
{
    public static class MapUtils
    {     
        // No walls, only ground
        public static Tile[,] GenerateMapPreset1()
        {
            return new Tile[10, 10] {
                { Tile.Entry,  Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Exit   }
            };
        }

        // Some walls
        public static Tile[,] GenerateMapPreset2()
        {
            return new Tile[10, 10] {
                { Tile.Entry,  Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Wall,   Tile.Wall,   Tile.Wall,   Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Wall,   Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Wall,   Tile.Wall,   Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Wall,   Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Wall,   Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground },
                { Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Ground, Tile.Wall,   Tile.Ground, Tile.Ground, Tile.Ground, Tile.Exit   }
            };
        }

        public static Tile[,] GenerateRandomMap()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Tile[,] randomMap = new Tile[10, 10];
            int[] mapLengths = new int[2] { randomMap.GetLength(0), randomMap.GetLength(1) };

            // Everything is random, either walls or ground
            for (int i = 0; i < mapLengths[0]; i++)
            {
                for (int j = 0; j < mapLengths[1]; j++)
                {
                    randomMap[i, j] = (Tile)rnd.Next(0, 2);
                }
            }

            // We set an entry at the start and an exit at the end
            randomMap[0, 0] = Tile.Entry;
            randomMap[mapLengths[0] - 1, mapLengths[1] - 1] = Tile.Exit;

            return randomMap;
        }

        public static void Draw(Tile[,] map)
        {
            int[] mapLengths = new int[2] { map.GetLength(0), map.GetLength(1) };
            for (int i = 0; i < mapLengths[0]; i++)
            {
                for (int j = 0; j < mapLengths[1]; j++)
                {
                    switch (map[i, j])
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
                        case Tile.Path:
                            Console.Write("o");
                            break;
                    }
                    if (j == mapLengths[0] - 1)
                        Console.Write("\n");
                }
            }
        }
    }
}