using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIMazeAgent
{
    public class myQueue
    {
        //public myQueue(int capacity) : base(capacity) { }
        private ArenaMaze[] queue;
        private int _head;
        private int _length;
        private int _tail;
        public int Tail
        {
            get { return _tail; }
            set 
            {
                if (_tail == _length)
                {
                    _tail = 0;
                }
                else if (_tail+1==_head)
                {
                    System.Windows.Forms.MessageBox.Show("Tail Penuh");
                }
                else
                {
                    _tail = value;    
                }

            }
        }

        public int Head
        {
            get { return _head; }
            set {
                if (_head == _length)
                {
                    _head = 0;
                }
                else
                {
                    _head = value;
                }
            }
        }
        public myQueue(int capacity)
        {
            queue = new ArenaMaze[capacity];
            _length = capacity;
            _head = 0;
            _tail = 0;
        }
        public void enqueue(ArenaMaze x)
        {
            queue[_tail] = x;
            _tail++;
        }
        public ArenaMaze dequeue()
        {
            _head++;
            return queue[_head-1];
        }
        
        //public void reOrderQueue()
        //{
        //  forea
                       
        //}
        
    }
}
