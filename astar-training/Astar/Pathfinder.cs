using System;
using System.Collections.Generic;

namespace astar_training.Astar
{
    public class Pathfinder
    {
        private Tile[,] _map;
        private int[] _mapLengths;
        private Node[,] _nodes;
        private Node _entryNode;
        private Node _exitNode;

        public Pathfinder(Tile[,] map)
        {
            _map = map;
            _mapLengths = new int[2] { _map.GetLength(0), _map.GetLength(1) };

            _nodes = new Node[_mapLengths[0], _mapLengths[1]];

            for (int i = 0; i < _mapLengths[0]; i++)
            {
                for (int j = 0; j < _mapLengths[1]; j++)
                {
                    _nodes[i, j] = new Node(new Point(i, j));

                    if (_map[i, j] == Tile.Entry)
                        _entryNode = _nodes[i, j];
                    else if (_map[i, j] == Tile.Exit)
                        _exitNode = _nodes[i, j];
                }
            }
        }

        public void Draw()
        {
            LinkedList<Point> path = FindPath();
            if (path != null)
            {
                foreach (Point point in path)
                {
                    if (_map[point.X, point.Y] != Tile.Exit)
                        _map[point.X, point.Y] = Tile.Path;
                }
                MapUtils.Draw(_map);
            }
            else
                Console.WriteLine("There is no path");
        }

        public LinkedList<Point> FindPath()
        {
            LinkedList<Point> path = null;
            if (Search(_nodes[_entryNode.Pos.X, _entryNode.Pos.Y]))
            {
                path = new LinkedList<Point>();
                Node node = _nodes[_exitNode.Pos.X, _exitNode.Pos.Y];
                while (node.ParentNode != null)
                {
                    path.AddFirst(node.Pos);
                    node = node.ParentNode;
                }
            }
            return path;
        }

        private bool Search(Node currentNode)
        {
            currentNode.State = NodeState.Closed;
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);
            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            foreach (Node nextNode in nextNodes)
            {
                if (nextNode == _exitNode)
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
            List<Point> nextLocations = GetAdjacentLocations(fromNode.Pos);

            foreach (Point location in nextLocations)
            {
                int x = location.X;
                int y = location.Y;

                // Stay within the grid's boundaries
                if (x < 0 || x >= _mapLengths[0] || y < 0 || y >= _mapLengths[1])
                    continue;

                // Ignore non-walkable nodes
                if (_map[x, y] == Tile.Wall)
                    continue;

                Node node = _nodes[x, y];

                // Ignore already-closed nodes
                if (node.State == NodeState.Closed)
                    continue;

                // Calculate G, H and F
                // G = distance from starting node to target node
                // H = distance from target node to exit node
                // F = G+H
                // Here, G is always 1, because there are no diagonals nor traps
                node.G = 1;
                float a = _exitNode.Pos.X - (node.Pos.X);
                float b = _exitNode.Pos.Y - (node.Pos.Y);
                node.H = (float)Math.Sqrt(a * a + b * b);
                node.F = node.G + node.H;

                // Already-open nodes are only added to the list
                if (node.State == NodeState.Open)
                {
                    node.ParentNode = fromNode;
                    walkableNodes.Add(node);
                }
                else
                {
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkableNodes.Add(node);
                }
            }

            return walkableNodes;
        }

        private static List<Point> GetAdjacentLocations(Point nodePos)
        {
            return new List<Point>(4)
            {
                new Point(nodePos.X - 1, nodePos.Y),
                new Point(nodePos.X + 1, nodePos.Y),
                new Point(nodePos.X, nodePos.Y - 1),
                new Point(nodePos.X, nodePos.Y + 1)
            };
        }
    }
}