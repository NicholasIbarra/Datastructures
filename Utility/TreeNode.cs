using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Utility
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            left = null;
            right = null;
        }

        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }

    public class LinkedListNode
    {
        public int val;
        public LinkedListNode next;

        public LinkedListNode() { }

        public LinkedListNode(int _val)
        {
            val = _val;
            next = null;
        }

        public LinkedListNode(int _val, LinkedListNode _next)
        {
            val = _val;
            next = _next;
        }
    }

    class BinaryMatrix
    {
        public int Get(int row, int col) 
        {
            return 0;
        }
        
        public IList<int> Dimensions() 
        {
            return new List<int>();
        }
    }
}
