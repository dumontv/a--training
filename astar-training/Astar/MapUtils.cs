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
            int firstMapLength = map.GetLength(0);

            for (int i = 0; i < firstMapLength; i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(GetTileChar(map[i,j]));

                    if (j == firstMapLength - 1)
                        Console.Write(Environment.NewLine);
                }
            }
        }

        public static char GetTileChar(Tile tile)
        {
            switch (tile)
            {
                case Tile.Ground: return 'x';
                case Tile.Wall: return '#';
                case Tile.Entry: return 'B';
                case Tile.Exit: return 'E';
                case Tile.Path: return 'o';

                default:
                    throw new ArgumentException(string.Format("Tile {0} not supported", tile));
            }
        }
    }
}