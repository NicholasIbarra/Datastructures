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
            throw new NotImplementedException();
        }
    }
}
