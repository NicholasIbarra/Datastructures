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
            // O(N)
            char[] number = num.ToString().ToCharArray();
            int[] numIndex = new int[10];

            // O(N)
            for (int i = 0; i < number.Length; i++)
            {
                numIndex[number[i] - '0'] = i;
            }

            // O(N)
            for (int i = 0; i < number.Length; i++)
            {
                // O(9)
                for (int j = 9; j > number[i] - '0'; j--)
                {
                    if (numIndex[j] > i)
                    {
                        char tmp = number[i];
                        number[i] = number[numIndex[j]];
                        number[numIndex[j]] = tmp;

                        return Convert.ToInt32(new string(number));
                    }
                }
            }

            return num;
        }
    }
}
