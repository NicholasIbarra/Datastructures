using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
            throw new NotImplementedException();
        }
    }
}
