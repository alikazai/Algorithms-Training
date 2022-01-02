using LinkedList.Models;

MyLinkedList myLinkedList = new("something");

myLinkedList.Append("1");
myLinkedList.Append("2");
myLinkedList.Append("3");
myLinkedList.Append("4");
myLinkedList.Append("5");
myLinkedList.Prepend("0");
var list = myLinkedList.Reverse();
Console.WriteLine(myLinkedList.PrintList());
Console.WriteLine(list.PrintList());

Console.ReadKey();