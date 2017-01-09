using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astar_training.Astar
{
    public class Node
    {
        public Point _pos;
        public float _g;
        public float _h;
        public float _f;
        public NodeState _state;
        public Node _parentNode;

        public enum NodeState { Untested, Open, Closed }

        public Node(Point pos)
        {
            _pos = pos;
            _state = NodeState.Untested;
        }

        public void setG(float g)
        {
            _g = g;
        }

        public void setH(float h)
        {
            _h = h;
        }

        public void setF(float f)
        {
            _f = f;
        }

        public void setNodeState(NodeState state)
        {
            _state = state;
        }

        public void setParentNode(Node parentNode)
        {
            _parentNode = parentNode;
        }
    }
}
