using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
        You are given two lists of closed intervals, firstList 
        and secondList, where firstList[i] = [starti, endi] and secondList[j] = [startj, endj]. 
        Each list of intervals is pairwise disjoint and in sorted order.

        Return the intersection of these two interval lists.

        A closed interval [a, b] (with a < b) denotes the set of real numbers x with a <= x <= b.

        The intersection of two closed intervals is a set of real numbers 
        that are either empty or represented as a closed interval. For example, 
        the intersection of [1, 3] and [2, 4] is [2, 3].

        https://leetcode.com/problems/interval-list-intersections/
    */
    class Interval_List_Intersections
    {
        public static void Tes()
        {
            int[][] firstList = new int[][]
            {
                new int[]{ 0, 2 },
                new int[]{ 5, 10 },
                new int[]{ 13,23 },
                new int[]{ 24,25 }
            };

            int[][] secondList = new int[][]
            {
                new int[]{ 1,5 },
                new int[]{ 8,12 },
                new int[]{ 15,24 },
                new int[]{ 25, 26 }
            };

            Interval_List_Intersections solution = new Interval_List_Intersections();

            solution.IntervalIntersection(firstList, secondList);
        }

        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> merged = new List<int[]>();
            int i = 0, j = 0;

            while (i < firstList.Length && j < secondList.Length)
            {
                /// Check if firstList intersections B
                int lo = Math.Max(firstList[i][0], secondList[j][0]);
                int hi = Math.Max(firstList[i][1], secondList[j][1]);

                if (lo <= hi)
                {
                    merged.Add(new int[] { lo, hi });
                }

                // Remove the interface with the samllest endpoint
                if (firstList[i][1] < secondList[j][1])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return merged.ToArray();
        }
    }
}
