using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/closest-binary-search-tree-value/
    // Time: O(H)
    // Space: O(1)
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
