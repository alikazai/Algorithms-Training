namespace LeetCode.PalindromeLinkedList;

public class PalindromeLinkedList
{

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }



    public bool IsPalindrome(ListNode head)
    {
        var stack = new Stack<int>();
        var isPalindrome = false;
        var stackNode = head;
        var currentNode = head;

        while (stackNode != null)
        {
            stack.Push(stackNode.val);
            stackNode = stackNode.next;
        }

        while (currentNode != null)
        {
            var s = stack.Pop();
            if (currentNode.val == s)
            {
                isPalindrome = true;
            }
            else
            {
                isPalindrome = false;
                break;
            }
            currentNode = currentNode.next;
        }

        return isPalindrome;
    }

}