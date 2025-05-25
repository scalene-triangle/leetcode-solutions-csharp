using leetcode_solutions_csharp.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.LinkedList.Easy;

public class ReverseLinkedListI
{

    /*
     * 206. Reverse Linked List
     * Given the head of a singly linked list, reverse the list, and return the reversed list.
     */
    public void Run()
    {
        ListNode head1 = new ListNode(1,
            new ListNode(2,
            new ListNode(3,
            new ListNode(4,
            new ListNode(5)))));
        ListNode reversed1 = ReverseList(head1);
        Console.WriteLine(PrintHelper.PrintList(reversed1)); // [5,4,3,2,1]


        ListNode head2 = new ListNode(1, new ListNode(2));
        ListNode reversed2 = ReverseList(head2);
        Console.WriteLine(PrintHelper.PrintList(reversed2)); // [2,1]

        ListNode head3 = new ListNode();
        ListNode reversed3 = ReverseList(head3);
        Console.WriteLine(PrintHelper.PrintList(reversed3)); // []
    }

    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */

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

    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;
        ListNode nextNode = null;

        while (current != null)
        {
            nextNode = current.next; // Save the next node
            current.next = prev; // Reverse the link
            prev = current; // Move pointers one position ahead
            current = nextNode;
        }

        // 'prev' now points to the new head of the reversed list
        return prev;
    }
}
