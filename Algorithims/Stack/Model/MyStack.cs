using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Model
{
    internal class MyStack
    {
        public Node? Top { get; set; }
        public Node? Bottom { get; set; }
        public int Length { get; set; }

        public MyStack()
        {
            Top = null;
            Bottom = null;
            Length = 0;
        }

        public Node? Peek()
        {
            return Top;
        }

        public Node Push(string value)
        {
            Node? newNode = new Node(value);
            if (IsEmpty())
            {
                Top = newNode;
                Bottom = newNode;
            }
            else
            {
                Node? holdingPointer = Top;
                Top = newNode;
                Top.Next = holdingPointer;
            }

            Length++;
            return Top;
        }

        public Node? Pop()
        {
            if (Top == null)
                return null;

            if(Top == Bottom)
                Bottom = null;

            Top = Top.Next;
            Length--;
            return Top;
        }

        private bool IsEmpty()
        {
            if (Length == 0)
                return true;

            return false;
        }
    }
}
