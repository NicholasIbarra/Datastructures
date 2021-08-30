using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
    /// and return an array of the non-overlapping intervals that cover all the intervals in the input.
    /// 
    /// https://leetcode.com/problems/merge-intervals/
    /// </summary>
    public class MergeIntervals
    {
        public static void Test()
        {
            MergeIntervals solution = new MergeIntervals();

            var ii1 = new int[] { 1, 3 };
            var ii2 = new int[] { 2, 6 };
            var ii3 = new int[] { 8, 10 };
            var ii4 = new int[] { 15, 18 };

            int[][] intervals1 = new int[][] { ii1, ii2, ii3, ii4 };

            solution.Merge(intervals1).ToList().ForEach(i => Console.WriteLine(String.Join(",", i)));

            var i1 = new int[] { 1, 4 };
            var i2 = new int[] { 0, 4 };

            int[][] intervals = new int[][] { i1, i2 };

            var result = solution.Merge(intervals);

            result.ToList().ForEach(i => Console.WriteLine(String.Join(",", i)));
        }

        public int[][] Merge(int[][] intervals)
        {
            // O(log n)
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> result = new List<int[]>();

            int last = int.MinValue;

            // O(n)
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] current = intervals[i];

                if (last < current[0])
                {
                    result.Add(current);
                }
                else if (last < current[1])
                {
                    result.Last()[1] = Math.Max(result.Last()[1], current[1]);
                }

                last = result.Last()[1];
            }

            return result.ToArray();
        }
    }
}
