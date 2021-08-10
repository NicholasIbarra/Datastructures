using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /// <summary>
    /// Given an array of integers nums and an integer k
    /// return the total number of continuous subarrays whose sum equals to k.
    /// 
    /// https://leetcode.com/problems/subarray-sum-equals-k/
    /// </summary>
    public class SubArrayEqualsK
    {
        public static void Test()
        {
            int[] nums = new int[] { 2, 1, 1 };
            int k = 2;

            //int[] nums = new int[] { 3, 4, 7, 2, -3, 1, 4, 2 };
            //int k = 7;

            SubArrayEqualsK solution = new SubArrayEqualsK();
            Console.WriteLine(solution.HashSolution(nums, k));
        }

        public int SubarraySum(int[] nums, int k)
        {
            int result = 0;

            for (int start = 0; start < nums.Length; start++)
            {
                for (int end = start; end < nums.Length; end++)
                {
                    int subResult = 0;

                    for(int i = start; i <= end; i++)
                    {
                        subResult += nums[i];
                    }

                    if (subResult == k)
                        result++;                    
                }
            }

            return result;
        }

        public int HashSolution(int[] nums, int k)
        {
            int count = 0, sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(sum)) map[sum]++;
                else map.Add(sum, 1); 
                
                sum += nums[i];

                if (map.ContainsKey(sum - k))
                    count += map[sum - k];
            }

            return count;
        }
    }
}
