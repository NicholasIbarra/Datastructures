using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
            throw new NotImplementedException();
        }
    }
}
