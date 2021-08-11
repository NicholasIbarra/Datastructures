using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given the root of a binary tree and an integer targetSum
    /// return all root-to-leaf paths where each path's sum equals targetSum.
    /// A leaf is a node with no children.
    /// 
    /// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3838/
    /// </summary>
    public static class PathSumII
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

        public static void Test()
        {
            TreeNode root = new TreeNode()
            {
                val = 5,
                left = new TreeNode()
                {
                    val = 4,
                    left = new TreeNode()
                    {
                        val = 11,
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode()
                {
                    val = 8,
                    left = new TreeNode(13),
                    right = new TreeNode()
                    {
                        val = 4,
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                }
            };

            var result = PathSum(root, 22);
            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        private static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null) return result;

            var subset = new List<int>();
            FindPath(root, subset, result, targetSum);

            return result;
        }

        private static void FindPath(TreeNode root, List<int> subset, List<IList<int>> result, int targetSum)
        {
            if (root == null)
                return;

            subset.Add(root.val);

            if (root.val == targetSum && root.left == null && root.right == null)
            {
                result.Add(subset);
                return;
            }

            FindPath(root.left, new List<int>(subset), result, targetSum - root.val);
            FindPath(root.right, new List<int>(subset), result, targetSum- root.val);
        }
    }
}
