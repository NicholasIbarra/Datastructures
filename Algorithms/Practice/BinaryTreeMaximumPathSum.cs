using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
    A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the 
    sequence has an edge connecting them. A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.

    The path sum of a path is the sum of the node's values in the path.

    Given the root of a binary tree, return the maximum path sum of any path.

    https://leetcode.com/problems/binary-tree-maximum-path-sum/
    */
    class BinaryTreeMaximumPathSum
    {
        class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static void Test()
        {
            TreeNode root = new TreeNode(-10)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            BinaryTreeMaximumPathSum solution = new BinaryTreeMaximumPathSum();
            Console.WriteLine(solution.MaxPathSum(root));

            TreeNode root2 = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };

            Console.WriteLine(solution.MaxPathSum(root2));
        }

        int MaxPathSum(TreeNode root)
        {
            throw new NotImplementedException();
        }
    }
}
