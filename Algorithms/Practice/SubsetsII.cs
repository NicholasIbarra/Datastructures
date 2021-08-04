using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datastructure.Algorithms.Practice
{
    class SubsetsII
    {
        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 3 };
            SubsetsWithDup(nums);
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            //var result = BacktrackingSolution(nums);
            //var result = ReursiveSolution(nums);
            var result = IterativeSolution(nums);

            result.ToList().ForEach(x => Console.WriteLine(string.Join(", ", x)));             
            return result;
        }

        /// <summary>
        /// Determine powerset by recursion
        /// First traverse to last element to add {} & nums[last] to results
        /// Then union results with nums[index]
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ReursiveSolution(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return new List<IList<int>>();
            }

            var results = new List<IList<int>>();

            RecursivePowerSet(0, results, nums);

            return results;
        }

        private static void RecursivePowerSet(int index, List<IList<int>> results, int[] nums)
        {
            if (index == nums.Length - 1)
            {
                // Add leaf nodes
                results.Add(new List<int> { });
                results.Add(new List<int> { nums[index] });
            }
            else
            {
                RecursivePowerSet(index + 1, results, nums);

                int n = results.Count;

                for (int i = 0; i < n; i++)
                {
                    var subset = new List<int>(results[i]);

                    subset.Add(nums[index]);
                    results.Add(subset);
                }
            }
        }

        /// <summary>
        /// Soluve via standard iteration
        /// 1. Initialize results with empty set
        /// 2. For each element in nums
        ///     1. Union results with elemnt
        ///     2. Add element to results
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> IterativeSolution(int[] nums)
        {
            var results = new List<IList<int>>();

            // Add empty set
            results.Add(new List<int>());

            for (int i = 0; i < nums.Length; i++)
            {
                int n = results.Count();
                for (int j = 0; j < n; j++)
                {
                    var subset = new List<int>(results[j]);

                    subset.Add(nums[i]);
                    results.Add(subset);
                }
            }

            return results;
        }

        /// <summary>
        /// Return the powerset by implementing a dfs backtracking alogrithm
        /// First, check if nums is empty
        /// Second, sort the nums array so duplicates will be in sequence
        /// 
        /// Add subset to results
        /// 
        /// Iterate from 0 to n - 1
        ///     1. Check if the elemnt is a duplicate already processed (i.e. no the first element)
        ///     2. Add element to subset
        ///     3. Recursivly call dfs to next level
        ///     4. Remove the lement from subset to processing next branch
        ///     
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return new List<IList<int>> ();
            }

            // Sort so duplicatse in sequence can be identified by n-1
            Array.Sort(nums);

            var results = new List<IList<int>>();
            var subset = new List<int>();

            Dfs(0, results, subset, nums);

            return results;
        }

        private static void Dfs(int start, List<IList<int>> results, List<int> subset, int[] nums)
        {
            // Add the subset to results
            results.Add(new List<int>(subset));
            Console.WriteLine(string.Join(", ", subset));

            // Iterate over nums
            for (int i = start; i < nums.Length; i++)
            {
                // Check for duplicates after atleast the first element is processed
                if (i > start && nums[i] == nums[i - 1])
                {
                    // Duplicate element, skip
                    continue;
                }

                subset.Add(nums[i]);
                Dfs(i + 1, results, subset, nums);

                // Remove last element to process next branch
                subset.RemoveAt(subset.Count - 1);
            }
        }
    }
}
