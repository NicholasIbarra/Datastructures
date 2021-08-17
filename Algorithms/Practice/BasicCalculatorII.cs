using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
     Given a string s which represents an expression, evaluate this expression and return its value. 

    The integer division should truncate toward zero.

    You may assume that the given expression is always valid. All intermediate results will be in the range of [-231, 231 - 1].

    Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().
    
    https://leetcode.com/problems/basic-calculator-ii/
    */
    class BasicCalculatorII
    {
        public static void Test()
        {
            BasicCalculatorII solution = new BasicCalculatorII();

            List<string> expressions = new List<string> { "3+2*2", " 3/2 ", " 3+5 / 2 " };

            foreach (string s in expressions)
            {
                Console.WriteLine(s + " " + solution.Calculate(s));
            }
        }

        public int Calculate(string s)
        {
            throw new NotImplementedException();
        }
    }
}
