using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/construct-binary-tree-from-string/
    // Time: O(N)
    // Space: O(H), height of tree

    class ConstructBinaryTreefromString
    {
        public static void Test()
        {
            ConstructBinaryTreefromString solution = new ConstructBinaryTreefromString();

            TreeNode node = solution.Str2tree("4(2(3)(1))(6(5))");
        }

        public TreeNode Str2tree(string s)
        {
            if (s == null || string.IsNullOrEmpty(s))
            {
                return null;
            }

            TreeNode root = new TreeNode();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            for (int index = 0; index < s.Length; index++)
            {
                TreeNode node = stack.Pop();

                // Not STarted
                if (char.IsNumber(s[index]) || s[index] == '-')
                {
                    Tuple<int, int> data = this.getNumer(s, index);
                    int value = data.Item1;
                    index = data.Item2;

                    node.val = value;

                    // next, if there is any data left, we check for the first subtree
                    // which according to the problem statement, will always be the left child
                    if (index < s.Length && s[index] == '(')
                    {
                        stack.Push(node);
                        node.left = new TreeNode();
                        stack.Push(node.left);
                    }
                }
                else if (s[index] == '(' && node.left != null)
                {
                    // left is done
                    stack.Push(node);
                    node.right = new TreeNode();
                    stack.Push(node.right);
                }
            }

            return stack.Count == 0 ? root : stack.Pop();
        }

        private Tuple<int, int> getNumer(string s, int index)
        {
            bool isNegative = false;

            if (s[index] == '-')
            {
                isNegative = true;
                index++;
            }

            int number = 0;

            while (index < s.Length && char.IsNumber(s[index]))
            {
                number = (number * 10) + (s[index] - '0');
                index++;
            }

            return new Tuple<int, int>(isNegative ? -number : number, index);
        }
    }
}
