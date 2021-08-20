using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
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

            //var i1 = new int[] { 1, 3 };
            //var i2 = new int[] { 2, 6 };
            //var i3 = new int[] { 8, 10 };
            //var i4 = new int[] { 15, 18 };

            //int[][] intervals = new int[][] { i1, i2, i3, i4 };

            var i1 = new int[] { 1, 4 };
            var i2 = new int[] { 0, 4 };
            
            int[][] intervals = new int[][] { i1, i2 };

            var result = solution.Merge(intervals);

            result.ToList().ForEach(i => Console.WriteLine(String.Join(",", i)));
        }

        public int[][] Merge(int[][] intervals)
        {
            LinkedList<int[]> result = new LinkedList<int[]>();

            if (intervals == null || intervals.Length == 0)
            {
                return result.ToArray();
            }

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            foreach (var current in intervals)
            {
                if (result.Count == 0 || result.Last()[0] < current[0])
                {
                    result.Append(current);
                }

                result.Last()[1] = Math.Max(result.Last()[1], current[1]);
            }

            return result.ToArray();
        }
    }
}
