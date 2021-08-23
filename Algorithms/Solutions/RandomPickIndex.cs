using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given an integer array nums with possible duplicates, randomly output the index of a given target number. You can assume that the given target number must exist in the array.

    Implement the Solution class:

    Solution(int[] nums) Initializes the object with the array nums.
    int pick(int target) Picks a random index i from nums where nums[i] == target. If there are multiple valid i's, then each index should have an equal probability of returning.

    https://leetcode.com/problems/random-pick-index/

     */
    class RandomPickIndex
    {
        public static void Test()
        {
            Solution solution = new Solution(new int[] {1, 2, 3, 3 });

            Console.WriteLine("3" + solution.Pick(3));
            Console.WriteLine("1" + solution.Pick(1));
            Console.WriteLine("3" + solution.Pick(3));
        }

        public class Solution
        {

            private int[] nums;
            private Random rand;

            public Solution(int[] nums)
            {
                this.nums = nums;
                rand = new Random();
            }

            public int Pick(int target)
            {
                int n = this.nums.Length;
                int count = 0;
                int idx = 0;

                for (int i = 0; i < n; i++)
                {
                    if (this.nums[i] == target)
                    {
                        count++;
                        if (rand.Next(count) == 0)
                        {
                            idx = i;
                        }
                    }
                }

                return idx;
            }
        }

    }

    /*
     public class Solution {

    public Solution(int[] nums) 
    {
        
    }
    
    public int Pick(int target) 
    {
        throw new NotImplementedException();
    }
}

     */
}
