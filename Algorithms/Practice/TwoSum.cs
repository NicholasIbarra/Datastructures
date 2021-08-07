using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// 
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    public static class TwoSum
    {
        public static void Test()
        {
            var array = new int[] { 3, 2, 4 };
            int sum = 6;

            //var array = new int[] { 2, 7, 11, 15 };
            //int sum = 9;

            var result = Solution(array, sum);

            if (result != null)
            {
                Console.WriteLine(result[0] + " ");
                Console.WriteLine(result[1] + " ");
            }
        }

        public static int[] Solution(int[] nums, int target)
        {
            throw new NotImplementedException();
        }

        /*
         public static int[] Solution(int[] nums, int target)
        {
            throw new NotImplementedException();
        }
        */
    }
}
