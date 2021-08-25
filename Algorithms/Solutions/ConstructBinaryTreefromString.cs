using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /* Medium
    You need to construct a binary tree from a string consisting of parenthesis and integers.

    The whole input represents a binary tree. It contains an integer followed by zero, one or 
    two pairs of parenthesis. The integer represents the root's value and a pair of parenthesis contains a child binary tree with the same structure.

    You always start to construct the left child node of the parent first if it exists.

     https://leetcode.com/problems/construct-binary-tree-from-string/
     */
    class ConstructBinaryTreefromString
    {
        public static void Test()
        {
            ConstructBinaryTreefromString solution = new ConstructBinaryTreefromString();

            TreeNode node = solution.Str2tree("4(2(3)(1))(6(5))");

            // Print using BFS
            List<int> results = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                int n = queue.Count;

                for(int i = 0; i < n; i++)
                {
                    TreeNode el = queue.Dequeue();
                    results.Add(el.val);

                    if (el.left != null) queue.Enqueue(el.left);
                    if (el.right != null) queue.Enqueue(el.right);
                }
            }

            Console.WriteLine(string.Join(",", results));
            
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

            for (int i = 0, j = i; i < s.Length; i++, j = i)
            {
                char c = s[i];

                if (c == ')')
                {
                    stack.Pop();
                }
                else if (c >= '0' && c <= '9' || c == '-')
                {
                    while (i + 1 < s.Length && s[i + 1] >= '0' && s[i + 1] <= '9') i++;

                    int val = 0;
                    int.TryParse(s.Substring(j, j - i + 1), out val);

                    TreeNode currentNode = new TreeNode(val);

                    if (stack.Count > 0)
                    {
                        TreeNode parent = stack.Peek();
                        if (parent.left != null) parent.right = currentNode;
                        else parent.left = currentNode;
                    }

                    stack.Push(currentNode);
                }
            }

            return stack.Count > 0 ? null : stack.Peek();
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
