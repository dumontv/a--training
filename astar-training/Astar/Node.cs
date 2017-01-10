using System;
using System.Collections.Generic;
using System.Linq;
namespace astar_training.Astar
{
    public class Node
    {
        public Point Pos { get; set; }
        public float G { get; set; }
        public float H { get; set; }
        public float F { get; set; }
        public NodeState State { get; set; }
        public Node ParentNode { get; set; }

        public Node(Point pos)
        {
            Pos = pos;
            State = NodeState.Untested;
        }
    }
}