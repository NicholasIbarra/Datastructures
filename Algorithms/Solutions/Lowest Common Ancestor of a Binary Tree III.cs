using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/
    class Lowest_Common_Ancestor_of_a_Binary_Tree_III
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node parent;
        }

        // n size of a && m size of b
        // time: O(n + m) 
        // space: o(1)
        public Node LowestCommonAncestor(Node p, Node q)
        {
            Node a = p, b = q;

            while (a != b)
            {
                a = a == null ? q : a.parent;
                b = b == null ? p : b.parent;
            }

            return a;
        }
    }
}
