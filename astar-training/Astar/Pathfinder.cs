using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace astar_training.Astar
{
    public class Pathfinder
    {
        private Map _map;
        private Point _entryPoint;
        private Point _exitPoint;

        public Pathfinder(Map map)
        {
            _map = map;
            for (int i = 0; i < _map.getMap().GetLength(0); i++)
            {
                for (int j = 0; j < _map.getMap().GetLength(1); j++)
                {
                    if (_map.getMap()[i, j] == Map.Tile.Entry)
                        _entryPoint = new Point(i, j);
                    else if (_map.getMap()[i, j] == Map.Tile.Exit)
                        _exitPoint = new Point(i, j);
                }
            }
        }

        private bool Search(Node currentNode)
        {
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);
            nextNodes.Sort((node1, node2) => node1._f.CompareTo(node2._f));
            foreach (var nextNode in nextNodes)
            {
        
            }
            return false;
        }

        private List<Node> GetAdjacentWalkableNodes(Node currentNode)
        {
            List<Node> adjacentNodes = new List<Node>();

            if (_map.getMap()[currentNode._pos._x - 1, currentNode._pos._y] != Map.Tile.Wall)
            {
                float a = _exitPoint._x - (currentNode._pos._x - 1);
                float b = _exitPoint._y - (currentNode._pos._y);
                float h = (float)Math.Sqrt(a*a + b*b);
                adjacentNodes.Add(new Node(new Point(currentNode._pos._x - 1, currentNode._pos._y), 1, h, 1+h));
            }
            if (_map.getMap()[currentNode._pos._x + 1, currentNode._pos._y] != Map.Tile.Wall)
            {
                float a = _exitPoint._x - (currentNode._pos._x + 1);
                float b = _exitPoint._y - (currentNode._pos._y);
                float h = (float)Math.Sqrt(a * a + b * b);
                adjacentNodes.Add(new Node(new Point(currentNode._pos._x + 1, currentNode._pos._y), 1, h, 1 + h));
            }
            if (_map.getMap()[currentNode._pos._x, currentNode._pos._y - 1] != Map.Tile.Wall)
            {
                float a = _exitPoint._x - (currentNode._pos._x);
                float b = _exitPoint._y - (currentNode._pos._y - 1);
                float h = (float)Math.Sqrt(a * a + b * b);
                adjacentNodes.Add(new Node(new Point(currentNode._pos._x, currentNode._pos._y - 1), 1, h, 1 + h));
            }
            if (_map.getMap()[currentNode._pos._x, currentNode._pos._y + 1] != Map.Tile.Wall)
            {
                float a = _exitPoint._x - (currentNode._pos._x);
                float b = _exitPoint._y - (currentNode._pos._y + 1);
                float h = (float)Math.Sqrt(a * a + b * b);
                adjacentNodes.Add(new Node(new Point(currentNode._pos._x, currentNode._pos._y + 1), 1, h, 1 + h));
            }

            return adjacentNodes;
        }
    }
}
