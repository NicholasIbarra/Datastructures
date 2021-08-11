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
            List<int[]> result = new List<int[]>();

            int endIndex = int.MinValue;

            // O(log n)
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            // O(N - 1) -> O(N)
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] current = intervals[i];

                if (current[0] > endIndex)
                {
                    result.Add(current);
                    endIndex = current[1];
                }
                else if (current[1] > endIndex)
                {
                    result[result.Count - 1][1] = current[1];
                    endIndex = current[1];
                }
            }

            return result.ToArray();
        }
    }
}
