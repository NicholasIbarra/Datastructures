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

        List<string> result = new List<string>();
        string Digits;
        int Target;

        public IList<string> AddOperators(string num, int target)
        {
            //throw new NotImplementedException();

            this.Digits = num;
            this.Target = target;

            Recusrive(0, 0, 0, 0, new List<string>());

            return this.result;
        }

        private void Recusrive(int index, long prev, long current, long value, List<string> operands)
        {
            if (index == this.Digits.Length)
            {
                if (value == this.Target && current == 0)
                {
                    StringBuilder sb = new StringBuilder();

                    operands.GetRange(1, operands.Count - 1)
                        .ForEach(o => sb.Append(o));

                    this.result.Add(sb.ToString());
                }

                return;
            }

            // Calculate the current value
            current = current * 10 + (this.Digits[index] - '0');

            if (current > 0)
            {
                this.Recusrive(index + 1, prev, current, value, operands);
            }

            // Addition
            operands.Add("+");
            operands.Add(current.ToString());

            this.Recusrive(index + 1, current, 0, value + current, operands);

            operands.RemoveAt(operands.Count - 1);
            operands.RemoveAt(operands.Count - 1);

            if (operands.Count > 0)
            {
                // Subtraction
                operands.Add("-");
                operands.Add(current.ToString());

                this.Recusrive(index + 1, current, 0, value - current, operands);

                operands.RemoveAt(operands.Count - 1);
                operands.RemoveAt(operands.Count - 1);

                // Multiplication
                operands.Add("*");
                operands.Add(current.ToString());

                this.Recusrive(index + 1, prev * current, 0, value - prev + (prev * current), operands);

                operands.RemoveAt(operands.Count - 1);
                operands.RemoveAt(operands.Count - 1);

            }
        }
    }
}
