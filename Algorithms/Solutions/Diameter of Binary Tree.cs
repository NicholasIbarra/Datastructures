using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given the root of a binary tree, return the length of the diameter of the tree.

    The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

    The length of a path between two nodes is represented by the number of edges between them.

    https://leetcode.com/problems/diameter-of-binary-tree/
    */
    class Diameter_of_Binary_Tree
    {
        public static void Test()
        {

            Diameter_of_Binary_Tree solution = new Diameter_of_Binary_Tree();

            Console.WriteLine(solution.DiameterOfBinaryTree(new TreeNode
            {
                val = 3,
                left = new TreeNode(1),
                right = new TreeNode(2)
            })); 
            
            Console.WriteLine(solution.DiameterOfBinaryTree(new TreeNode
            {
                val = 1,
                left = new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                right = new TreeNode(3)
            }));
        }

        int diamter;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            diamter = 0;

            dfs(root);

            return diamter;
        }

        private int dfs(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = dfs(node.left);
            int right = dfs(node.right);

            this.diamter = Math.Max(diamter, left + right);

            return Math.Max(left, right) + 1;
        }
    }
}
