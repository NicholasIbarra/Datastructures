using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public class Heap<T> : IEnumerable<T>
    {
        private readonly Func<T, T, int> comparer;
        private readonly List<T> list;

        public Heap(Func<T, T, int> comparer, int capacity = -1)
        {
            this.comparer = comparer;
            list = new List<T>(capacity + 1) { default };
        }

        private int Last => list.Count - 1;
        public int Count => list.Count - 1;

        public IEnumerator<T> GetEnumerator() => list.Skip(1).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T value)
        {
            list.Add(value);
            Swim(Last);
        }

        public T DeleteMax()
        {
            var max = list[1];
            Swap(1, Last);
            list.RemoveAt(Last);
            Sink(1);
            return max;
        }

        private void Swim(int node)
        {
            while (node > 1 && Less(Parent(node), node))
            {
                Swap(Parent(node), node);
                node = Parent(node);
            }
        }

        private void Sink(int root)
        {
            while (Left(root) <= Last)
            {
                var child = Left(root);
                if (child < Last && Less(child, child + 1)) child++;
                if (!Less(root, child)) break;

                Swap(root, child);
                root = child;
            }
        }

        private static int Parent(int index) => index >> 1;
        private int Left(int index) => index << 1;
        private bool Less(int one, int two) => comparer(list[one], list[two]) < 0;

        private void Swap(int one, int two)
        {
            var acc = list[one];
            list[one] = list[two];
            list[two] = acc;
        }
    }
}
