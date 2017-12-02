namespace UIMazeAgent
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenerateMaze_BT = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Keterangan_Label = new System.Windows.Forms.Label();
            this.Start_bt = new System.Windows.Forms.Button();
            this.GreedyAlgorithm = new System.Windows.Forms.RadioButton();
            this.SimpleReflectAlgorithm = new System.Windows.Forms.RadioButton();
            this.BreadthFirstAlgorithm = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DFSAlgorithm = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AStarAlgorithm = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 371);
            this.panel1.TabIndex = 0;
            // 
            // GenerateMaze_BT
            // 
            this.GenerateMaze_BT.Location = new System.Drawing.Point(6, 19);
            this.GenerateMaze_BT.Name = "GenerateMaze_BT";
            this.GenerateMaze_BT.Size = new System.Drawing.Size(152, 23);
            this.GenerateMaze_BT.TabIndex = 1;
            this.GenerateMaze_BT.Text = "Generate Maze";
            this.GenerateMaze_BT.UseVisualStyleBackColor = true;
            this.GenerateMaze_BT.Click += new System.EventHandler(this.GenerateMaze_BT_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Keterangan_Label
            // 
            this.Keterangan_Label.AutoSize = true;
            this.Keterangan_Label.Location = new System.Drawing.Point(12, 17);
            this.Keterangan_Label.Name = "Keterangan_Label";
            this.Keterangan_Label.Size = new System.Drawing.Size(87, 13);
            this.Keterangan_Label.TabIndex = 3;
            this.Keterangan_Label.Text = "Coordinate X,Y =";
            // 
            // Start_bt
            // 
            this.Start_bt.Location = new System.Drawing.Point(6, 138);
            this.Start_bt.Name = "Start_bt";
            this.Start_bt.Size = new System.Drawing.Size(152, 23);
            this.Start_bt.TabIndex = 4;
            this.Start_bt.Text = "View Proccess";
            this.Start_bt.UseVisualStyleBackColor = true;
            this.Start_bt.Click += new System.EventHandler(this.Start_bt_Click);
            // 
            // GreedyAlgorithm
            // 
            this.GreedyAlgorithm.AutoSize = true;
            this.GreedyAlgorithm.Location = new System.Drawing.Point(6, 88);
            this.GreedyAlgorithm.Name = "GreedyAlgorithm";
            this.GreedyAlgorithm.Size = new System.Drawing.Size(112, 17);
            this.GreedyAlgorithm.TabIndex = 6;
            this.GreedyAlgorithm.TabStop = true;
            this.GreedyAlgorithm.Text = "Greedy Movement";
            this.GreedyAlgorithm.UseVisualStyleBackColor = true;
            this.GreedyAlgorithm.CheckedChanged += new System.EventHandler(this.GreedyAlgorithm_CheckedChanged);
            // 
            // SimpleReflectAlgorithm
            // 
            this.SimpleReflectAlgorithm.AutoSize = true;
            this.SimpleReflectAlgorithm.Location = new System.Drawing.Point(6, 19);
            this.SimpleReflectAlgorithm.Name = "SimpleReflectAlgorithm";
            this.SimpleReflectAlgorithm.Size = new System.Drawing.Size(93, 17);
            this.SimpleReflectAlgorithm.TabIndex = 7;
            this.SimpleReflectAlgorithm.TabStop = true;
            this.SimpleReflectAlgorithm.Text = "Simple Reflect";
            this.SimpleReflectAlgorithm.UseVisualStyleBackColor = true;
            this.SimpleReflectAlgorithm.CheckedChanged += new System.EventHandler(this.SimpleReflectAlgorithm_CheckedChanged);
            // 
            // BreadthFirstAlgorithm
            // 
            this.BreadthFirstAlgorithm.AutoSize = true;
            this.BreadthFirstAlgorithm.Location = new System.Drawing.Point(6, 42);
            this.BreadthFirstAlgorithm.Name = "BreadthFirstAlgorithm";
            this.BreadthFirstAlgorithm.Size = new System.Drawing.Size(143, 17);
            this.BreadthFirstAlgorithm.TabIndex = 8;
            this.BreadthFirstAlgorithm.TabStop = true;
            this.BreadthFirstAlgorithm.Text = "BFS Algorithm movement";
            this.BreadthFirstAlgorithm.UseVisualStyleBackColor = true;
            this.BreadthFirstAlgorithm.CheckedChanged += new System.EventHandler(this.BreadthFirstAlgorithm_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AStarAlgorithm);
            this.groupBox1.Controls.Add(this.DFSAlgorithm);
            this.groupBox1.Controls.Add(this.SimpleReflectAlgorithm);
            this.groupBox1.Controls.Add(this.GreedyAlgorithm);
            this.groupBox1.Controls.Add(this.BreadthFirstAlgorithm);
            this.groupBox1.Controls.Add(this.Start_bt);
            this.groupBox1.Location = new System.Drawing.Point(525, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 172);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithm";
            // 
            // DFSAlgorithm
            // 
            this.DFSAlgorithm.AutoSize = true;
            this.DFSAlgorithm.Location = new System.Drawing.Point(6, 65);
            this.DFSAlgorithm.Name = "DFSAlgorithm";
            this.DFSAlgorithm.Size = new System.Drawing.Size(145, 17);
            this.DFSAlgorithm.TabIndex = 9;
            this.DFSAlgorithm.TabStop = true;
            this.DFSAlgorithm.Text = "DFS Algorithm Movement";
            this.DFSAlgorithm.UseVisualStyleBackColor = true;
            this.DFSAlgorithm.CheckedChanged += new System.EventHandler(this.DFSAlgorithm_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GenerateMaze_BT);
            this.groupBox2.Location = new System.Drawing.Point(525, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 57);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Maze";
            // 
            // AStarAlgorithm
            // 
            this.AStarAlgorithm.AutoSize = true;
            this.AStarAlgorithm.Location = new System.Drawing.Point(6, 111);
            this.AStarAlgorithm.Name = "AStarAlgorithm";
            this.AStarAlgorithm.Size = new System.Drawing.Size(82, 17);
            this.AStarAlgorithm.TabIndex = 16;
            this.AStarAlgorithm.TabStop = true;
            this.AStarAlgorithm.Text = "A* Algorithm";
            this.AStarAlgorithm.UseVisualStyleBackColor = true;
            this.AStarAlgorithm.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 556);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Keterangan_Label);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "MazePIB";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GenerateMaze_BT;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Keterangan_Label;
        private System.Windows.Forms.Button Start_bt;
        private System.Windows.Forms.RadioButton GreedyAlgorithm;
        private System.Windows.Forms.RadioButton SimpleReflectAlgorithm;
        private System.Windows.Forms.RadioButton BreadthFirstAlgorithm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton DFSAlgorithm;
        private System.Windows.Forms.RadioButton AStarAlgorithm;
    }
}

