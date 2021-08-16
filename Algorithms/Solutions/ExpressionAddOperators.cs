using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given a string num that contains only digits and an integer target, 
    return all possibilities to add the binary operators '+', '-', or '*' between the digits of num so that the resultant 
    expression evaluates to the target value.

    https://leetcode.com/problems/expression-add-operators/
    */
    class ExpressionAddOperators
    {
        private int target;
        private string digits;
        private List<string> answer;

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
            this.answer = new List<string>();

            if (num == null || num.Length == 0)
            {
                return this.answer;
            }

            this.target = target;
            this.digits = num;

            recurse(0, 0, 0, 0, new List<string>());

            return this.answer;
        }

        private void recurse(int index, long previousOperand, long currentOperand, long value, List<string> ops)
        {
            string num = this.digits;

            // done processing all the digis in the num
            if (index == num.Length)
            {
                // if the final value == target and no operand is left unprocessed
                if (value == this.target && currentOperand == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    ops.GetRange(1, ops.Count - 1).ForEach(v => sb.Append(v));

                    this.answer.Add(sb.ToString());
                }

                return;
            }

            // Extending the current operand by 1 digit
            currentOperand = currentOperand * 10 + (long)char.GetNumericValue(num[index]);
            string currentValRep = currentOperand.ToString();
            int length = num.Length;

            // to avoid cases where we have 1 + 05 or 1 * 05 since invalid operand

            if (currentOperand > 0)
            {
                // no op recursion
                recurse(index + 1, previousOperand, currentOperand, value, ops);
            }

            // Addition
            ops.Add("+");
            ops.Add(currentValRep);
            recurse(index + 1, currentOperand, 0, value + currentOperand, ops);
            ops.RemoveAt(ops.Count - 1);
            ops.RemoveAt(ops.Count - 1);

            if (ops.Count > 0)
            {
                // subctraction
                ops.Add("-");
                ops.Add(currentValRep);
                recurse(index + 1, -currentOperand, 0, value - currentOperand, ops);
                ops.RemoveAt(ops.Count - 1);
                ops.RemoveAt(ops.Count - 1);

                // subctraction
                ops.Add("*");
                ops.Add(currentValRep);
                recurse(index + 1, previousOperand * currentOperand, 0, value - previousOperand + (currentOperand * previousOperand), ops);
                ops.RemoveAt(ops.Count - 1);
                ops.RemoveAt(ops.Count - 1);
            }
        }
    }
}
