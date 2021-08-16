using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{

    /*
     Given a string num that contains only digits and an integer target, 
    return all possibilities to add the binary operators '+', '-', or '*' between the digits of num so that the resultant 
    expression evaluates to the target value.

    https://leetcode.com/problems/expression-add-operators/
    */
    class ExpressionAddOperators
    {
        public static void Test()
        {
            ExpressionAddOperators solution = new ExpressionAddOperators();

            Console.WriteLine(string.Join(",", solution.AddOperators("123", 6)));
            Console.WriteLine(string.Join(",", solution.AddOperators("232", 8)));
            Console.WriteLine(string.Join(",", solution.AddOperators("105", 5)));
            Console.WriteLine(string.Join(",", solution.AddOperators("00", 0)));
        }

        public IList<string> AddOperators(string num, int target)
        {
            throw new NotImplementedException();
        }

    }
}
