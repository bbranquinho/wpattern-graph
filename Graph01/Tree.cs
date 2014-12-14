using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class Tree
    {
        public static int N;
        public Edge[] edges;
        public bool[] included;
        public int[] verticesDelay;
        public int h;

        //public Tree parent;
        
        public Tree(Tree mTree)
        {
            this.edges = new Edge[Tree.N];
            this.included = new bool[Tree.N];
            this.h = mTree.h;
            this.edges = new Edge[Tree.N];
            this.verticesDelay = new int[Tree.N];

            for (int i = 0; i < Tree.N; i++)
            {
                this.included[i] = mTree.included[i];
                this.edges[i] = new Edge();
                this.edges[i].edge = new List<Node>();
                this.verticesDelay[i] = mTree.verticesDelay[i];

                foreach (Node node in mTree.edges[i].edge)
                {
                    this.edges[i].edge.Add(new Node(node.Vertex, node.Weight, node.Delay));
                }
            }

            //this.parent = mTree;
        }

        public Tree(int mStart)
        {
            this.edges = new Edge[Tree.N];
            this.included = new bool[Tree.N];
            this.h = 0;
            this.verticesDelay = new int[Tree.N];

            for (int i = 0; i < Tree.N; i++)
            {
                this.edges[i] = new Edge();
                this.edges[i].edge = new List<Node>();
                this.included[i] = false;
            }

            this.included[mStart] = true;
        }

        public void addEdge(int mX, int mY, int mWeight, int mDelay)
        {
            this.edges[mX].edge.Add(new Node(mY, mWeight, mDelay));
            this.edges[mY].edge.Add(new Node(mX, mWeight, mDelay));
            this.included[mY] = true;
            this.verticesDelay[mY] = this.verticesDelay[mX] + mDelay;
            this.h += mWeight;
        }

        public bool excededDelay(Tree mTree, int mLimitDelay, int[] mGoal)
        {
            List<int> Q = new List<int>();
            int[] auxVerticesDelay = new int[Tree.N];
            int aux, i, min;
            bool[] auxIncluded = new bool[Tree.N];

            for (i = 0; i < Tree.N; i++)
            {
                auxVerticesDelay[i] = ((this.verticesDelay[i] == 0) ? int.MaxValue : this.verticesDelay[i]);
                auxIncluded[i] = this.included[i];
                Q.Add(i);
            }
            auxVerticesDelay[0] = 0;

            while (Q.Count > 0)
            {
                Q.Sort(new QIcomparer(auxVerticesDelay));
                aux = Q[0];
                Q.RemoveAt(0);

                auxIncluded[aux] = true;
                min = i = int.MaxValue;

                foreach (Node node in mTree.edges[aux].edge)
                {
                    if (!auxIncluded[node.Vertex])
                    {
                        if ((auxVerticesDelay[aux] + node.Delay) < min)
                        {
                            min = auxVerticesDelay[aux] + node.Delay;
                            i = node.Vertex;
                        }
                    }
                }

                if (i != int.MaxValue)
                {
                    if (min < auxVerticesDelay[i])
                    {
                        auxVerticesDelay[i] = min;
                    }
                }
            }

            foreach (int goal in mGoal)
            {
                if (auxVerticesDelay[goal] > mLimitDelay)
                {
                    return true;
                }
            }

            return false;
        }

        public string key()
        {
            string str = "";

            for (int i = 0; i < Tree.N; i++)
            {
                if (this.included[i])
                {
                    str += i + " ";
                }
            }

            return str;
        }

        public void setN(int mN)
        {
            Tree.N = mN;
        }
    }
}
