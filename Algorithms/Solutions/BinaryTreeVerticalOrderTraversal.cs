using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given the root of a binary tree, return the vertical order traversal of its nodes' values. (i.e., from top to bottom, column by column).

    If two nodes are in the same row and column, the order should be from left to right.

    https://leetcode.com/problems/binary-tree-vertical-order-traversal/
    */
    class BinaryTreeVerticalOrderTraversal
    {
        public static void Test()
        {
            TreeNode root = new TreeNode
            {
                val = 3,
                left = new TreeNode(9),
                right = new TreeNode
                {
                    val = 20,
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            BinaryTreeVerticalOrderTraversal solution = new BinaryTreeVerticalOrderTraversal();

            solution.VerticalOrder(root).ToList().ForEach(i => Console.WriteLine(string.Join(",", i)));

        }

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null) return result;

            Dictionary<int, List<int>> columnTable = new Dictionary<int, List<int>>();
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();

            int column = 0;
            queue.Enqueue(new Tuple<TreeNode, int>(root, column));

            int minColumn = 0, maxColumn = 0;

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();

                root = p.Item1;
                column = p.Item2;

                if (root != null)
                {
                    if (!columnTable.ContainsKey(column))
                    {
                        columnTable.Add(column, new List<int>());
                    }

                    columnTable[column].Add(root.val);
                    minColumn = Math.Min(minColumn, column);
                    maxColumn = Math.Max(maxColumn, column);

                    queue.Enqueue(new Tuple<TreeNode, int>(root.left, column - 1));
                    queue.Enqueue(new Tuple<TreeNode, int>(root.right, column + 1));
                }
            }

            for (int i = minColumn; i < maxColumn + 1; i++)
            {
                result.Add(columnTable[i]);
            }

            return result;
        }
    }
}
;