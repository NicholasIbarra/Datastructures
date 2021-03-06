using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
    You are given two non-empty linked lists representing two non-negative integers. 
    The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

    https://leetcode.com/problems/add-two-numbers/
    */
    class AddTwoNumers
    {
        class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static void Test()
        {
            ListNode n1 = new ListNode(2);
            ListNode n2 = new ListNode(4);
            ListNode n3 = new ListNode(3);

            n2.next = n3;
            n1.next = n2;

            ListNode m1 = new ListNode(5);
            ListNode m2 = new ListNode(6);
            ListNode m3 = new ListNode(4);

            m2.next = m3;
            m1.next = m2;

            AddTwoNumers solution = new AddTwoNumers();
            ListNode result = solution.AddTwoNumbers(n1, m1);

            while (result != null)
            {
                Console.Write(result.val + (result.next != null ? " -> " : ""));
                result = result.next;
            }
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            throw new NotImplementedException();
        }
    }
}
