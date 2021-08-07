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

        private static int HALF_INT_MIN = -1073741824;

        public static void Test()
        {
            int dividend = 7000;
            int divisor = 313;

            // 22
            int result = Solution(dividend, divisor);

            Console.WriteLine(result);
        }


        /// <summary>
        /// Edge Cases and Scenarios
        /// 
        /// Negative States
        /// neg * pos = neg
        /// neg * neg = pos
        /// pos * pos = pos
        /// 
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        private static int Solution(int dividend, int divisor)
        {
            // Overflow
            if (dividend == int.MaxValue && divisor == -1)
            {
                return int.MaxValue;
            }

            int negatives = 2;

            if (dividend > 0)
            {
                dividend = -dividend;
                negatives--;
            }

            if (divisor > 0)
            {
                divisor = -divisor;
                negatives--;
            }

            int highestPowerOFtwo = -1;
            int highestDoubles = divisor;

            while (dividend <= highestDoubles + highestDoubles)
            {
                highestPowerOFtwo += highestPowerOFtwo;
                highestDoubles += highestDoubles;
            }

            int quotient = 0;

            while (dividend <= divisor)
            {
                if (dividend <= highestDoubles)
                {
                    dividend -= highestDoubles;
                    quotient += highestPowerOFtwo;
                }

                highestDoubles >>= 1;
                highestPowerOFtwo >>= 1;
            }

            return quotient;
        }
    }
}
