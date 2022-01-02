using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Model
{
    internal class MyQueue
    {
        public Node? First { get; set; }
        public Node? Last { get; set; }
        public int Length { get; set; }

        public MyQueue()
        {
            First = null;
            Last = null;
            Length = 0;
        }

        public Node? Peek()
        {
            return First;
        }

        public Node Enqueue(string value)
        {
            Node? newNode = new Node(value);
            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last= newNode;
            }

            Length++;
            return newNode;
        }

        public Node? Dequeue()
        {
            if (First == null)
                return null;

            if(First == Last)
                Last = null;

            First = First.Next;
            Length--;
            return First;
        }

        private bool IsEmpty()
        {
            if (Length == 0)
                return true;

            return false;
        }
    }
}
