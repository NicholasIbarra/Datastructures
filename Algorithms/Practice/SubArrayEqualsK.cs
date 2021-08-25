using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given an array of integers "nums" and an integer "k"
    /// return the total number of continuous subarrays whose sum equals to k.
    /// 
    /// https://leetcode.com/problems/subarray-sum-equals-k/
    /// </summary>
    class SubArrayEqualsK
    {
        public static void Test()
        {
            int[] nums = new int[] { 2, 1, 1 };
            int k = 2;

            SubArrayEqualsK solution = new SubArrayEqualsK();
            int r1 = solution.Solution(nums, k);
            Console.WriteLine(r1);

            int[] nums2 = new int[] { 3, 4, 7, 2, -3, 1, 4, 2 };
            int k2 = 7;

            int r2 = solution.Solution(nums2, k2);
            Console.WriteLine(r2);
        }

        private int Solution(int[] nums, int k)
        {
            throw new NotImplementedException();
        }
    }
}
