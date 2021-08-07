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
            int[] nums = new int[] { 1, 2, 2 };
            IList<IList<int>> result = BacktrackingSolution(nums);

            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        private static IList<IList<int>> Solution(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return result;

            int n = nums.Length;
            int power2n = (int)Math.Pow(2, n);
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < power2n; i++)
            {
                var subset = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    int mask = 1 << j;
                    int isSet = mask & i;

                    if (isSet != 0)
                    {
                        subset.Add(nums[j]);
                    }
                }

                var hashCode = String.Join(",", subset);

                if (!seen.Contains(hashCode))
                {
                    result.Add(subset);
                    seen.Add(hashCode);
                }
            }

            return result;
        }

        private static IList<IList<int>> RecursiveSolution(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return result;

            Dfs(0, result, nums);

            return result;
        }

        private static void Dfs(int level, IList<IList<int>> result, int[] nums)
        {
            if (level == nums.Length - 1)
            {
                result.Add(new List<int>());
                result.Add(new List<int> { nums[level] });
            }
            else
            {
                Dfs(level + 1, result, nums);

                int n = result.Count;
                for (int i = level; i < n; i++)
                {
                    List<int> subset = new List<int>(result[i]);

                    subset.Add(nums[level]);
                    result.Add(subset);
                }
            }
        }

        private static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return result;

            // Sort Array to identiy dupes
            Array.Sort(nums);

            BacktrackingDfs(0, new List<int>(), result, nums);

            return result;
        }

        private static void BacktrackingDfs(int startIndex, List<int> subset, List<IList<int>> result, int[] nums)
        {
            result.Add(new List<int>(subset));

            for (int i = startIndex; i < nums.Length; i++)
            {
                if (i > startIndex && nums[i] == nums[i - 1])
                {
                    continue;
                }

                subset.Add(nums[i]);
                BacktrackingDfs(i + 1, subset, result, nums);

                subset.RemoveAt(subset.Count - 1);
            }
        }
    }
}