using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    class BinaryTreeMaximumPathSum
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

        int max = int.MinValue;
        int MaxPathSum(TreeNode root)
        {
            PathSum(root);
            return max;
        }

        int PathSum(TreeNode node)
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
