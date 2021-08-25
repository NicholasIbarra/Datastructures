using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given two non-negative integers, num1 and num2 represented as string, return the sum of num1 and num2 as a string.

    You must solve the problem without using any built-in library for handling large integers (such as BigInteger).
    You must also not convert the inputs to integers directly.

    https://leetcode.com/problems/add-strings/
    */
    class AddStringsSolution
    {
        public static void Test()
        {
            string num1 = "11", num2 = "123";

            AddStringsSolution solution = new AddStringsSolution();

            Console.WriteLine(solution.AddStrings(num1, num2));
        }

        public string AddStrings(string num1, string num2)
        {
            if (num2.Length > num1.Length)
            {
                return AddStrings(num2, num1);
            }

            StringBuilder sb = new StringBuilder();
            int carryOver = 0;

            for (int i = 0; i < num1.Length; i++)
            {
                int x = num1[num1.Length - 1 - i] - '0';
                int y = i >= num2.Length ? 0 : num2[num2.Length - 1 - i] - '0';

                int sum = x + y + carryOver;

                carryOver = sum / 10;
                sb.Insert(0, sum % 10);
            }

            if (carryOver > 0)
            {
                sb.Insert(0, carryOver);
            }

            return sb.ToString();
        }
    }
}
