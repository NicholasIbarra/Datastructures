using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
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
            var result = new List<IList<int>>();

            if (root == null) return result;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                List<int> subset = new List<int>();
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Node node = queue.Dequeue();
                    subset.Add(node.val);

                    if (node.children != null)
                    {
                        foreach (Node child in node.children)
                        {
                            queue.Enqueue(child);
                        }
                    }
                    
                }

                result.Add(subset);
            }

            return result;
        }

        public static IList<IList<int>> RecursionSolution(Node root)
        {
            var result = new List<IList<int>>();

            traverseNode(root, 0, result);

            return result;
        }

        private static void traverseNode(Node node, int level, List<IList<int>> result)
        {
            if (result.Count <= level)
            {
                result.Add(new List<int>());
            }

            result[level].Add(node.val);

            foreach (Node child in node.children ?? new List<Node>())
            {
                traverseNode(child, level + 1, result);
            }
        }

        public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> enu)
        {
            if (enu == null)
                return;

            foreach (T obj in enu)
                queue.Enqueue(obj);
        }
    }
}
