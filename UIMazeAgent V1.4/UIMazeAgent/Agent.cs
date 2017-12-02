using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UIMazeAgent
{
    public class Agent
    {
        private int _row;
        private int _col;
        private int[] AgentGoal;
        private double _JarakTempuh;
        public Queue<ArenaMaze> brainMemoryProcess;
        public Stack<ArenaMaze> Fringe_stack;
        public Queue<ArenaMaze> Fringe;
        //property
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }
        public Agent(int[] goal)
        {
            this.Row = 1;
            this.Col = 1;
            this.AgentGoal = goal;
            
        }
        public Agent(int row, int col)
        {
            this._row=row;
            this._col = col;
           
        }
        //----------------------------------------------
        //general methods for agent
        public bool isAgentGoal()
        {
            if (this.Row == AgentGoal[0] && this.Col == AgentGoal[1])
                return true;
            else
                return false;
        }
        public bool isAgentGoal(int row,int col)
        {
            if (row == AgentGoal[0] && col == AgentGoal[1])
                return true;
            else
                return false;
        }
        public ArenaMaze minimalHeuristik(List<ArenaMaze> nodes)
        {
            ArenaMaze tmp = nodes[0];
            foreach (ArenaMaze item in nodes)
            {
                if (item.Heuristik < tmp.Heuristik)
                { tmp = item; }
            }
            return tmp;
        }
        //----------------------------------------------
        //agent methods for simple movement !!!
        // Agent Sensors !!!!!!
        public bool checkKanan(ArenaMaze[,] arenaMaze)
        {
            
            if (arenaMaze[this.Row, this.Col + 1].Status != false)
                return true;
            else
                return false;
        }
        public bool checkBawah(ArenaMaze[,] arenaMaze)
        {
            if (arenaMaze[this.Row + 1, this.Col].Status != false)
                return true;
            else
                return false;
        }
        public bool checkKiri(ArenaMaze[,] arenaMaze)
        {
            if (arenaMaze[this.Row, this.Col - 1].Status != false)
                return true;
            else
                return false;
        }
        public bool checkAtas(ArenaMaze[,] arenaMaze)
        {

            if (arenaMaze[this.Row - 1, this.Col].Status != false)
                return true;
            else
                return false;
        }
        //fungsi expand adalah fungsi dimana fungsi akan me return semua node yang berhubungan dengan tempat dimana agent berdiri
        private List<ArenaMaze> expand(int row, int col,ArenaMaze[,] arenaMaze)
        {
            //defining the agent position
            this._row = row;//nodeTmp.Row;
            this._col = col;// nodeTmp.Col;
            arenaMaze[this._row, this._col].Status = false;
            //defining the agent position
            List<ArenaMaze> tmp = new List<ArenaMaze>();
            if (arenaMaze[this._row, this._col + 1].Status == true)
            {
                arenaMaze[this._row, this._col + 1].Head = arenaMaze[this._row, this._col];
                tmp.Add(arenaMaze[this._row, this._col + 1]);
            }
            if (arenaMaze[this._row + 1, this._col].Status == true)
            {
                arenaMaze[this._row + 1, this._col].Head = arenaMaze[this._row, this._col];
                tmp.Add(arenaMaze[this._row + 1, this._col]);

            }
            if (arenaMaze[this._row, this._col - 1].Status == true)
            {
                arenaMaze[this._row, this._col - 1].Head = arenaMaze[this._row, this._col];
                tmp.Add(arenaMaze[this._row, this._col - 1]);
            }
            if (arenaMaze[this._row - 1, this._col].Status == true)
            {
                arenaMaze[this._row - 1, this._col].Head = arenaMaze[this._row, this._col];
                tmp.Add(arenaMaze[this._row - 1, this._col]);
            }
            return tmp;
        }
        //----------------------------------------------
        //those methods return some solution that've been thinked by the agent and if agent can't resolve agent will show the message
        //Simple Refflect Agent Methods!!!
        public Queue<ArenaMaze> SimpleRefflectAgent(ArenaMaze[,] Environment)
        {
            /*IS : This Method Recieve An Environment to be analysed by agen to find a path to go trought the goal with simple refflect
             *FS : This Method Return An Action to be performed on Environment
             *Created By : Noverio Joe (Von)
             * 
             */
            brainMemoryProcess = new Queue<ArenaMaze>(100);//as a List Of Actions
            bool isStuck = false;
            while (isStuck == false)
            {
                if (this.isAgentGoal() || (this._row + 1 == AgentGoal[0] && this._col==AgentGoal[1]) || (this._col + 1 == AgentGoal[1]&&this._row==AgentGoal[0]) || (this._col - 1 == AgentGoal[1]&&this._row==AgentGoal[0]) || (this._row - 1 == AgentGoal[0]&&this._col==AgentGoal[1]))
                {
                    MessageBox.Show("Succeed");
                    isStuck = true;
                }
                else
                {
                    Environment[this._row, this._col].Status = false;
                    if (this.checkKanan(Environment) == true)
                    {
                        this.brainMemoryProcess.Enqueue(Environment[this._row, this._col + 1]);
                        this._col++;
                    }
                    else if (this.checkBawah(Environment) == true)
                    {
                        this.brainMemoryProcess.Enqueue(Environment[this._row+1, this._col]);
                        this._row++;
                    }
                    else if (this.checkKiri(Environment) == true)
                    {
                        this.brainMemoryProcess.Enqueue(Environment[this._row, this._col-1]);
                        this._col--;
                    }
                    else if (this.checkAtas(Environment) == true)
                    {
                        this.brainMemoryProcess.Enqueue(Environment[this._row - 1, this._col]);
                        this._row--;
                    }
                    else
                    {
                        MessageBox.Show("Agent Stuck on coordinate X,Y = " + this._row + "," + this._col );
                        isStuck = true;
                    }
                }
            }
            return brainMemoryProcess;
        }
        //DeepFirsth algorithm Methods!!! 
        public Queue<ArenaMaze> DFSAlgorithm(ArenaMaze[,] Environment)
        {
            brainMemoryProcess = new Queue<ArenaMaze>(50);
            Fringe_stack = new Stack<ArenaMaze>(100);
            bool isEnd = false;
            ArenaMaze nodeTemp;
            Fringe_stack.Push(Environment[1,1]);
            while (isEnd==false)
            {
                if (Fringe_stack.Count<=0)
                {
                    isEnd = true;
                    MessageBox.Show("Does Not Resolve");
                }
                else
                {
                    nodeTemp=Fringe_stack.Pop();
                    brainMemoryProcess.Enqueue(nodeTemp);
                    if (this.isAgentGoal(nodeTemp.Row,nodeTemp.Col))
                    {
                        isEnd = true;
                        
                        MessageBox.Show("Succeed");
                    }
                    else
                    {
                        foreach (ArenaMaze item in expand(nodeTemp.Row, nodeTemp.Col, Environment))
                        { this.Fringe_stack.Push(item); }
                    } 
                }
            }
            return brainMemoryProcess;
        }
        //BreadthFirst algorithm
        public Queue<ArenaMaze> BFSAlgorithm(ArenaMaze[,] Environment)
        {
            Fringe = new Queue<ArenaMaze>(100);
            brainMemoryProcess = new Queue<ArenaMaze>(50);
            bool isEnd = false;
            ArenaMaze nodeTemp;
            Fringe.Enqueue(Environment[1, 1]);
            while (isEnd==false)
            {
                if (Fringe.Count<=0)
                {
                    isEnd = true;
                    MessageBox.Show("Does Not Resolve");
                }
                else
                {
                    nodeTemp = Fringe.Dequeue();
                    brainMemoryProcess.Enqueue(nodeTemp);
                    if (this.isAgentGoal(nodeTemp.Row, nodeTemp.Col))
                    {
                        isEnd = true;
                        MessageBox.Show("Succeed");
                    }
                    else
                    {
                        foreach (ArenaMaze item in expand(nodeTemp.Row,nodeTemp.Col,Environment))
                        {
                            this.Fringe.Enqueue(item);
                        }
                    }
                }
            }
            
            return brainMemoryProcess;
        }
        //Greedy algorithm
        public Queue<ArenaMaze> GreedyAlgorithm(ArenaMaze[,] Environment)
        {
            brainMemoryProcess = new Queue<ArenaMaze>(50);
            List<ArenaMaze> myQueue = new List<ArenaMaze>(200);
            bool isEnd = false;
            ArenaMaze nodeTemp;
            myQueue.Add(Environment[1, 1]);
            Queue<ArenaMaze> queue = new Queue<ArenaMaze>(50);
            while (isEnd == false)
            {
                if (myQueue.Count == 0)
                {
                    isEnd = true;
                    MessageBox.Show("Does Not Resolve");
                }
                else
                {
                    nodeTemp = myQueue.OrderBy(x => x.Heuristik).ToList()[0];
                    //nodeTemp = myQueue.ToList()[0];
                    brainMemoryProcess.Enqueue(nodeTemp);
                    myQueue.Remove(nodeTemp);
                    if (this.isAgentGoal(nodeTemp.Row, nodeTemp.Col))
                    {
                        isEnd = true;
                        MessageBox.Show("Succeed");
                    }
                    else
                    {
                        foreach (ArenaMaze item in expand(nodeTemp.Row, nodeTemp.Col, Environment))
                        { myQueue.Add(item); }
                    }
                }
            }
            return brainMemoryProcess;
        }
        //A* algorithm
        public Queue<ArenaMaze> AStarAlgorithm(ArenaMaze[,] Environment)
        {
            this._JarakTempuh = 0;
            brainMemoryProcess = new Queue<ArenaMaze>(50);
            List<ArenaMaze> myQueue = new List<ArenaMaze>(200);

            bool isEnd = false;
            ArenaMaze nodeTemp;

            myQueue.Add(Environment[1, 1]);
            
            while (isEnd == false)
            {
                if (myQueue.Count == 0)
                {
                    isEnd = true;
                    MessageBox.Show("Does Not Resolve");
                }
                else
                {
                    nodeTemp = myQueue.OrderBy(x => x.Heuristik+this._JarakTempuh).ToList()[0];
                    this._JarakTempuh += nodeTemp.Heuristik;
                    brainMemoryProcess.Enqueue(nodeTemp);
                    myQueue.Remove(nodeTemp);
                    if (this.isAgentGoal(nodeTemp.Row, nodeTemp.Col))
                    {
                        isEnd = true;
                        MessageBox.Show("Succeed");
                    }
                    else
                    {
                        foreach (ArenaMaze item in expand(nodeTemp.Row, nodeTemp.Col, Environment))
                        {
                            myQueue.Add(item); 
                        }
                        this._JarakTempuh += nodeTemp.Heuristik ;
                    }
                }
            }
            return brainMemoryProcess;
        }
    }
}
