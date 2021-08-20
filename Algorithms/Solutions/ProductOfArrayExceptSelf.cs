using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
    The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

    You must write an algorithm that runs in O(n) time and without using the division operation.

    https://leetcode.com/problems/product-of-array-except-self/
    */
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

        private static int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;

            int[] L = new int[length];
            int[] R = new int[length];

            // Calcualte the products to the left
            L[0] = 1;
            
            for(int i = 1; i < length; i++)
            {
                L[i] = L[i - 1] * nums[i - 1];
            }
            
            // Calculate the products to the right
            R[length - 1] = 1;
            for (int i = length - 2; i >= 0; i--)
            {
                R[i] = R[i + 1] * nums[i + 1];
            }

            int[] answer = new int[length];

            // Calculate final answer
            for (int i = 0; i < length; i++)
            {
                answer[i] = L[i] * R[i];
            }

            return answer;
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
