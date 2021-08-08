using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /// <summary>
    /// Given two binary strings a and b, return their sum as a binary string.
    /// 
    /// https://leetcode.com/problems/add-binary/
    /// </summary>
    public class AddBinary
    {
        public static void Test()
        {
            AddBinary solution = new AddBinary();
            
            string a = "1010";
            string b = "11";

            Console.WriteLine(solution.BitShiftingSolution(a, b));
        }

        public string AddBinarySolution(string a, string b)
        {
            string result = string.Empty;

            int n = Math.Max(a.Length, b.Length);

            bool hasCarryOver = false;

            for (int i = 0; i < n; i++)
            {
                int x = i >= a.Length ? 0 : a[a.Length - 1 - i] - '0';
                int y = i >= b.Length ? 0 : b[b.Length - 1 - i] - '0';

                var sum = x + y + (hasCarryOver ? 1 : 0);
                hasCarryOver = sum > 1;

                result = (sum % 2).ToString() + result;
            }

            return (hasCarryOver ? "1" : "") + result;
        }

        public string BitShiftingSolution(string a, string b)
        {
            int x = int.Parse(a);
            int y = int.Parse(b);

            int zero = int.Parse("0");
            int carry, answer;

            while(y.CompareTo(zero) != 0)
            {
                answer = x ^ y;
                carry = (x & y) << 1;

                x = answer;
                y = carry;
            }

            return Convert.ToString(x, toBase: 2);
        }
    }
}
