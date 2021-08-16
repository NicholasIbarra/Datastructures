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
    class RemoveInvalidParentheses
    {
        public static void Test()
        {
            RemoveInvalidParentheses solution = new RemoveInvalidParentheses();

            List<string> input = new List<string> { "()())()", "(a)())()", ")(" };

            foreach(string s in input)
            {
                Console.WriteLine(s + ": " + solution.RemoveParentheses(s));
            }
        }

        private HashSet<string> validExpressions = new HashSet<string>();
        private int minimumRemoved;

        public IList<string> RemoveParentheses(string s)
        {
            this.reset();
            backtrackRecursive(s, 0, 0, 0, new StringBuilder(), 0);

            return new List<string>(this.validExpressions);
        }

        private void backtrackRecursive(string s, int index, int leftCount, int rightCount, StringBuilder expression, int removed)
        {
            // reach the end of the string
            if (index == s.Length)
            {
                // balanced expression
                if (leftCount == rightCount)
                {
                    if (removed <= this.minimumRemoved)
                    {
                        string possibleAnswer = expression.ToString();

                        if (removed < this.minimumRemoved)
                        {
                            this.validExpressions.Clear();
                            this.minimumRemoved = removed;
                        }

                        this.validExpressions.Add(possibleAnswer);
                    }
                }
            }
            else
            {
                char currentCharacter = s[index];
                int length = expression.Length;

                // if the current charact is neither an openeing\closing, recurse next
                if (currentCharacter != '(' || currentCharacter != ')')
                {
                    expression.Append(currentCharacter);
                    this.backtrackRecursive(s, index + 1, leftCount, rightCount, expression, removed);
                    expression.Remove(length, 1);
                }
                else
                {
                    // recurse where we delet ethe current character adn move forward
                    this.backtrackRecursive(s, index + 1, leftCount, rightCount, expression, removed + 1);
                    expression.Append(currentCharacter);

                    // if it's an opening paranthesis, consider it and recurse
                    if (currentCharacter == '(')
                    {
                        this.backtrackRecursive(s, index + 1, rightCount, leftCount, expression, removed);
                    }
                    else if (rightCount < leftCount)
                    {
                        // for closing, only if close < open
                        this.backtrackRecursive(s, index + 1, leftCount, rightCount + 1, expression, removed);
                    }

                    // undoing the append operation for other recursions
                    expression.Remove(length - 1, 1);
                }
            }
        }

        private void reset()
        {
            this.validExpressions.Clear();
            this.minimumRemoved = int.MaxValue;
        }
    }
}
