using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given the root of a binary tree, imagine yourself 
    standing on the right side of it, return the values of the nodes 
    you can see ordered from top to bottom.

    https://leetcode.com/problems/binary-tree-right-side-view/
    */
    class BinaryTreeRightSideView
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
            TreeNode root = new TreeNode
            {
                val = 1,
                left = new TreeNode()
                {
                    val = 2,
                    right = new TreeNode(5)
                },
                right = new TreeNode()
                {
                    val = 3,
                    right = new TreeNode(4)
                }
            };

            BinaryTreeRightSideView solutution = new BinaryTreeRightSideView();

            Console.WriteLine(String.Join(",", solutution.RightSideView(root)));
        }

        IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return new List<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            List<int> result = new List<int>();

            while(queue.Count > 0)
            {
                int elementsOnLevel = queue.Count;

                for (int i = 0; i < elementsOnLevel; ++i)
                {
                    TreeNode node = queue.Dequeue();

                    // Last value
                    if (i == elementsOnLevel - 1)                        
                        result.Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return result;
        }

        IList<int> RightSideViewDfs(TreeNode root)
        {
            List<int> result = new List<int>();
            TraveseDfs(root, result, 0);

            return result;
        }

        private void TraveseDfs(TreeNode root, List<int> result, int level)
        {
            if (root == null)
            {
                return;
            }

            if (level >= result.Count)
            {
                result.Add(root.val);
            }

            TraveseDfs(root.right, result, level + 1);
            TraveseDfs(root.left, result, level + 1);
        }
    }
}
