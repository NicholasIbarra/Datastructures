using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
    Convert a Binary Search Tree to a sorted Circular Doubly-Linked List in place.

   You can think of the left and right pointers as synonymous to the predecessor and successor pointers 
   in a doubly-linked list. For a circular doubly linked list, the predecessor of the first element is the last element, and the successor of the last element is the first element.

   We want to do the transformation in place. After the transformation, the left pointer of the tree node 
   should point to its predecessor, and the right pointer should point to its successor. You should return the pointer to the smallest element of the linked list.

   https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/
   */
    class ConvertBinarySearchTreetoSortedDoublyLinkedList
    {
        public static void Test()
        {
            Node root = new Node(4)
            {
                left = new Node(2, new Node(1), new Node(3)),
                right = new Node(5)
            };

            var solution = new ConvertBinarySearchTreetoSortedDoublyLinkedList();
            var result = solution.TreeToDoublyList(root);

            Console.WriteLine(result.val);
        }

        public Node TreeToDoublyList(Node root)
        {
            throw new NotImplementedException();
        }
    }
}
