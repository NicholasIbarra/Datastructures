﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
    /// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3870/
    /// </summary>
    static class StoneGame
    {
        public static void Test()
        {
            var piles = new int[] { 5, 3, 4, 5 };
            Console.WriteLine(Solution(piles));
        }

        private static bool Solution(int[] piles)
        {
            throw new NotImplementedException();
        }
    }
}
