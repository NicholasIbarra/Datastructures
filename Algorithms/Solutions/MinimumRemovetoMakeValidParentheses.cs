using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    public class MinimumRemovetoMakeValidParentheses
    {
        public static void Test()
        {
            List<string> tests = new List<string> { "())()(((", "(a(b(c)d)", "lee(t(c)o)de)", "a)b(c)d", "))(("};
            MinimumRemovetoMakeValidParentheses solution = new MinimumRemovetoMakeValidParentheses();

            foreach(string s in tests )
            {
                Console.WriteLine(s + " -> " + solution.SolutionWithoutStack(s));
            }
        }

        public string MinRemoveToMakeValid(string s)
        {
            StringBuilder result = new StringBuilder();
            Stack<int> stack = new Stack<int>();
            HashSet<int> indexesToRemove = new HashSet<int>();

            for(int i = 0; i < s.Length; i++)
            {
                bool isOpen = s[i] == '(';
                bool isClose = s[i] == ')';

                if (isOpen)
                {
                    stack.Push(i);
                }
                else if (isClose)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        indexesToRemove.Add(i);
                    }
                }
            }

            while (stack.Count > 0) indexesToRemove.Add(stack.Pop());

            for (int i = 0; i < s.Length; i++)
            {
                if (!indexesToRemove.Contains(i))
                {
                    result.Append(s[i]);
                }
            }
            
            return result.ToString();
        }

        public string SolutionWithoutStack(string s)
        {
            StringBuilder sb = new StringBuilder();
            int balance = 0, seenClosed = 0;

            // Remove all invalid ")"
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(')
                {
                    balance++;
                }
                else if (c == ')')
                {
                    if (balance <= 0)
                    {
                        continue;
                    }

                    balance--;
                    seenClosed++;
                }

                sb.Append(c);
            }

            // Remove right most "("
            StringBuilder res = new StringBuilder();

            foreach (char c in sb.ToString())
            {
                if (c == '(')
                {
                    seenClosed--;
                    if (seenClosed < 0)
                        continue;
                }

                res.Append(c);
            }

            return res.ToString();
        }
    }
}
