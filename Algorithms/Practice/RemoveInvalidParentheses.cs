using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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

            foreach (string s in input)
            {
                Console.WriteLine(s + ": " + solution.RemoveParentheses(s));
            }
        }

        public IList<string> RemoveParentheses(string s)
        {
            throw new NotImplementedException();
        }
    }
}
