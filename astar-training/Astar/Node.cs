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

        public Node(Point pos, float g, float h, float f)
        {
            _pos = pos;
            _g = g;
            _h = h;
            _f = f;
        }

        public void setPos(Point pos)
        {
            _pos = pos;
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
    }
}
