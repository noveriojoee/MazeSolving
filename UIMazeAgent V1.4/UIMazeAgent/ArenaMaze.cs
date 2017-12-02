using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace UIMazeAgent
{
    public class ArenaMaze:Label
    {
        private bool _status;
        private int _row;
        private int _col;
        private double _heuristik;
        private ArenaMaze _head;

        //Property Encapsulate
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public ArenaMaze Head
        {
            get { return _head; }
            set { _head = value; }
        }
        public int Row
        {
            get { return _row; }
        }
        public int Col
        {
            get { return _col; }         
        }
        public double Heuristik
        {
            get { return _heuristik; }
            set { _heuristik = value; }
        }
        public ArenaMaze(int row,int col,int goalRow,int goalCol)
        {
            this._status = true;
            this._row = row;
            this._col = col;
            this._heuristik = Math.Sqrt(Math.Pow((goalRow - row), 2) + Math.Pow((goalCol - col), 2));
        }
    }
}
