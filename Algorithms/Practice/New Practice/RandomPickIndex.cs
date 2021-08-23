using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
            Solution solution = new Solution(new int[] { 1, 2, 3, 3 });

            Console.WriteLine("3" + solution.Pick(3));
            Console.WriteLine("1" + solution.Pick(1));
            Console.WriteLine("3" + solution.Pick(3));
        }

        public class Solution
        {
            public Solution(int[] nums)
            {

            }

            public int Pick(int target)
            {
                throw new NotImplementedException();
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