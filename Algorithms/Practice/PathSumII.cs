using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where each path's sum equals targetSum.
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

        /// <summary>
        /// Utilize a DFS to find the root to leafe path that equals the target sum
        /// Recurrsiv call of findPath 
        /// if node = null, return
        /// Add node.val to current path
        /// if node.val == target sum && left\right null, add to result
        /// 
        /// else recursion on node.left && node.right
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> paths = new List<IList<int>>();
            findPath(root, targetSum, new List<int>(), paths);

            return paths;
        }

        private static void findPath(TreeNode node, int targetSum, List<int> current, List<IList<int>> paths)
        {
            // Handle base case
            if (node == null)
            {
                return;
            }

            current.Add(node.val);

            if (node.val == targetSum && node.left == null && node.right == null)
            {
                paths.Add(current);
                return;
            }

            // Traverse left and right side of tree
            findPath(node.left, targetSum - node.val, new List<int>(current), paths);
            findPath(node.right, targetSum - node.val, new List<int>(current), paths);
        }
    }
}
