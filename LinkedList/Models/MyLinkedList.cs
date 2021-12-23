using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LinkedList.Models
{
    internal class MyLinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }
        private int Length { get; set; }

        public MyLinkedList(string value)
        {
            Head = new Node(value);
            Tail = Head;
            Length = 1;
        }

        public void Append(string value)
        {
            Node newNode = new Node(value);
            Tail.Next = newNode;
            Tail = newNode;
            Length++;
        }

        public void Prepend(string value)
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
            Length++;
        }

        public String PrintList()
        {
            List<string> list = new List<string>();
            Node? currentNode = Head;
            while (currentNode != null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return JsonSerializer.Serialize(list.ToArray());
        }

        public void Insert(int index, string value)
        {
            if (index == 0)
            {
                Prepend(value);
                return;
            }

            if(index >= Length)
            {

                Append(value);
                return;
            }

            Node? newNode = new Node(value);
            Node? leader = TraverseToIndex(index - 1);
            Node? holdingPointer = leader.Next;
            leader.Next = newNode;
            newNode.Next = holdingPointer;
            Length++;
        }

        public void Remove(int index)
        {
            if (index == 0)
                return;

            Node? leader = TraverseToIndex(index - 1);
            Node? unwantedNode = leader.Next;
            leader.Next = unwantedNode.Next;
            Length--;
        }

        private Node? TraverseToIndex(int index)
        {
            int counter = 0;
            Node? currentNode = Head;
            while (counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }

            return currentNode;
        }

        public MyLinkedList Reverse()
        {
            if (Head.Next == null)
                return this;

            Node? currentNode = Head;
            MyLinkedList reverseList = new MyLinkedList(currentNode.Value);
            currentNode = currentNode.Next;
            while(currentNode != null)
            {
                reverseList.Prepend(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return reverseList;
        }
    }
}