using Datastructure.Utility;
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
    class PathSumII
    {

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

            PathSumII solution = new PathSumII();
            var result = solution.PathSum(root, 22);
            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            throw new NotImplementedException();
        }
    }
}
