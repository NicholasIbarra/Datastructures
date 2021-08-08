using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given an n-ary tree, return the level order traversal of its nodes' values.
    /// 
    /// Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value(See examples).
    /// </summary>
    public static class NTreeLevelOrderTraversal
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public static void Test()
        {
            var root = new Node(1)
            {
                children = new List<Node>
                {
                    new Node(3)
                    {
                        children = new List<Node>
                        {
                            new Node(5),
                            new Node(6)
                        }
                    },
                    new Node(2),
                    new Node(4)
                }
            };

            var result = LevelOrder(root);
            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        public static IList<IList<int>> LevelOrder(Node root)
        {
            List<IList<int>> result = new List<IList<int>>();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                List<int> subset = new List<int>();
                int n = queue.Count;

                for(int i = 0; i < n; i++)
                {
                    Node node = queue.Dequeue();
                    subset.Add(node.val);

                    queue.AddRange(node.children);
                }

                result.Add(subset);
            }

            return result;
        }
    }

    public static class Extensions
    {
        public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> enu)
        {
            if (enu == null)
                return;

            foreach (T obj in enu)
                queue.Enqueue(obj);
        }
    }
}
