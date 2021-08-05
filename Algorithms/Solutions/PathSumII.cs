using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
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

        public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> paths = new List<IList<int>>();
            findPaths(root, targetSum, new List<int>(), paths);

            return paths;
        }

        private static void findPaths(TreeNode root, int targetSum, List<int> current, List<IList<int>> paths)
        { 
            if (root == null)
            {
                return;
            }

            current.Add(root.val);

            if (root.val == targetSum && root.left == null & root.right == null)
            {
                paths.Add(current);
                return;
            }

            // Left tree
            findPaths(root.left, targetSum - root.val, new List<int>(current), paths);

            // right tree
            findPaths(root.right, targetSum - root.val, new List<int>(current), paths);
        }
    }
}
