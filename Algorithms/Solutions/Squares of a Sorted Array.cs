using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/squares-of-a-sorted-array/
    class Squares_of_a_Sorted_Array
    {
        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int left = 0, right = n - 1;

            for (int i = n - 1; i >= 0; i--)
            {
                int square;

                if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
                {
                    square = nums[right];
                    right--;
                }
                else
                {
                    square = nums[left];
                    left++;
                }

                result[i] = square * square;
            }

            return result;
        }
    }
}
