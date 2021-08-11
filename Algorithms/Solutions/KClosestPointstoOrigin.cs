using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
        Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane 
        and an integer k, return the k closest points to the origin (0, 0).

        The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).

        You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).

        https://leetcode.com/problems/k-closest-points-to-origin/
    */
    class KClosestPointstoOrigin
    {
        public static void Test()
        {
            int[][] points = new int[2][]
            {
                new int[]{1, 3},
                new int[]{-2, 2}
            };

            int k = 1;

            KClosestPointstoOrigin solution = new KClosestPointstoOrigin();
            var result = solution.KClosest(points, k);

            result.ToList().ForEach(r => Console.WriteLine(string.Join(",", r)));
        }

        public int[][] KClosest(int[][] points, int k)
        {
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < points.Length; i++)
            {
                double distance = Math.Pow(Math.Pow((0 - points[i][0]), 2) + Math.Pow((0 - points[i][1]), 2), .5);
                Console.WriteLine(distance);
            }

            return result.ToArray();
        }
    }
}
