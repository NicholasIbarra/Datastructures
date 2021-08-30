using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/random-pick-index/
    // Time: O(n)
    // Space: O(1)
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
                int count = 0;
                int idx = 0;

                for (int i = 0; i < nums.Length; i++)
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
