using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Graph
{
    public partial class frmGraph : Form
    {
        #region Form Variables
        private int[] goal;
        private Tree tree;
        #endregion

        #region Form Methods
        public frmGraph()
        {
            InitializeComponent();
        }
        
        private void txtOutput_DoubleClick(object sender, EventArgs e)
        {
            this.txtOutput.Text = "";
        }
        
        private void lblLimitDelay_Click(object sender, EventArgs e)
        {
            this.txtLimitDelay.Enabled = !this.txtLimitDelay.Enabled;
        }

        private void txtLimitDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGoal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumberVertices_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumberExecution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEdge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar.CompareTo('|') == 0))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void btnSolution_Click(object sender, EventArgs e)
        {
            Tree solution;
            StopWatch sw = new StopWatch();

            buildTree();

            sw.Start();
            solution = (this.txtLimitDelay.Enabled ? findSolution(Convert.ToInt32(this.txtLimitDelay.Text)) : findSolution());
            sw.Stop();

            if (solution != null)
            {
                printDFS(solution, 0);
                printDFSWolfram(solution, 0);
                this.txtOutput.Text += "WEIGHT: " + solution.h + "\r\n" + (sw.GetElapsedTimeInMicroseconds() / 1000).ToString() + " milisecond\r\n\r\n";
            }
            else
            {
                this.txtOutput.Text = "Not Founded";
            }
        }

        private void btnPrintGraph_Click(object sender, EventArgs e)
        {
            int i, j;

            buildTree();

            for (i = 0; i < Tree.N; i++)
            {
                foreach (Node node in this.tree.edges[i].edge)
                {
                    this.txtOutput.Text += i + " " + node.Vertex + " (" + node.Weight + ", " + node.Delay + ")\r\n";
                }
            }

            this.txtOutput.Text += "\r\nLayeredGraphPlot[{\r\n";

            for (i = 0; i < Tree.N; i++)
            {
                for (j = 0; j < this.tree.edges[i].edge.Count; j++)
                {
                    this.txtOutput.Text += "\"" + i + "\" -> \"" + this.tree.edges[i].edge[j].Vertex;
                    this.txtOutput.Text += (((i == (Tree.N - 1)) && (j == (this.tree.edges[i].edge.Count - 1))) ? "\r\n" : "\",\r\n");
                }
            }

            this.txtOutput.Text += "}, Left, VertexLabeling -> True]\r\n\r\n";
        }

        private Tree findSolution()
        {
            AStar aStar = new AStar();

            if (this.chkSorting.Checked)
            {
                return aStar.FindSolutionSorting(this.tree, 0, this.goal);
            }
            else if (this.chkSortingHashtable.Checked)
            {
                return aStar.FindSolutionSortingHashtable(this.tree, 0, this.goal);
            }
            else if (this.chkHeap.Checked)
            {
                return aStar.FindSolutionHeap(this.tree, 0, this.goal);
            }
            else if (this.chkHeapHashtable.Checked)
            {
                return aStar.FindSolutionHeapHashtable(this.tree, 0, this.goal);
            }
            else
            {
                throw new Exception("Find solution method not defined!");
            }
        }

        private Tree findSolution(int mLimitDelay)
        {
            AStar aStar = new AStar();

            if (this.chkSorting.Checked)
            {
                return aStar.FindSolutionSorting(this.tree, 0, this.goal, mLimitDelay);
            }
            else if (this.chkSortingHashtable.Checked)
            {
                return aStar.FindSolutionSortingHashtable(this.tree, 0, this.goal, mLimitDelay);
            }
            else if (this.chkHeap.Checked)
            {
                return aStar.FindSolutionHeap(this.tree, 0, this.goal, mLimitDelay);
            }
            else if (this.chkHeapHashtable.Checked)
            {
                return aStar.FindSolutionHeapHashtable(this.tree, 0, this.goal, mLimitDelay);
            }
            else
            {
                throw new Exception("Find solution method not defined!");
            }
        }

        private void printDFS(Tree mTree, int start)
        {
            bool[] visited;

            visited = new bool[Tree.N];

            for (int i = 0; i < Tree.N; i++)
            {
                visited[i] = false;
            }

            DFS(mTree, start, visited);

            this.txtOutput.Text += "\r\n";
        }

        // Depth-first search
        private void DFS(Tree mTree, int v, bool[] visited)
        {
            visited[v] = true;

            foreach (Node node in mTree.edges[v].edge)
            {
                if (!visited[node.Vertex])
                {
                    this.txtOutput.Text += v + " " + node.Vertex + " (" + mTree.verticesDelay[node.Vertex] + ")\r\n";
                    DFS(mTree, node.Vertex, visited);
                }
            }
        }

        private void printDFSWolfram(Tree mTree, int start)
        {
            bool[] visited;
            visited = new bool[Tree.N];

            this.txtOutput.Text += "LayeredGraphPlot[\r\n{";

            for (int i = 0; i < Tree.N; i++)
            {
                visited[i] = false;
            }

            DFSWolfram(mTree, start, visited);

            this.txtOutput.Text = this.txtOutput.Text.Substring(0, this.txtOutput.Text.Length - 3) + "}, Left, VertexLabeling -> True]\r\n\r\n";
        }

        // Depth-first search
        private void DFSWolfram(Tree mTree, int v, bool[] visited)
        {
            visited[v] = true;

            foreach (Node node in mTree.edges[v].edge)
            {
                if (!visited[node.Vertex])
                {
                    this.txtOutput.Text += "{" + v + " -> " + node.Vertex + ", \"" + node.Weight + ", " + node.Delay + "\"},\r\n";
                    DFSWolfram(mTree, node.Vertex, visited);
                }
            }
        }

        private void buildTree()
        {
            string[] tmp, strEdge;
            int i;

            tmp = this.txtGoal.Text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            this.goal = new int[tmp.Length];

            for (i = 0; i < tmp.Length; i++)
            {
                this.goal[i] = Convert.ToInt32(tmp[i]);
            }

            Tree.N = Convert.ToInt32(txtNumberVertices.Text);
            this.tree = new Tree(0);

            tmp = this.txtEdge.Text.Split('|', (char)StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in tmp)
            {
                strEdge = str.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

                if (strEdge.Length != 4)
                {
                    MessageBox.Show("Error in definition of tree (" + str + ")");
                    Application.Exit();
                }

                this.tree.addEdge(Convert.ToInt32(strEdge[0]), Convert.ToInt32(strEdge[1]), Convert.ToInt32(strEdge[2]), Convert.ToInt32(strEdge[3]));
            }
        }

        private void btnAverageTime_Click(object sender, EventArgs e)
        {
            StopWatch sw = new StopWatch();
            AStar aStar = new AStar();
            Tree solution;
            int numberExecutions = Convert.ToInt32(this.txtNumberExecution.Text);
            string str;
            double average = 0.0f;

            if (chkSorting.Checked)
            {
                str = "Sorting\r\n";
            }
            else if (chkSortingHashtable.Checked)
            {
                str = "Sorting and Hashtable\r\n";
            }
            else if (chkHeap.Checked)
            {
                str = "Heap\r\n";
            }
            else if (chkHeapHashtable.Checked)
            {
                str = "Heap and Hashtable\r\n";
            }
            else
            {
                throw new Exception("Find solution method not defined!");
            }
            
            buildTree();

            sw.Start();
            aStar.FindSolutionHeap(this.tree, 0, this.goal);
            sw.Stop();
            sw.Reset();

            for (int i = 0; i < numberExecutions; i++)
            {
                if (chkSorting.Checked)
                {
                    sw.Start();
                    solution = aStar.FindSolutionSorting(this.tree, 0, this.goal);
                    sw.Stop();
                }
                else if (chkSortingHashtable.Checked)
                {
                    sw.Start();
                    solution = aStar.FindSolutionSortingHashtable(this.tree, 0, this.goal);
                    sw.Stop();
                }
                else if (chkHeap.Checked)
                {
                    sw.Start();
                    solution = aStar.FindSolutionHeap(this.tree, 0, this.goal);
                    sw.Stop();
                }
                else
                {
                    sw.Start();
                    solution = aStar.FindSolutionHeapHashtable(this.tree, 0, this.goal);
                    sw.Stop();
                }

                Console.WriteLine((sw.GetElapsedTimeInMicroseconds() / 1000).ToString());

                average += sw.GetElapsedTimeInMicroseconds();
                str += (sw.GetElapsedTimeInMicroseconds() / 1000).ToString() + "\r\n";
                sw.Reset();
            }

            this.txtOutput.Text += str + "\r\nAverage (ms): " + ((average / numberExecutions) / 1000).ToString() + "\r\n\r\n";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }
    }
}
