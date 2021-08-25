using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     You are given an integer num. You can swap two digits at most once to get the maximum valued number.

    Return the maximum valued number you can get.

    https://leetcode.com/problems/maximum-swap/
     */
    class Maximum_Swap
    {
        public static void Test()
        {
            Maximum_Swap soltion = new Maximum_Swap();

            Console.Write(soltion.MaximumSwap(2736));
            Console.Write(soltion.MaximumSwap(9973));
        }

        public int MaximumSwap(int num)
        {
            char[] digits = num.ToString().ToCharArray();
            int[] buckets = new int[10];

            for (int i = 0; i < digits.Length; i++)
            {
                buckets[digits[i] - '0'] = i;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                for (int k = 9; k > digits[i] - '0'; k--)
                {
                    if (buckets[k] > i)
                    {
                        char tmp = digits[i];
                        digits[i] = digits[buckets[k]];
                        digits[buckets[k]] = tmp;

                        int.TryParse(digits, out num);
                        return Convert.ToInt32(new string(digits));
                    }
                }
            }

            return num;
        }
    }
}
