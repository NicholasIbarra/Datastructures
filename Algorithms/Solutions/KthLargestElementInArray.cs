using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given an integer array nums and an integer k, return the kth largest element in the array.

    Note that it is the kth largest element in the sorted order, not the kth distinct element.
    */
    class KthLargestElementInArray
    {
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

        public int QuickSelect(int[] nums, int k)
        {
            int lo = 0;
            int hi = nums.Length - 1;
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
                while (i < hi && less(nums[++i], nums[lo]));
                    while (j > lo && less(nums[lo], nums[--j]));
                        if (i >= j)
                        {
                            break;
                        }
                exch(nums, i, j);
            }
            exch(nums, lo, j);
            return j;
        }

        private void exch(int[] a, int i, int j)
        {
            int tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        private bool less(int v, int w)
        {
            return v < w;
        }
    }
}
