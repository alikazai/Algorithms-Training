using Queue.Model;

MyQueue myQueue = new();

// ENQUEUE
// Jon (0) - James (1) - Jack -(2)
/*
0 - Jon { value:"jon", next: "james"} //first
1 - James { value:"james", next: "jack"}
2 - Jack { value:"jack", next: "jane"}
3 - Jane { value:"jane", next: null} //last
*/
myQueue.Enqueue("jon");
myQueue.Enqueue("james");
myQueue.Enqueue("jack");
myQueue.Enqueue("jane");

//DEQUEUE
// Jon (0) - James (1) - --Jack -(2)--
/*
0 - James { value:"james", next: "jack"} //first
1 - Jack { value:"jack", next: "jane"}
2 - Jane { value:"jane", next: null} //last
*/
myQueue.Dequeue();
myQueue.Peek();