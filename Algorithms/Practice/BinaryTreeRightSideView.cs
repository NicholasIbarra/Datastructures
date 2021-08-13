using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
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

        private IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int nodesOnLevel = queue.Count;

                for (int i = 0; i < nodesOnLevel; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (i == nodesOnLevel - 1)
                    {
                        // Laast node on the level
                        result.Add(node.val);
                    }

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return result;
        }
    }
}
