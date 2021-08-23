using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
    /// Return the quotient after dividing dividend by divisor.
    /// 
    /// The integer division should truncate toward zero, which means losing its fractional part. 
    /// For example, truncate(8.345) = 8 and truncate(-2.7335) = -2.
    /// 
    /// Note: Assume we are dealing with an environment that could only store integers within 
    /// the 32-bit signed integer range: [−2^31, 2^31 − 1]. For this problem, assume that your 
    /// function returns 2^31 − 1 when the division result overflows.
    /// 
    /// https://leetcode.com/problems/divide-two-integers/
    /// 
    /// </summary>
    public static class DivideTwoIntegers
    {
        public static void Test()
        {
            Console.WriteLine(Solution(-50, -5));

            int dividend = -7000;
            int divisor = 313;

            // 22
            int result = Solution(dividend, divisor);

            Console.WriteLine(result);
        }

        private static int Solution(int dividend, int divisor)
        {
            throw new NotImplementedException();
        }
    }
}
