using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given a Circular Linked List node, which is sorted in ascending order, write a function to insert a value insertVal 
    into the list such that it remains a sorted circular list. The given node can be a reference to any single node in the list and may not necessarily be the smallest value in the circular list.

    If there are multiple suitable places for insertion, you may choose any place to insert the new value. After the insertion, the circular list should remain sorted.

    If the list is empty (i.e., the given node is null), you should create a new single circular list and return the reference to that single node. Otherwise, you should return the originally given node.

    https://leetcode.com/problems/insert-into-a-sorted-circular-linked-list/
     */
    class Insert_into_a_Sorted_Circular_Linked_List
    {
        Node Insert(Node head, int insertVal)
        {
            if (head == null)
            {
                Node root = new Node(insertVal, null);
                root.next = root;

                return root;
            }

            Node prev = head;
            Node curr = head.next;

            do
            {
                // Scenario 1: in list
                if (prev.val <= insertVal && insertVal <= curr.val)
                {
                    break;
                }
                else if (prev.val > curr.val)
                {
                    // Scenario 2: At The End    
                    if (insertVal >= prev.val || insertVal <= curr.val)
                    {
                        break;
                    }
                }

                prev = curr;
                curr = curr.next;
            }
            while (prev != head);

            // Scenario 3: All values the same, i.e. anywhere
            prev.next = new Node(insertVal, curr);
            return head;
        }

        class Node
        {
            public int val;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
                next = null;
            }

            public Node(int _val, Node _next)
            {
                val = _val;
                next = _next;
            }
        }
    }
}
