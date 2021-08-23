using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given a string s that contains parentheses and letters,
    remove the minimum number of invalid parentheses to make the input string valid.

    Return all the possible results. You may return the answer in any order.

    https://leetcode.com/problems/remove-invalid-parentheses/
    */
    class RemoveInvalidParenthesesSolution
    {
        public static void Test()
        {
            RemoveInvalidParenthesesSolution solution = new RemoveInvalidParenthesesSolution();

            List<string> input = new List<string> { "()())()", "(a)())()", ")(" };

            foreach(string s in input)
            {
                Console.WriteLine(s + ": " + string.Join(",", solution.removeInvalidParentheses(s)));
            }
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            var list = new List<string>();

            if (isValidParanthesis(s))
            {
                list.Add(s);
                return list;
            }

            var queue = new Queue<Tuple<string, int, char>>();
            queue.Enqueue(new Tuple<string, int, char>(s, 0, ')'));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var search  = current.Item1;
                var start   = current.Item2;
                var removed = current.Item3;

                // Start from last removal
                for (int i = start; i < search.Length; i++)
                {
                    var visit = search[i];

                    // not parenthesis
                    if (!(visit == '(' || visit == ')'))
                    {
                        continue;
                    }

                    // Do not remove consectuive ones, i.e. (((
                    if (i != start && search[i - 1] == visit)
                    {
                        continue;
                    }

                    // Do not remove valid pair
                    if (removed == '(' && visit == ')')
                    {
                        continue;
                    }

                    // remove visit char from the string
                    var skipCurrent = search.Substring(0, i) + search.Substring(i + 1);
                    
                    if (isValidParanthesis(skipCurrent))
                    {
                        list.Add(skipCurrent);
                        continue;
                    }

                    if (list.Count == 0)
                    {
                        queue.Enqueue(new Tuple<string, int, char>(skipCurrent, i, visit));
                    }
                }
            }

            return list;
        }

        private bool isValidParanthesis(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var visit = s[i];
                var isOpen = visit == '(';
                var isClose = visit == ')';

                if (isOpen) ++count;

                if (isClose)
                {
                    bool noOpenToMatch = count <= 0;

                    if (noOpenToMatch) return false;

                    count--;
                }
            }

            return count == 0;
        }



        private HashSet<string> validExpressions = new HashSet<string>();

        private void recurse(
            String s,
            int index,
            int leftCount,
            int rightCount,
            int leftRem,
            int rightRem,
            StringBuilder expression)
        {

            // If we reached the end of the string, just check if the resulting expression is
            // valid or not and also if we have removed the total number of left and right
            // parentheses that we should have removed.
            if (index == s.Length)
            {
                if (leftRem == 0 && rightRem == 0)
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
                if ((character == '(' && leftRem > 0) || (character == ')' && rightRem > 0))
                {
                    this.recurse(
                        s,
                        index + 1,
                        leftCount,
                        rightCount,
                        leftRem - (character == '(' ? 1 : 0),
                        rightRem - (character == ')' ? 1 : 0),
                        expression);
                }

                expression.Append(character);

                // Simply recurse one step further if the current character is not a parenthesis.
                if (character != '(' && character != ')')
                {

                    this.recurse(s, index + 1, leftCount, rightCount, leftRem, rightRem, expression);

                }
                else if (character == '(')
                {

                    // Consider an opening bracket.
                    this.recurse(s, index + 1, leftCount + 1, rightCount, leftRem, rightRem, expression);

                }
                else if (rightCount < leftCount)
                {

                    // Consider a closing bracket.
                    this.recurse(s, index + 1, leftCount, rightCount + 1, leftRem, rightRem, expression);
                }

                // Delete for backtracking.
                expression.Remove(length, 1);
            }
        }

        public List<string> removeInvalidParentheses(string s)
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
                    // If we don't have a matching left, then this is a misplaced right, record it.
                    right = left == 0 ? right + 1 : right;

                    // Decrement count of left parentheses because we have found a right
                    // which CAN be a matching one for a left.
                    left = left > 0 ? left - 1 : left;
                }
            }

            this.recurse(s, 0, 0, 0, left, right, new StringBuilder());
            return new List<string>(this.validExpressions);
        }
    }
}
