using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class AStar
    {
        #region Member Fields
        private List<Tree> open;
        private Tree aux;
        private int left, right, lowest, parent;
        #endregion

        #region Constructor
        public AStar()
        {
        }
        #endregion

        #region Public Method
        public Tree FindSolutionSorting(Tree mTree, int mStart, int[] mGoal)
        {
            List<Tree> closed = new List<Tree>();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();
            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                open.Sort(new TreeIComparer());
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open.RemoveAt(0);
                closed.Add(x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if (Contains(y, closed) >= 0)
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionSorting(Tree mTree, int mStart, int[] mGoal, int mLimitDelay)
        {
            List<Tree> closed = new List<Tree>();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();
            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                open.Sort(new TreeIComparer());
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open.RemoveAt(0);
                closed.Add(x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if ((Contains(y, closed) >= 0) || (y.verticesDelay[node.Vertex] > mLimitDelay) || y.excededDelay(mTree, mLimitDelay, mGoal))
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionSortingHashtable(Tree mTree, int mStart, int[] mGoal)
        {
            Hashtable hashClosed = new Hashtable();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();

            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                open.Sort(new TreeIComparer());
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open.RemoveAt(0);
                hashClosed.Add(x.key(), x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if (hashClosed.Contains(y.key()))
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionSortingHashtable(Tree mTree, int mStart, int[] mGoal, int mLimitDelay)
        {
            Hashtable hashClosed = new Hashtable();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();

            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                open.Sort(new TreeIComparer());
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open.RemoveAt(0);
                hashClosed.Add(x.key(), x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if (hashClosed.Contains(y.key()) || (y.verticesDelay[node.Vertex] > mLimitDelay) || y.excededDelay(mTree, mLimitDelay, mGoal))
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionHeap(Tree mTree, int mStart, int[] mGoal)
        {
            List<Tree> closed = new List<Tree>();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();
            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open[0] = open[open.Count - 1];
                open.RemoveAt(open.Count - 1);
                RemoveHeapOpen(0);

                closed.Add(x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if (Contains(y, closed) >= 0)
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                                InsertHeapOpen(open.Count - 1);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionHeap(Tree mTree, int mStart, int[] mGoal, int mLimitDelay)
        {
            List<Tree> closed = new List<Tree>();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();
            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open[0] = open[open.Count - 1];
                open.RemoveAt(open.Count - 1);
                RemoveHeapOpen(0);

                closed.Add(x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if ((Contains(y, closed) >= 0) || (y.verticesDelay[node.Vertex] > mLimitDelay) || y.excededDelay(mTree, mLimitDelay, mGoal))
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                                InsertHeapOpen(open.Count - 1);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionHeapHashtable(Tree mTree, int mStart, int[] mGoal)
        {
            Hashtable hashClosed = new Hashtable();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();
            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open[0] = open[open.Count - 1];
                open.RemoveAt(open.Count - 1);
                RemoveHeapOpen(0);

                hashClosed.Add(x.key(), x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if (hashClosed.Contains(y.key()))
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                                InsertHeapOpen(open.Count - 1);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }

        public Tree FindSolutionHeapHashtable(Tree mTree, int mStart, int[] mGoal, int mLimitDelay)
        {
            Hashtable hashClosed = new Hashtable();
            Tree x, y;
            int i, z;

            this.open = new List<Tree>();
            this.open.Add(new Tree(mStart));

            while (open.Count > 0)
            {
                x = open[0];

                if (IsGoal(x, mGoal))
                {
                    return x;
                }

                open[0] = open[open.Count - 1];
                open.RemoveAt(open.Count - 1);
                RemoveHeapOpen(0);

                hashClosed.Add(x.key(), x);

                for (i = 0; i < Tree.N; i++)
                {
                    if (x.included[i])
                    {
                        foreach (Node node in mTree.edges[i].edge.Where(node => !x.included[node.Vertex]))
                        {
                            y = new Tree(x);
                            y.addEdge(i, node.Vertex, node.Weight, node.Delay);

                            if (hashClosed.Contains(y.key()) || (y.verticesDelay[node.Vertex] > mLimitDelay) || y.excededDelay(mTree, mLimitDelay, mGoal))
                            {
                                continue;
                            }

                            if ((z = Contains(y, open)) < 0)
                            {
                                open.Add(y);
                                InsertHeapOpen(open.Count - 1);
                            }
                            else if (y.h < open[z].h)
                            {
                                open[z] = y;
                            }
                        }
                    }
                }
            }

            return null; // Fail.
        }
        #endregion

        #region Methods
        private static int Contains(Tree mY, List<Tree> mList)
        {
            bool containsY;
            int i, j;

            for (i = 0; i < mList.Count; i++)
            {
                containsY = true;

                for (j = 0; (j < Tree.N) && containsY; j++)
                {
                    if (mY.included[j] != mList[i].included[j])
                    {
                        containsY = false;
                    }
                }

                if (containsY)
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsGoal(Tree mTree, int[] mGoal)
        {
            return mGoal.All(vertex => mTree.included[vertex]);
        }

        private void InsertHeapOpen(int mIndex)
        {
            while ((parent = (mIndex - 1) / 2) >= 0)
            {
                if (open[mIndex].h >= open[parent].h)
                {
                    return;
                }

                aux = open[mIndex];
                open[mIndex] = open[parent];
                open[parent] = aux;

                mIndex = parent;
            }
        }

        private void RemoveHeapOpen(int mIndex)
        {
            left = mIndex * 2 + 1;
            right = mIndex * 2 + 2;
            lowest = (((left < open.Count) && (open[left].h < open[mIndex].h)) ? left : mIndex);

            if ((right < open.Count) && (open[right].h < open[lowest].h))
            {
                lowest = right;
            }

            if (lowest != mIndex)
            {
                aux = open[mIndex];
                open[mIndex] = open[lowest];
                open[lowest] = aux;

                RemoveHeapOpen(lowest);
            }
        }
        #endregion
    }
}
