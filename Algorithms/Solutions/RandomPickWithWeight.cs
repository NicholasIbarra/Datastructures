using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     You are given an array of positive integers w where w[i] describes the weight of ith index (0-indexed).

    We need to call the function pickIndex() which randomly returns an integer 
    in the range [0, w.length - 1]. pickIndex() should return the integer proportional to its
    weight in the w array. For example, for w = [1, 3], the probability of picking the 
    index 0 is 1 / (1 + 3) = 0.25 (i.e 25%) while the probability of 
    picking the index 1 is 3 / (1 + 3) = 0.75 (i.e 75%).

    More formally, the probability of picking index i is w[i] / sum(w).

    https://leetcode.com/problems/random-pick-with-weight/
    */
    class RandomPickWithWeight
    {
        static Random random = new Random();

        public static void Test()
        {
            Console.WriteLine(random.NextDouble());
        }

        public class Solution
        {
            private int[] prefixSums;
            private int totalSums;

            static Random random = new Random();

            public Solution(int[] w)
            {
                prefixSums = new int[w.Length];

                int prefixSum = 0;
                for (int i = 0; i < w.Length; ++i)
                {
                    prefixSum += w[i];
                    prefixSums[i] = prefixSum;
                }

                this.totalSums = prefixSum;
            }

            public int PickIndex()
            {
                double target = this.totalSums * random.NextDouble();

                // binary search

                int low = 0, high = this.prefixSums.Length;

                while (low < high)
                {
                    // avoid overflow
                    int mid = low + (high - low) / 2;

                    if (target > this.prefixSums[mid])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid;
                    }
                }

                return low;
            }
        }
    }
}
