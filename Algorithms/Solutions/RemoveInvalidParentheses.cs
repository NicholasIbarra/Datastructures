using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/remove-invalid-parentheses/
    // Time: O(2 ^ n)
    // Space: O(n)
    class RemoveInvalidParenthesesSolution
    {
        public static void Test()
        {
            RemoveInvalidParenthesesSolution solution = new RemoveInvalidParenthesesSolution();

            List<string> input = new List<string> { "()())()", "(a)())()", ")(" };

            foreach(string s in input)
            {
                Console.WriteLine(s + ": " + string.Join(",", solution.RemoveInvalidParentheses(s)));
            }
        }

        private HashSet<string> validExpressions = new HashSet<string>();

        private void backtrack(
            string s,
            int index,
            int lc,
            int rc,
            int left,
            int right,
            StringBuilder expression)
        {

            // If we reached the end of the string, just check if the resulting expression is
            // valid or not and also if we have removed the total number of left and right
            // parentheses that we should have removed.
            if (index == s.Length)
            {
                if (left == 0 && right == 0)
                {
                    this.validExpressions.Add(expression.ToString());
                }

            }
            else
            {
                char character = s[index];
                int length = expression.Length;

                // The discard case. Note that here we have our pruning condition.
                // We don't recurse if the remaining count for that parenthesis is == 0.
                if ((character == '(' && left > 0) || (character == ')' && right > 0))
                {
                    this.backtrack(
                        s,
                        index + 1,
                        lc,
                        rc,
                        left - (character == '(' ? 1 : 0),
                        right - (character == ')' ? 1 : 0),
                        expression);
                }

                expression.Append(character);

                // Simply recurse one step further if the current character is not a parenthesis.
                if (character != '(' && character != ')')
                {

                    this.backtrack(s, index + 1, lc, rc, left, right, expression);

                }
                else if (character == '(')
                {

                    // Consider an opening bracket.
                    this.backtrack(s, index + 1, lc + 1, rc, left, right, expression);

                }
                else if (rc < lc)
                {

                    // Consider a closing bracket.
                    this.backtrack(s, index + 1, lc, rc + 1, left, right, expression);
                }

                // Delete for backtracking.
                expression.Remove(length, 1);
            }
        }

        public List<string> RemoveInvalidParentheses(string s)
        {

            int left = 0, right = 0;

            // First, we find out the number of misplaced left and right parentheses.
            for (int i = 0; i < s.Length; i++)
            {

                // Simply record the left one.
                if (s[i] == '(')
                {
                    left++;
                }
                else if (s[i] == ')')
                {
                    right = left == 0 ? right + 1 : right;
                    left = left > 0 ? left - 1 : left;
                }
            }

            this.backtrack(s, 0, 0, 0, left, right, new StringBuilder());
            return new List<string>(this.validExpressions);
        }
    }
}
