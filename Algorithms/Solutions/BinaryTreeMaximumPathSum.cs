using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    public class TreeNode
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

    public class BinaryTreeMaximumPathSum
    {
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
            var result = solution.MaxPathSum(root);

            Console.WriteLine(result);
        }

        int max = 0;
        public int MaxPathSum(TreeNode root)
        {
            PathSum(root);
            return max;

        }

        public int PathSum(TreeNode node)
        {
            if (node == null) return 0;

            int leftMax = Math.Max(PathSum(node.left), 0);
            int rightMax = Math.Max(PathSum(node.right), 0);

            int nodeVal = node.val + leftMax + rightMax;
            max = Math.Max(nodeVal, max);

            return node.val + Math.Max(leftMax, rightMax);
        }
    }
}
