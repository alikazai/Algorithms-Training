using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList.Models
{
    internal class Node
    {
        public string Value { get; set; }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }

        public Node(string value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
