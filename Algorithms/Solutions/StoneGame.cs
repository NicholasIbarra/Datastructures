using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /// <summary>
    /// Alex and Lee play a game with piles of stones.  There are an even number of piles arranged 
    /// in a row, and each pile has a positive integer number of stones piles[i].
    /// The objective of the game is to end with the most stones.The total number of 
    /// stones is odd, so there are no ties.
    /// 
    /// Alex and Lee take turns, with Alex starting first.  
    /// Each turn, a player takes the entire pile of stones from either the beginning or the end of the row.  
    /// This continues until there are no more piles left, at which point the person with the most stones wins.
    /// 
    /// Assuming Alex and Lee play optimally, return True if and only if Alex wins the game.
    /// 
    /// https://leetcode.com/problems/stone-game/
    /// </summary>
    static class StoneGame
    {
        public static void Test()
        {
            var piles = new int[] { 5, 3, 4, 5 };
            Console.WriteLine(DynamicProgrammingSolution(piles));
        }

        /// <summary>
        /// Solve via dynmic programming
        /// This is because you can break the problem into sub problems
        /// 
        /// Time complexity: O(n^2)
        /// Space complexity: O(n^2)
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public static bool DynamicProgrammingSolution(int[] piles)
        {
            return dp(0, piles.Length - 1, piles) > 0;
        }

        public static int dp(int i, int j, int[] piles)
        {
            if (i > j)
            {
                return 0;
            }

            if ((j - i) % 2 != 0)
            {
                // Alex turn
                return Math.Max(piles[i] + dp(i + 1, j, piles), piles[j] + dp(i, j - 1, piles));
            }
            else
            {
                // Lee turn
                return Math.Min(-piles[i] + dp(i + 1, j, piles), -piles[j] + dp(i, j - 1, piles));
            }
        }


        public static bool MathmaticalSolution(int[] piles)
        {
            // piles are always even and alex always goes first
            // if odd indexes are white and even are black, alex always has the option to take all black or all white
            return true;
        }

    }
}
