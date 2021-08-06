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
    /// the 32-bit signed integer range: [−231, 231 − 1]. For this problem, assume that your 
    /// function returns 231 − 1 when the division result overflows.
    /// 
    /// https://leetcode.com/problems/divide-two-integers/
    /// 
    /// </summary>
    public static class DivideTwoIntegers
    {
        public static void Test()
        {
            int dividend = 7000;
            int divisor = 313;

            //var result = RepeatedSubstraction(dividend, divisor);
            //var result = ExponetialSearch(dividend, divisor);
            //var result = AddingPowersOfTwo(dividend, divisor);
            var result = AddingPowersOfTwoBitShifting(dividend, divisor);

            Console.WriteLine(result);
        }

        public static int RepeatedSubstraction(int dividend, int divisor)
        {
            throw new NotImplementedException();
        }

        private static int HALF_INT_MIN = -1073741824;

        public static int ExponetialSearch(int dividend, int divisor)
        {
            throw new NotImplementedException();
        }

        public static int AddingPowersOfTwo(int dividend, int divisor)
        {
            throw new NotImplementedException();
        }

        public static int AddingPowersOfTwoBitShifting(int dividend, int divisor)
        {
            throw new NotImplementedException();
        }
    }
}
