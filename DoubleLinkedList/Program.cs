using DoubleLinkedList.Model;

MyDoubleLinkedList myLinkedList = new("something");

myLinkedList.Append("1");
myLinkedList.Append("2");
myLinkedList.Append("3");
myLinkedList.Append("4");
myLinkedList.Append("5");
myLinkedList.Prepend("0");
Console.WriteLine(myLinkedList.PrintList());

Console.ReadKey();