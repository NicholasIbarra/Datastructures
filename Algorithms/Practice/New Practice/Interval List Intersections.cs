using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice.New_Practice
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
            throw new NotImplementedException();
        }
    }
}
