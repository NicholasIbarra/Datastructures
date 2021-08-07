using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
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

        /// <summary>
        /// This solution takes the dividend and subtracts the divisor until the the result <= 0
        /// However, it converts both dividend and divisor to neagtive so there are not multiple code blocks
        /// to handle different combinations of positive \ negative
        /// If there was only 1 negative converted, then answer is negative
        /// 
        /// Time Complexity: O(n)
        /// Worst case senario, divisor equals 1, then would iterate from 0 to n
        /// 
        /// Space Complexit: O(1)
        /// Only used fixed number integers
        /// 
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static int RepeatedSubstraction(int dividend, int divisor)
        {
            // Special case: overflow.
            if (dividend == int.MaxValue && divisor == -1)
            {
                return int.MaxValue;
            }

            // Conert to negative so we do not separate code for
            // all the possible combinations of positive/negative divisor and dividend
            int negatives = 2;

            if (dividend > 0)
            {
                negatives--;
                dividend = -dividend;
            }

            if (divisor > 0)
            {
                negatives--;
                divisor = -divisor;
            }

            // Count how many times divisor can be broken 
            int quotient = 0;
            
            while(dividend - divisor <= 0)
            {
                quotient--;
                dividend -= divisor;
            }

            // If there was exactly one negative sign, quotient remains neagtive
            // positive * negative = negative
            // negative * negative = positive 
            // positive * positive = positive

            if (negatives != 1)
            {
                quotient = -quotient;
            }

            return quotient;
        }

        private static int HALF_INT_MIN = -1073741824;

        /// <summary>
        /// This uses an exponetial search. Similar to iterative approach except
        /// we double the divisor until it exceeds the divident
        /// we then track how many iterations were done and subtracting the remainder from the dividend
        /// we then repeat with the the reduced divisor
        /// repeat until the dividend < divisor
        /// 
        /// Time Complexity: O(Log^2 n)
        /// Space Complexity: 
        /// 
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static int ExponetialSearch(int dividend, int divisor)
        {
            // Special Case: Overflow (Validate range: [-2^31 + 1, 2^31 - 1])
            if (dividend == int.MaxValue && divisor == -1)
            {
                return int.MaxValue;
            }

            // Convert to negative numbers
            int negatives = 2;
            if (dividend > 0)
            {
                negatives--;
                dividend = -dividend;
            }

            if (divisor > 0)
            {
                negatives--;
                divisor = -divisor;
            }

            int quotient = 0;

            while (divisor >= dividend)
            {
                // Atleast once else would not have hit code block
                int powerOfTwo = -1;
                int value = divisor;

                // Check if double the current value > dividend
                while (value >= HALF_INT_MIN && value + value >= dividend)
                {
                    value += value;
                    powerOfTwo += powerOfTwo;
                }

                // Add to 
                quotient += powerOfTwo;

                // Remove value from dividend so we can try again for the remainder
                dividend -= value;

            }

            return negatives != 1 ? -quotient : quotient;
        }

        /// <summary>
        ///  Adding Power of Twos
        ///  Similar to the exponetial search, except for since
        ///  we know that after looping through the first round of divisors, the next power of two will be less then that value
        ///  
        /// Create a list two track the power of twos and doubles
        /// Then work backwars from (n-1 to 0) and subtract
        /// 
        /// Time Complexity: O(log n)
        /// First search is log(n) + log(n) iterations
        /// 
        /// Space Complexity: O(log n)
        ///  
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static int AddingPowersOfTwo(int dividend, int divisor)
        {
            if (dividend == int.MaxValue && divisor == -1)
            {
                return int.MaxValue;
            }

            // Convert to negatives
            int negatives = 2;
            if (dividend > 0)
            {
                negatives--;
                dividend = -dividend;
            }

            if (divisor > 0)
            {
                negatives--;
                divisor = -divisor;
            }

            List<int> doubles = new List<int>();
            List<int> powersOfTwo = new List<int>();

            int powerOFTwo = -1;

            // Make a list of doubles
            while (divisor >= dividend)
            {
                doubles.Add(divisor);
                powersOfTwo.Add(powerOFTwo);

                divisor += divisor;
                powerOFTwo += powerOFTwo;
            }

            int quotient = 0;

            // Work backwards and check if the double fits
            for (int i = doubles.Count - 1; i >= 0; i--)
            {
                if (doubles[i] >= dividend)
                {
                    quotient += powersOfTwo[i];
                    dividend -= doubles[i];
                }

            }

            return negatives != 1 ? -quotient : quotient;
        }

        /// <summary>
        /// Adding Power of Twos with Bitshifting
        /// Similar to the exponetial search, except for since
        /// we know that after looping through the first round of divisors, the next power of two will be less then that value
        ///  
        /// However, instead of creating a list we just get the higest power of two value
        /// and use right bit shifting to half the value and compare with divisor
        /// 
        /// Time Complexity: O(log n)
        /// First search is log(n) + log(n) iterations
        /// 
        /// Space Complexity: O(1)
        ///  
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static int AddingPowersOfTwoBitShifting(int dividend, int divisor)
        {
            if (dividend == int.MaxValue && divisor == -1)
            {
                return int.MaxValue;
            }

            // Convert to negatives
            int negatives = 2;
            
            if (dividend > 0)
            {
                negatives--;
                dividend = -dividend;
            }

            if (divisor > 0)
            {
                negatives--;
                divisor = -divisor;
            }

            // Find the max power of twos 
            int highestDouble = divisor;
            int highestPowerOfTwo = -1;

            while (highestDouble >= HALF_INT_MIN && dividend <= highestDouble + highestDouble)
            {
                highestDouble += highestDouble;
                highestPowerOfTwo += highestPowerOfTwo;
            }

            int quotient = 0;

            while (dividend <= divisor)
            {
                if (dividend <= highestDouble)
                {
                    dividend -= highestDouble;
                    quotient += highestPowerOfTwo;
                }

                highestDouble >>= 1;
                highestPowerOfTwo >>= 1;
            }

            return negatives != 1 ? -quotient : quotient;
        }
    }
}
