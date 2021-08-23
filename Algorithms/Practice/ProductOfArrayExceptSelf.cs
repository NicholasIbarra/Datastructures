using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
            ProductOfArrayExceptSelf solution = new ProductOfArrayExceptSelf();

            List<List<int>> tests = new List<List<int>>()
            {
                new List<int>() {1, 2, 3, 4},
                new List<int>() {-1,1,0,-3,3}
            };

            foreach(var test in tests)
            {
                int[] result = solution.ProductExceptSelf(test.ToArray());
                Console.WriteLine(string.Join(",", result));
            }
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            throw new NotImplementedException();
        }
    }
}
