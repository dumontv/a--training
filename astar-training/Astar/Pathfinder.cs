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
        private Node[,] _nodes;
        private Point _entryPoint;
        private Point _exitPoint;

        public Pathfinder(Map map)
        {
            _map = map;
            _nodes = new Node[_map.getMap().GetLength(0), _map.getMap().GetLength(1)];
            for (int i = 0; i < _map.getMap().GetLength(0); i++)
            {
                for (int j = 0; j < _map.getMap().GetLength(1); j++)
                {
                    _nodes[i,j] = new Node(new Point(i, j));

                    if (_map.getMap()[i, j] == Map.Tile.Entry)
                        _entryPoint = new Point(i, j);
                    else if (_map.getMap()[i, j] == Map.Tile.Exit)
                        _exitPoint = new Point(i, j);
                }
            }
        }

        public void Draw()
        {
            List<Point> points = FindPath();
            if (points.Count > 0)
            {
                foreach (Point point in points)
                {
                    if (_map.getMap()[point._x, point._y] != Map.Tile.Exit)
                        _map.getMap()[point._x, point._y] = Map.Tile.Path;
                }
                _map.Draw();
            }
            else
                Console.WriteLine("There is no path");
        }

        public List<Point> FindPath()
        {
            List<Point> path = new List<Point>();
            if (Search(_nodes[_entryPoint._x, _entryPoint._y]))
            {
                Node node = _nodes[_exitPoint._x, _exitPoint._y];
                while (node._parentNode != null)
                {
                    path.Add(node._pos);
                    node = node._parentNode;
                }
                path.Reverse();
            }
            return path;
        }

        private bool Search(Node currentNode)
        {
            currentNode.setNodeState(Node.NodeState.Closed);
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);
            nextNodes.Sort((node1, node2) => node1._f.CompareTo(node2._f));
            foreach (var nextNode in nextNodes)
            {
                if (nextNode._pos == _exitPoint)
                {
                    return true;
                }           
                else
                {
                    if (Search(nextNode))
                        return true;
                }           
            }
            return false;
        }

        private List<Node> GetAdjacentWalkableNodes(Node fromNode)
        {
            List<Node> walkableNodes = new List<Node>();
            List<Point> nextLocations = GetAdjacentLocations(fromNode._pos);

            foreach (var location in nextLocations)
            {
                int x = location._x;
                int y = location._y;
                
                // Stay within the grid's boundaries
                if (x < 0 || x >= _map.getMap().GetLength(0) || y < 0 || y >= _map.getMap().GetLength(1))
                    continue;

                // Ignore non-walkable nodes
                if (_map.getMap()[x, y] == Map.Tile.Wall)
                    continue;

                Node node = _nodes[x, y];

                // Ignore already-closed nodes
                if (node._state == Node.NodeState.Closed)
                    continue;

                // Calculate G, H and F
                // Here, G is always 1, because there are no diagonals nor traps
                node._g = 1;
                float a = _exitPoint._x - (node._pos._x);
                float b = _exitPoint._y - (node._pos._y);                
                node._h = (float)Math.Sqrt(a * a + b * b);
                node._f = node._g + node._h;

                // Already-open nodes are only added to the list
                if (node._state == Node.NodeState.Open)
                {
                    node.setParentNode(fromNode);
                    walkableNodes.Add(node);
                }
                else
                {
                    node.setParentNode(fromNode);
                    node.setNodeState(Node.NodeState.Open);
                    walkableNodes.Add(node);
                }
            }

            return walkableNodes;
        }

        private List<Point> GetAdjacentLocations(Point nodePos)
        {
            List<Point> locations = new List<Point>();
            locations.Add(new Point(nodePos._x - 1, nodePos._y));
            locations.Add(new Point(nodePos._x + 1, nodePos._y));
            locations.Add(new Point(nodePos._x, nodePos._y - 1));
            locations.Add(new Point(nodePos._x, nodePos._y + 1));

            return locations;
        }
    }
}
