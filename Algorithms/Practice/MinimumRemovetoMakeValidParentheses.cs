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

        private string MinRemoveToMakeValid(string s)
        {
            //throw new NotImplementedException();

            StringBuilder sb = new StringBuilder();

            // right most closed parenthesis

            int balance = 0, totalClosed = 0;

            foreach(char c in s)
            {
                if (c == '(')
                {
                    balance++;
                }
                else if (c == ')')
                {
                    if (balance <= 0)
                        continue;

                    balance--;
                    totalClosed++;
                }

                sb.Append(c);
            }


            // Left Most Open Parenthesis

            StringBuilder res = new StringBuilder();

            foreach (char c in sb.ToString())
            {
                if (c == '(')
                {
                    if (totalClosed <= 0)
                        continue; 
                    
                    totalClosed--;
                }

                res.Append(c);
            }

            return res.ToString();
        }
    }

}
