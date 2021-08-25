using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
    /// The solution set must not contain duplicate subsets.Return the solution in any order.
    /// 
    /// https://leetcode.com/problems/subsets-ii/
    /// </summary>
    /// 
    class SubsetsII
    {
        public static void Test()
        {
            SubsetsII solution = new SubsetsII();

            int[] nums = new int[] { 1, 2, 3 };
            IList<IList<int>> result = solution.SubsetsWithDup(nums);

            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            throw new NotImplementedException();
        }
    }
}