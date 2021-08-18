using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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

        private IList<int> RightSideView(TreeNode root)
        {
            throw new NotImplementedException();
        }
    }
}
