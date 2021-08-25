using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given an integer array nums and an integer k,
    return true if nums has a continuous subarray of size at least two whose elements sum up to a multiple of k, or false otherwise.

    An integer x is a multiple of k if there exists an integer n such that x = n * k. 0 is always a multiple of k.

    https://leetcode.com/problems/continuous-subarray-sum/
    */
    class ContinuousSubarraySumSolution
    {
        public static void Test()
        {
            ContinuousSubarraySumSolution solution = new ContinuousSubarraySumSolution();

            Console.WriteLine(solution.CheckSubarraySum(new int[] { 23, 2, 4, 6, 7 }, 6));
            Console.WriteLine(solution.CheckSubarraySum(new int[] { 23, 2, 6, 4, 7 }, 6));
            Console.WriteLine(solution.CheckSubarraySum(new int[] { 23, 2, 6, 4, 7 }, 13));
        }

        public bool CheckSubarraySum(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>() { { 0, -1 } };
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (k != 0)
                    sum = sum % k;

                if (dict.ContainsKey(sum))
                {
                    if (i - dict[sum] > 1)
                        return true;
                }
                else
                    dict[sum] = i;
            }

            return false;
        }
    }
}
