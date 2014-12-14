using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class Node
    {
        public int Vertex;
        public int Weight;
        public int Delay;

        public Node(int mVertex, int mDelay)
        {
            this.Vertex = mVertex;
            this.Delay = mDelay;
        }

        public Node(int mVertex, int mWeight, int mDelay)
        {
            this.Vertex = mVertex;
            this.Weight = mWeight;
            this.Delay = mDelay;
        }
    }
}
