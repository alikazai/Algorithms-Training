using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Models
{
    internal class MyLinkedList
    {
        private Node? Head { get; set; }
        private Node? Tail { get; set; }
        private int Length { get; set; }

        public MyLinkedList(string value)
        {
            Head = new Node(value);
            Tail = Head;
            Length = 1;
        }

        public void Append(string value)
        {
            //const newNode = new Node(value);
            //this.tail.next = newNode;
            //this.tail = newNode;
            //this.length++;
        }

        public void Prepend(string value)
        {
            //const newNode = new Node(value);
            //newNode.next = this.head;
            //this.head = newNode;
            //this.length++;
        }

        public void PrintList()
        {
            //const array = [];
            //let currentNode = this.head;
            //while (currentNode !== null)
            //{
            //    array.push(currentNode.value);
            //    currentNode = currentNode.next;
            //}

            //return console.log(array);
        }

        public void Insert(int index, string value)
        {
            //if (index == 0)
            //{
            //    return this.prepend(value);
            //}

            //if (index >= this.length)
            //{
            //    return this.append(value);
            //}

            //const newNode = new Node(value);
            //const leader = this.traverseToIndex(index - 1);
            //const holdingPointer = leader.next;
            //leader.next = newNode;
            //newNode.next = holdingPointer;
            //this.length++;
        }

        public void Remove(int index)
        {
            //if (index == 0)
            //{
            //    return;
            //}

            //const leader = this.traverseToIndex(index - 1);
            //const unWantedNode = leader.next;
            //leader.next = unWantedNode.next;
            //this.length--;
        }

        private void TraverseToIndex(int index)
        {
            //let counter = 0;
            //let currentNode = this.head;
            //while (counter !== index)
            //{
            //    currentNode = currentNode.next;
            //    counter++;
            //}

            //return currentNode;
        }

        public void Reverse()
        {
            //if (!this.head.next)
            //{
            //    return this.head;
            //}

            //let currentNode = this.head;
            //const reverseList = new LinkedList(currentNode.value);
            //currentNode = currentNode.next;
            //while (currentNode !== null)
            //{
            //    reverseList.prepend(currentNode.value);
            //    currentNode = currentNode.next;
            //}

            //return reverseList.printList();
        }
    }
}