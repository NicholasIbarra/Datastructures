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
            List<IList<int>> result = new List<IList<int>>();

            RecursiveSearch(0, nums, result);

            return result;
        }

        private static void RecursiveSearch(int index, int[] nums, List<IList<int>> result)
        {
            if (index == nums.Length - 1)
            {
                // Returns the last element and empty set
                result.Add(new List<int> { });
                result.Add(new List<int> { nums[index] });
            }
            else
            {
                // Recursivsly call to last element
                RecursiveSearch(index + 1, nums, result);
                int n = result.Count;

                // Loop through current results and append nums[index]
                for (int i = 0; i < n; i++)
                {
                    List<int> subset = new List<int>(result[i]);

                    subset.Add(nums[index]);
                    result.Add(subset);
                }
            }
        }

        public static IList<IList<int>> IterativeSolution(int[] nums)
        {
            HashSet<string> seen = new HashSet<string>();
            List<IList<int>> result = new List<IList<int>>();

            // Initialize the empty set
            result.Add(new List<int>());

            // Iterate over nums (O(N))
            for (int i = 0; i < nums.Length; i++)
            {
                // Union results with result + num[i] O(2^n)
                int n = result.Count;
                string hashcode;

                for (int j = 0; j < n; j++)
                {
                    var subset = new List<int>(result[j]);
                    subset.Add(nums[i]);

                    hashcode = String.Join(",", subset);
                    
                    if (!seen.Contains(hashcode))
                    {
                        result.Add(subset); 
                        seen.Add(hashcode);
                    }
                }
            }

            return result;
        }

        public static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            Array.Sort(nums);

            List<IList<int>> result = new List<IList<int>>();

            DfsBacktracking(0, new List<int>(), nums, result);

            return result;
        }

        private static void DfsBacktracking(int start, List<int> subset, int[] nums, List<IList<int>> result)
        {
            result.Add(subset);

            for(int i = start; i < nums.Length; i++)
            {
                // Check for duplicates
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }

                subset.Add(nums[i]);
                DfsBacktracking(i + 1, new List<int>(subset), nums, result);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        public static IList<IList<int>> SampleSolution(int[] nums)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Use bit masking to generate all possible combinations
        /// Calcualte max number of subsets (total bitmasks)
        /// For each bitmask, loop over nums
        /// if jth is set add to subset
        /// 
        /// return subset
        /// O(n * n^2)
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> BitmaskingSolution(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return new List<IList<int>>();
            }

            int n = nums.Length;
            int max = (int)Math.Pow(2, n);

            var seen = new HashSet<string>();
            var results = new List<IList<int>>();

            for (int index = 0; index < max; index++)
            {
                List<int> subset = new List<int>();
                StringBuilder hashcode = new StringBuilder();

                for (int j = 0; j < n; j++)
                {
                    int mask = 1 << j;
                    int isSet = mask & index;

                    if (isSet != 0)
                    {
                        subset.Add(nums[j]);
                        hashcode.Append(nums[j]).Append(",");
                    }
                }

                if (!seen.Contains(hashcode.ToString()))
                {
                    results.Add(subset);
                    seen.Add(hashcode.ToString());
                }   
            }

            return results;
        }
    }
}
