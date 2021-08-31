using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/continuous-subarray-sum/
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
            var dict = new Dictionary<int, int>();
            dict.Add(0, -1);

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
