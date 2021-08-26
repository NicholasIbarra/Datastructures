using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice.New_Practice
{
    /*
        Given the root node of a binary search tree and
        two integers low and high, return the sum of values 
        of all nodes with a value in the inclusive range [low, high].

        https://leetcode.com/problems/range-sum-of-bst/
    
     */
    class Range_Sum_of_BST
    {
        public static void Test()
        {
            Range_Sum_of_BST solution = new Range_Sum_of_BST();

            TreeNode root = new TreeNode
            {
                val = 10,
                left = new TreeNode(5, new TreeNode(3), new TreeNode(7)),
                right = new TreeNode(15, null, new TreeNode(18))
            };

            Console.WriteLine(solution.RangeSumBST(root, 7, 15));
        }

        public int RangeSumBST(TreeNode root, int low, int high)
        {
            throw new NotImplementedException();
        }
    }
}
