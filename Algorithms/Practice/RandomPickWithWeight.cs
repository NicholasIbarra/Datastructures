using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
        public static void Test()
        {
            int[] w = new int[2] { 1, 3 };
            Solution solution = new Solution(w);

            Console.WriteLine(solution.PickIndex());
            Console.WriteLine(solution.PickIndex());
        }

        public class Solution
        {
            public Solution(int[] w)
            {
            }

            public int PickIndex()
            {
                throw new NotImplementedException();
            }
        }
    }
}

/*
 public class Solution
        {
            public Solution(int[] w)
            {
            }

            public int PickIndex()
            {
                throw new NotImplementedException();
            }
        }

 */