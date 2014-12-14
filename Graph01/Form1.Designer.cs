namespace Graph
{
    partial class frmGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraph));
            this.btnSolution = new System.Windows.Forms.Button();
            this.txtGoal = new System.Windows.Forms.TextBox();
            this.lblGoal = new System.Windows.Forms.Label();
            this.lblNumberVertex = new System.Windows.Forms.Label();
            this.txtNumberVertices = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtEdge = new System.Windows.Forms.TextBox();
            this.btnPrintGraph = new System.Windows.Forms.Button();
            this.lblEdge = new System.Windows.Forms.Label();
            this.btnAverageTime = new System.Windows.Forms.Button();
            this.grbOption = new System.Windows.Forms.GroupBox();
            this.txtLimitDelay = new System.Windows.Forms.TextBox();
            this.lblLimitDelay = new System.Windows.Forms.Label();
            this.txtNumberExecution = new System.Windows.Forms.TextBox();
            this.lblNumerExecution = new System.Windows.Forms.Label();
            this.chkHeapHashtable = new System.Windows.Forms.RadioButton();
            this.chkHeap = new System.Windows.Forms.RadioButton();
            this.chkSortingHashtable = new System.Windows.Forms.RadioButton();
            this.chkSorting = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.grbOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSolution
            // 
            this.btnSolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolution.Location = new System.Drawing.Point(18, 12);
            this.btnSolution.Name = "btnSolution";
            this.btnSolution.Size = new System.Drawing.Size(114, 23);
            this.btnSolution.TabIndex = 0;
            this.btnSolution.Text = "Solution";
            this.btnSolution.UseVisualStyleBackColor = true;
            this.btnSolution.Click += new System.EventHandler(this.btnSolution_Click);
            // 
            // txtGoal
            // 
            this.txtGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGoal.Location = new System.Drawing.Point(371, 16);
            this.txtGoal.Name = "txtGoal";
            this.txtGoal.Size = new System.Drawing.Size(143, 20);
            this.txtGoal.TabIndex = 4;
            this.txtGoal.Text = "1 8 9 12 13";
            this.txtGoal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoal_KeyPress);
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Location = new System.Drawing.Point(331, 21);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(34, 13);
            this.lblGoal.TabIndex = 2;
            this.lblGoal.Text = "Goals";
            // 
            // lblNumberVertex
            // 
            this.lblNumberVertex.AutoSize = true;
            this.lblNumberVertex.Location = new System.Drawing.Point(206, 46);
            this.lblNumberVertex.Name = "lblNumberVertex";
            this.lblNumberVertex.Size = new System.Drawing.Size(72, 13);
            this.lblNumberVertex.TabIndex = 4;
            this.lblNumberVertex.Text = "N° of Vertices";
            // 
            // txtNumberVertices
            // 
            this.txtNumberVertices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumberVertices.Location = new System.Drawing.Point(284, 43);
            this.txtNumberVertices.Name = "txtNumberVertices";
            this.txtNumberVertices.Size = new System.Drawing.Size(41, 20);
            this.txtNumberVertices.TabIndex = 5;
            this.txtNumberVertices.Text = "15";
            this.txtNumberVertices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberVertices_KeyPress);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Location = new System.Drawing.Point(286, 142);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(246, 225);
            this.txtOutput.TabIndex = 5;
            this.txtOutput.DoubleClick += new System.EventHandler(this.txtOutput_DoubleClick);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(362, 115);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(73, 24);
            this.lblOutput.TabIndex = 6;
            this.lblOutput.Text = "Output";
            // 
            // txtEdge
            // 
            this.txtEdge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdge.Location = new System.Drawing.Point(12, 142);
            this.txtEdge.Multiline = true;
            this.txtEdge.Name = "txtEdge";
            this.txtEdge.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEdge.Size = new System.Drawing.Size(268, 225);
            this.txtEdge.TabIndex = 4;
            this.txtEdge.Text = resources.GetString("txtEdge.Text");
            this.txtEdge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEdge_KeyPress);
            // 
            // btnPrintGraph
            // 
            this.btnPrintGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintGraph.Location = new System.Drawing.Point(264, 12);
            this.btnPrintGraph.Name = "btnPrintGraph";
            this.btnPrintGraph.Size = new System.Drawing.Size(139, 23);
            this.btnPrintGraph.TabIndex = 2;
            this.btnPrintGraph.Text = "Print Graph";
            this.btnPrintGraph.UseVisualStyleBackColor = true;
            this.btnPrintGraph.Click += new System.EventHandler(this.btnPrintGraph_Click);
            // 
            // lblEdge
            // 
            this.lblEdge.AutoSize = true;
            this.lblEdge.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdge.Location = new System.Drawing.Point(118, 115);
            this.lblEdge.Name = "lblEdge";
            this.lblEdge.Size = new System.Drawing.Size(64, 24);
            this.lblEdge.TabIndex = 10;
            this.lblEdge.Text = "Edges";
            // 
            // btnAverageTime
            // 
            this.btnAverageTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAverageTime.Location = new System.Drawing.Point(138, 12);
            this.btnAverageTime.Name = "btnAverageTime";
            this.btnAverageTime.Size = new System.Drawing.Size(120, 23);
            this.btnAverageTime.TabIndex = 1;
            this.btnAverageTime.Text = "Average Time";
            this.btnAverageTime.UseVisualStyleBackColor = true;
            this.btnAverageTime.Click += new System.EventHandler(this.btnAverageTime_Click);
            // 
            // grbOption
            // 
            this.grbOption.Controls.Add(this.txtLimitDelay);
            this.grbOption.Controls.Add(this.lblLimitDelay);
            this.grbOption.Controls.Add(this.txtNumberExecution);
            this.grbOption.Controls.Add(this.lblNumerExecution);
            this.grbOption.Controls.Add(this.chkHeapHashtable);
            this.grbOption.Controls.Add(this.chkHeap);
            this.grbOption.Controls.Add(this.chkSortingHashtable);
            this.grbOption.Controls.Add(this.chkSorting);
            this.grbOption.Controls.Add(this.txtGoal);
            this.grbOption.Controls.Add(this.lblGoal);
            this.grbOption.Controls.Add(this.txtNumberVertices);
            this.grbOption.Controls.Add(this.lblNumberVertex);
            this.grbOption.Location = new System.Drawing.Point(12, 41);
            this.grbOption.Name = "grbOption";
            this.grbOption.Size = new System.Drawing.Size(520, 71);
            this.grbOption.TabIndex = 3;
            this.grbOption.TabStop = false;
            this.grbOption.Text = "Options";
            // 
            // txtLimitDelay
            // 
            this.txtLimitDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLimitDelay.Enabled = false;
            this.txtLimitDelay.Location = new System.Drawing.Point(284, 16);
            this.txtLimitDelay.MaxLength = 4;
            this.txtLimitDelay.Name = "txtLimitDelay";
            this.txtLimitDelay.Size = new System.Drawing.Size(41, 20);
            this.txtLimitDelay.TabIndex = 8;
            this.txtLimitDelay.Text = "30";
            this.txtLimitDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimitDelay_KeyPress);
            // 
            // lblLimitDelay
            // 
            this.lblLimitDelay.AutoSize = true;
            this.lblLimitDelay.Location = new System.Drawing.Point(206, 21);
            this.lblLimitDelay.Name = "lblLimitDelay";
            this.lblLimitDelay.Size = new System.Drawing.Size(58, 13);
            this.lblLimitDelay.TabIndex = 7;
            this.lblLimitDelay.Text = "Limit Delay";
            this.lblLimitDelay.Click += new System.EventHandler(this.lblLimitDelay_Click);
            // 
            // txtNumberExecution
            // 
            this.txtNumberExecution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumberExecution.Location = new System.Drawing.Point(472, 42);
            this.txtNumberExecution.Name = "txtNumberExecution";
            this.txtNumberExecution.Size = new System.Drawing.Size(42, 20);
            this.txtNumberExecution.TabIndex = 6;
            this.txtNumberExecution.Text = "5";
            this.txtNumberExecution.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberExecution_KeyPress);
            // 
            // lblNumerExecution
            // 
            this.lblNumerExecution.AutoSize = true;
            this.lblNumerExecution.Location = new System.Drawing.Point(331, 46);
            this.lblNumerExecution.Name = "lblNumerExecution";
            this.lblNumerExecution.Size = new System.Drawing.Size(135, 13);
            this.lblNumerExecution.TabIndex = 6;
            this.lblNumerExecution.Text = "N° of Executions (Average)";
            // 
            // chkHeapHashtable
            // 
            this.chkHeapHashtable.AutoSize = true;
            this.chkHeapHashtable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeapHashtable.Location = new System.Drawing.Point(70, 43);
            this.chkHeapHashtable.Name = "chkHeapHashtable";
            this.chkHeapHashtable.Size = new System.Drawing.Size(122, 17);
            this.chkHeapHashtable.TabIndex = 3;
            this.chkHeapHashtable.Text = "Heap and Hashtable";
            this.chkHeapHashtable.UseVisualStyleBackColor = true;
            // 
            // chkHeap
            // 
            this.chkHeap.AutoSize = true;
            this.chkHeap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHeap.Location = new System.Drawing.Point(6, 43);
            this.chkHeap.Name = "chkHeap";
            this.chkHeap.Size = new System.Drawing.Size(50, 17);
            this.chkHeap.TabIndex = 2;
            this.chkHeap.Text = "Heap";
            this.chkHeap.UseVisualStyleBackColor = true;
            // 
            // chkSortingHashtable
            // 
            this.chkSortingHashtable.AutoSize = true;
            this.chkSortingHashtable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSortingHashtable.Location = new System.Drawing.Point(70, 19);
            this.chkSortingHashtable.Name = "chkSortingHashtable";
            this.chkSortingHashtable.Size = new System.Drawing.Size(129, 17);
            this.chkSortingHashtable.TabIndex = 1;
            this.chkSortingHashtable.Text = "Sorting and Hashtable";
            this.chkSortingHashtable.UseVisualStyleBackColor = true;
            // 
            // chkSorting
            // 
            this.chkSorting.AutoSize = true;
            this.chkSorting.Checked = true;
            this.chkSorting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSorting.Location = new System.Drawing.Point(6, 19);
            this.chkSorting.Name = "chkSorting";
            this.chkSorting.Size = new System.Drawing.Size(57, 17);
            this.chkSorting.TabIndex = 0;
            this.chkSorting.TabStop = true;
            this.chkSorting.Text = "Sorting";
            this.chkSorting.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(409, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 379);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grbOption);
            this.Controls.Add(this.btnAverageTime);
            this.Controls.Add(this.lblEdge);
            this.Controls.Add(this.btnPrintGraph);
            this.Controls.Add(this.txtEdge);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSolution);
            this.Name = "frmGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph";
            this.grbOption.ResumeLayout(false);
            this.grbOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolution;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Label lblNumberVertex;
        private System.Windows.Forms.TextBox txtNumberVertices;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtEdge;
        private System.Windows.Forms.Button btnPrintGraph;
        private System.Windows.Forms.Label lblEdge;
        private System.Windows.Forms.Button btnAverageTime;
        private System.Windows.Forms.GroupBox grbOption;
        private System.Windows.Forms.RadioButton chkHeapHashtable;
        private System.Windows.Forms.RadioButton chkHeap;
        private System.Windows.Forms.RadioButton chkSortingHashtable;
        private System.Windows.Forms.RadioButton chkSorting;
        private System.Windows.Forms.TextBox txtNumberExecution;
        private System.Windows.Forms.Label lblNumerExecution;
        private System.Windows.Forms.TextBox txtLimitDelay;
        private System.Windows.Forms.Label lblLimitDelay;
        private System.Windows.Forms.Button btnClear;
    }
}

