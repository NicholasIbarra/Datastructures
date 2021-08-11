using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
    Given a string s of '(' , ')' and lowercase English characters. 

    Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.

    Formally, a parentheses string is valid if and only if:

    It is the empty string, contains only lowercase characters, or
    It can be written as AB (A concatenated with B), where A and B are valid strings, or
    It can be written as (A), where A is a valid string.

    https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/

     */
    public class MinimumRemovetoMakeValidParentheses
    {
        public static void Test()
        {
            List<string> tests = new List<string> {  "(a(b(c)d)", "lee(t(c)o)de)", "a)b(c)d", "())()(((", "))((" };
            MinimumRemovetoMakeValidParentheses solution = new MinimumRemovetoMakeValidParentheses();

            foreach (string s in tests)
            {
                Console.WriteLine(s + " -> " + solution.MinRemoveToMakeValid(s));
            }
        }

        /// <summary>
        /// Scenarios
        /// 
        /// (()
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string MinRemoveToMakeValid(string s)
        {
            StringBuilder sb = new StringBuilder();

            int balance = 0;
            int openBrackets = 0;

            // right most )
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(')
                {
                    openBrackets++;
                    balance++;
                }
                else if (c == ')')
                {
                    if (balance > 0)
                    {
                        balance--;
                    }
                    else
                    {
                        continue;
                    }
                }

                sb.Append(c);
            }

            // left most (
            Console.WriteLine(sb.ToString());
            StringBuilder result = new StringBuilder();
            int openToKkeep = openBrackets - balance;

            for(int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '(')
                {
                    openToKkeep--;

                    if (openToKkeep < 0)
                        continue;
                }

                result.Append(sb[i]);
            }

            return result.ToString();
        }
    }

}
