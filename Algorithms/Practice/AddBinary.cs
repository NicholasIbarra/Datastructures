using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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

            Console.WriteLine(a + " " + b + " = " + solution.AddBinarySolution(a, b));
        }

        public string AddBinarySolution(string a, string b)
        {
            throw new NotImplementedException();
        }
    }
}
