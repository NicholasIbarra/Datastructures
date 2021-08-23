using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
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

        // the smallest (first) and the largest (last) nodes
        Node first = null;
        Node last = null;

        public Node TreeToDoublyList(Node root)
        {
            if (root == null) return null;

            dfs(root);

            last.right = first;
            first.left = last;

            return first;
        }

        private void dfs(Node node)
        {
            if (node == null)
            {
                return;
            }
            else
            {
                // left 
                dfs(node.left);

                if (last != null)
                {
                    last.right = node;
                    node.left = last;
                }
                else
                {
                    first = node;
                }

                last = node;
                dfs(node.right);
            }
        }

        public Node InorderMorrisTraversal(Node root)
        {
            if (root == null) return null;

            Node head = new Node();
            Node last = head;

            Node node = root;

            while (node != null)
            {
                if (node.left != null)
                {
                    // Find the inorder predecessor of current
                    Node pre = node.left;
                    while (pre.right != null && pre.right != node)
                        pre = pre.right;

                    // Make current as right child of its inorder predecessor
                    if (pre.right == null)
                    {
                        pre.right = node;
                        node = node.left;
                    }
                    else
                    {
                        // Revert the changes made in if part to restore
                        // the original tree i.e., fix the right child of predecssor
                        last.right = node;
                        node.left = last;
                        last = node;
                        node = node.right;
                    }
                }
                else
                {
                    last.right = node;
                    node.left = last;
                    last = node;
                    node = node.right;
                }
            }

            last.right = head.right;
            head.right.left = last;
            return head.right;
        }
    }
}
