using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given the root of a binary search tree and a target value, return the value in the BST that is closest to the target.
    
    https://leetcode.com/problems/closest-binary-search-tree-value/
    */
    class ClosestBinarySearchTreeValue
    {
        public int ClosestValue(TreeNode root, double target)
        {
            int val, closest = root.val;

            while (root != null)
            {
                val = root.val;
                closest = Math.Abs(val - target) < Math.Abs(closest - target) ? val : closest;
                root = target < root.val ? root.left : root.right;
            }

            return closest;
        }
    }
}
