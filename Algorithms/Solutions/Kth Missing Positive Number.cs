using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/kth-missing-positive-number/
    class Kth_Missing_Positive_Number
    {
        public int FindKthPositive(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] - mid - 1 < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left + k;
        }
    }
}
