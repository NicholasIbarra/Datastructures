using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/basic-calculator-ii/
    // Time: O(n)
    // Space: O(1)
    class BasicCalculatorII
    {
        public static void Test()
        {
            BasicCalculatorII solution = new BasicCalculatorII();

            List<string> expressions = new List<string> { "3+2*2", " 3/2 ", " 3+5 / 2 " };

            foreach(string s in expressions)
            {
                Console.WriteLine(s + " " + solution.Calculate(s));
            }
        }

        public int Calculate(string s)
        {
            if (s == null || s.Length == 0) return 0;

            int length = s.Length;
            int currentNumber = 0, lastNumber = 0, result = 0;
            char operation = '+';

            for (int i = 0; i < length; i++)
            {
                char currentChar = s[i];

                if (char.IsNumber(currentChar))
                {
                    currentNumber = (currentNumber * 10) + (currentChar - '0');
                }
                
                if (!char.IsNumber(currentChar) && !char.IsWhiteSpace(currentChar) || i == length - 1)
                {
                    if (operation == '+' || operation == '-')
                    {
                        result += lastNumber;
                        lastNumber = operation == '+' ? currentNumber : -currentNumber;
                    }
                    else if (operation == '*')
                    {
                        lastNumber = lastNumber * currentNumber;
                    }
                    else if (operation == '/')
                    {
                        lastNumber = lastNumber / currentNumber;
                    }

                    operation = currentChar;
                    currentNumber = 0;
                }
            }

            result += lastNumber;
            return result;
        }
    }
}
