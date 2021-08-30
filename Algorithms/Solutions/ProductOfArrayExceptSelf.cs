using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/product-of-array-except-self/
    // time: O(n)
    // Space: O(n)
    class ProductOfArrayExceptSelf
    {
        public static void Test()
        {
            List<List<int>> tests = new List<List<int>>()
            {
                new List<int>() {1, 2, 3, 4},
                new List<int>() {-1,1,0,-3,3}
            };

            foreach(var test in tests)
            {
                int[] result = ProductExceptSelfConstantSpace(test.ToArray());
                Console.WriteLine(string.Join(",", result));
            }
        }

        private static int[] ProductExceptSelfConstantSpace(int[] nums)
        {
            int length = nums.Length;
            int[] answer = new int[length];

            // Calcualte the products to the left
            answer[0] = 1;

            for (int i = 1; i < length; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // Calculate the products to the right
            int R = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                answer[i] = answer[i] * R;
                R *= nums[i];
            }

            return answer;
        }
    }
}
