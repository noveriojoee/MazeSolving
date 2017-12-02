using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIMazeAgent
{
    public partial class Form1 : Form
    {

        const int RMAX = 10;
        const int CMAX = 10;
        int[] Goal = new int[2];
        int[] Start = new int[2];
        int counter = 0;
        ArenaMaze[,] arenaMaze= new ArenaMaze[RMAX, CMAX];
        Random rd = new Random();
        Queue<ArenaMaze> Fringe = new Queue<ArenaMaze>(50);
        Queue<ArenaMaze> movements = new Queue<ArenaMaze>(100);
          Stack<ArenaMaze> movementsList = new Stack<ArenaMaze>(100);//untuk men trace back jalur yang lebih effisien untuk di lewati dari goal ke start
        Agent agen;
        public Form1()
        {
            InitializeComponent();
            GenerateArena();
            Start_bt.Enabled = false;
            SimpleReflectAlgorithm.Checked=false;
            BreadthFirstAlgorithm.Checked = false;
            DFSAlgorithm.Checked = false;
            GreedyAlgorithm.Checked = false;
            AStarAlgorithm.Checked = true;
        }
        private void MarkRoute_Click(object sender, EventArgs e)
        {MarkingRoute();}
        private void GenerateMaze_BT_Click(object sender, EventArgs e)
        {
            Fringe.Clear();
            movementsList.Clear();
            movements.Clear();
            RemovePanel();
            GenerateArena();
            SimpleReflectAlgorithm.Checked = false;
            BreadthFirstAlgorithm.Checked = false;
            DFSAlgorithm.Checked = false;
            GreedyAlgorithm.Checked = false;
            AStarAlgorithm.Checked = false;
            Start_bt.Enabled = false;
            int counter = 0;
            while (counter < 17)
            {
                int value1 = rd.Next(1, CMAX-1);
                int value2 = rd.Next(1, CMAX-1);
                if (arenaMaze[value1, value2].Status.Equals(true) && (value1 != Goal[0] || value2 != Goal[1]) && (value1 != 1 || value2 != 1))
                {
                    arenaMaze[value1, value2].Status = false;
                    arenaMaze[value1, value2].BackColor = Color.Black;
                    counter++;
                }
            }
        }
        private void Start_bt_Click(object sender, EventArgs e)
        {timer1.Start();} 
        private void timer1_Tick(object sender, EventArgs e)
        {
            ArenaMaze tmp = movements.Dequeue();
            arenaMaze[tmp.Row, tmp.Col].BackColor = Color.Gold;
            arenaMaze[tmp.Row, tmp.Col].Text = (this.counter++).ToString();
            Keterangan_Label.Text = "Coordinate Y,X =" + tmp.Row + "," + tmp.Col;
            if (agen.isAgentGoal(tmp.Row,tmp.Col)||movements.Count<=0)
            {
                traceBack(arenaMaze[tmp.Row, tmp.Col]);
                MarkingRoute();
                timer1.Stop(); this.counter = 0; 
            }
            
        }
        //memasukan jalur yang effisien ke stack
        private void traceBack(ArenaMaze nodeTmp)
        {
            ArenaMaze x;
            while (nodeTmp.Head != null)
            {
                movementsList.Push(nodeTmp);
                x = nodeTmp.Head;
                nodeTmp = x;
            }
        }
        //making route adalah fungsi dimana fungsi ini akan mengeluarkan isi stack dan menampilkan jalur yang di lewati agent di maze
        private void MarkingRoute()
        {
            ArenaMaze x; int count = 0;
            while (movementsList.Count > 0)
            {
                x = movementsList.Pop();
                arenaMaze[x.Row, x.Col].Text = (count++).ToString();
                arenaMaze[x.Row, x.Col].BackColor = Color.Brown;
            }
        }
        #region methods visuality
        private void GenerateArena()
        {
            Start[0] = 1; Start[1] = 1;
            Goal[0] = rd.Next(2, 8); Goal[1] = rd.Next(2, 8);
            for (int row = 0; row < RMAX; row++)
            {
                for (int col = 0; col < CMAX; col++)
                {
                    arenaMaze[row, col] = new ArenaMaze(row,col,Goal[0],Goal[1]);
                    arenaMaze[row, col].ForeColor = Color.Red;
                    arenaMaze[row, col].BackColor = Color.Silver;
                    arenaMaze[row, col].Size = new Size(49, 49);
                    arenaMaze[row, col].Location = new Point(col * 50, row * 50);
                    panel1.Controls.Add(arenaMaze[row, col]);
                    if (row == 0 || col == 0 || col == CMAX - 1 || row == CMAX - 1)
                    {
                        arenaMaze[row, col].BackColor = Color.Red;
                        arenaMaze[row, col].Status = false;
                    }
                    else if ((row == 1 && col == 1) || (row == Goal[0] && col == Goal[1]))
                    {
                        arenaMaze[row, col].BackColor = Color.Green;
                    }
                }
            }
            agen = new Agent(Goal);
            arenaMaze[Start[0], Start[1]].Head = null;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Size = new Size(50 * CMAX, 50 * RMAX);
            panel1.ForeColor = Color.Black;

        }
        private void RemovePanel()
        {
            for (int i = 0; i < RMAX; i++)
            {
                for (int z = 0; z < CMAX; z++)
                { panel1.Controls.Remove(arenaMaze[i, z]); }
            }
        }
        #endregion
        
        private void SimpleReflectAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            if (SimpleReflectAlgorithm.Checked == true)
            {
                this.movements = agen.SimpleRefflectAgent(this.arenaMaze);
                Start_bt.Enabled = true;
            }
        }
        private void DFSAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            if (DFSAlgorithm.Checked==true)
            {
                this.movements=agen.DFSAlgorithm(this.arenaMaze);
                
                Start_bt.Enabled = true;
            }
        }
        private void BreadthFirstAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            if (BreadthFirstAlgorithm.Checked==true)
            {
                this.movements = agen.BFSAlgorithm(this.arenaMaze);
                Start_bt.Enabled = true;
            }
        }
        private void GreedyAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            if (GreedyAlgorithm.Checked == true)
            {
                this.movements = agen.GreedyAlgorithm(this.arenaMaze);
                Start_bt.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (AStarAlgorithm.Checked==true)
            {
                this.movements = agen.AStarAlgorithm(this.arenaMaze);
                Start_bt.Enabled = true;
            }
        }

       
        

      
       

        









    }
}
