using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{

    /*
    Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

    According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined 
    between two nodes p and q as the lowest node in T that has both p and q as 
    descendants (where we allow a node to be a descendant of itself).”

    https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
    */
    class LowestCommonAncestorOfBinaryTree
    {
        public static void Test()
        {
            TreeNode root = new TreeNode
            {
                val = 3,
                left = new TreeNode
                {
                    val = 5,
                    left = new TreeNode(6),
                    right = new TreeNode
                    {
                        val = 2,
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1, new TreeNode(0), new TreeNode(8))
            };

            LowestCommonAncestorOfBinaryTree solution = new LowestCommonAncestorOfBinaryTree();
            Console.WriteLine("p: 5, q: 1 -> " + solution.LowestCommonAncestor(root, root.left, root.right).val);

            Console.WriteLine("p: 5, q: 4 -> " + solution.LowestCommonAncestor(root, root.left, root.left.right.right).val);
        }

        TreeNode answer;

        private TreeNode LowestCommonAncestor(TreeNode root, TreeNode left, TreeNode right)
        {
            //throw new NotImplementedException();

            TraverseTee(root, left, right);

            return answer;

        }

        private bool TraverseTee(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null)
            {
                return false;
            }

            int left = TraverseTee(node.left, p, q) ? 1 : 0;
            int right = TraverseTee(node.right, p, q) ? 1 : 0;
            int root = (node == p || node == q) ? 1 : 0;

            if ((root + left + right) >= 2)
            {
                this.answer = node;
            }

            return (root + left + right) > 0;
        }
    }
}
