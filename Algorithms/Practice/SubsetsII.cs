using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
    /// The solution set must not contain duplicate subsets.Return the solution in any order.
    /// </summary>
    /// 
    class SubsetsII
    {
        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 2 };
            var result = IterativeSolution(nums);

            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        public static IList<IList<int>> ReursiveSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> IterativeSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> SampleSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> BitmaskingSolution(int[] nums)
        {
            throw new NotImplementedException();
        }
    }
}

/*
        public static IList<IList<int>> ReursiveSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        private static void RecursiveSearch(int index, int[] nums, List<IList<int>> result)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> IterativeSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> SampleSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        public static IList<IList<int>> BitmaskingSolution(int[] nums)
        {
            throw new NotImplementedException();
        }
 */