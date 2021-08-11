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
    /// 
    /// https://leetcode.com/problems/n-ary-tree-level-order-traversal/
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
            throw new NotImplementedException();
        }
    }

}
