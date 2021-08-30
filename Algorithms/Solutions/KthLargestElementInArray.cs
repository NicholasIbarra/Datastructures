using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/kth-largest-element-in-an-array/
    // time: Average, O(N) worst O(n^2)
    // Space: O(1)

    class KthLargestElementInArray
    {
        static Random random = new Random();

        public static void Test()
        {
            KthLargestElementInArray solution = new KthLargestElementInArray();

            int[] nums = new int[] { 3, 2, 1, 5, 6, 4 };
            int k = 2;

            Console.WriteLine("Expect 5: " + solution.FindKthLargest(nums, k));
            Console.WriteLine("Expect 4: " + solution.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
        }

        public int FindKthLargest(int[] nums, int k)
        {
            // https://en.wikipedia.org/wiki/Quickselect
            return QuickSelect(nums, nums.Length - k);
        }

        private int QuickSelect(int[] nums, int k)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            //shuffle(nums);

            while (lo < hi)
            {
                int j = partition(nums, lo, hi);
                if (j < k)
                {
                    lo = j + 1;
                }
                else if (j > k)
                {
                    hi = j - 1;
                }
                else
                {
                    break;
                }
            }

            return nums[k];
        }

        private int partition(int[] nums, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;

            while (true)
            {
                while (i < hi && nums[++i] < nums[lo]) ;
                while (j > lo && nums[lo] < nums[--j]) ;

                if (i >= j)
                {
                    break;
                }

                exch(nums, i, j);
            }

            exch(nums, lo, j);
            return j;
        }


        private void shuffle(int[] a)
        {
            for (int ind = 1; ind < a.Length; ind++)
            {
                int r = random.Next(ind + 1);
                exch(a, ind, r);
            }
        }

        private void exch(int[] nums, int i, int j)
        {
            int tmp = nums[i];

            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
