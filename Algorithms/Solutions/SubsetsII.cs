using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Solutions
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
            int[] nums = new int[] { 2, 1, 2 };
            var result = SubsetsWithDup(nums);
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = BitmaskingSolution(nums);
            result.ToList().ForEach(r => Console.WriteLine(string.Join(", ", r)));

            return result;
        }

        /// <summary>
        /// Solve powerset recussively by first checking if array is empty
        /// if Has values, go to last elemnt in the set and return {} and {last num}
        /// Then union results with element n
        /// Continue until reached first element
        /// 
        /// Time Complexity: O(n * s ^ (n - 1))
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> RecursiveSolution(int[] nums)
        {
            var emptySEt = new List<int> { };

            if (nums.Length == 0)
            {
                return new List<IList<int>> { emptySEt };
            }

            IList<IList<int>> result = new List<IList<int>>();

            SubsetRecur(nums, 0, result);

            return result;
        }

        private static void SubsetRecur(int[] nums, int index, IList<IList<int>> result)
        {
            if (index == nums.Length - 1)
            {
                // root Node, return empty set and last value
                result.Add(new List<int> { } );
                result.Add(new List<int> { nums[index] });
            }
            else
            {
                SubsetRecur(nums, index + 1, result);

                // Iterate over the current result set
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    List<int> current = new List<int>();

                    // Union current element and result item
                    current.AddRange(result[i]);
                    current.Add(nums[index]);

                    // append to final result
                    result.Add(current);
                }
            }
        }

        /// <summary>
        /// Solve using iterative approach 
        /// First init result with empty set and iterate over each item in nums
        /// For each element loop through the results creating a new list with 
        /// with the result and adding the element
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> IterativeSolution(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            // Initialize result with empty set
            var emptySet = new List<int> { };
            result.Add(emptySet);

            for (int i = 0; i < nums.Length; i++)
            {
                int n = result.Count;
                for (int j = 0; j < n; j++)
                {
                    List<int> current = new List<int>();

                    current.AddRange(result[j]);
                    current.Add(nums[i]);

                    result.Add(current);
                }
            }

            return result;
        }

        public static IList<IList<int>> result = new List<IList<int>>();

        /// <summary>
        /// Solve powerset using dfs backtracking solution
        /// First need to sort nums array so duplicates are in sequence and can be detected
        /// Then we traverse the tree adding a subset on each call
        /// For each level, we need to iterate through all the nums excluding duplicates
        /// Duplicates are identified by sequence numbers that are next to each other
        /// Duplicates should only be skipped after the first element is processed
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            var emptySEt = new List<int> { };

            if (nums.Length == 0)
            {
                return new List<IList<int>> { emptySEt };
            }

            // Sort so duplicates are next to each other
            Array.Sort(nums);

            var subset = new List<int>();

            Backtracking(0, subset, nums);

            return result;
        }

        public static void Backtracking(int start, List<int> subset, int[] nums)
        {
            result.Add(new List<int>(subset));
            Console.WriteLine(string.Join(", ", subset));

            for (int i = start; i < nums.Length; i++)
            {
                // Check for duplicates by comparing if the current elemnt is the same as the previous
                // Check against starting element to ensure index 0 is accounted for
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }

                subset.Add(nums[i]);
                Backtracking(i + 1, subset, nums);

                // Remove last item
                subset.RemoveAt(subset.Count - 1);
            }
        }

        /// <summary>
        /// Soive the powerset using bitmasking
        /// 
        /// Sort the nums array to identify duplicates
        /// Get max number of subets (n^2) and iterate from 0 to max
        /// Iterate over each element in nums
        /// if the jth value is set add to subset and create a hashcode (duplicates)
        /// If hascode doesn't exist, add and add subset to final results
        /// 
        /// Time: O(n * n^2)
        /// Space: O(n * n^2)
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> BitmaskingSolution(int[] nums)
        {
            var result = new List<IList<int>>();

            // Sort to identiy duplicates
            Array.Sort(nums);

            int n = nums.Length;
            int max = (int)Math.Pow(2, n);

            HashSet<string> seen = new HashSet<string>();

            for (var index = 0; index < max; index++)
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
                    result.Add(subset);
                    seen.Add(hashcode.ToString());
                }
            }

            return result;
        }

        public static IList<IList<int>> SampleSolution(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> subsets = new List<IList<int>>();
            subsets.Add(new List<int>());

            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                startIndex = 0;

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    startIndex = endIndex + 1;
                }

                endIndex = subsets.Count - 1;

                for (int j = startIndex; j <= endIndex; j++)
                {
                    IList<int> subset = new List<int>(subsets[j]);
                    subset.Add(nums[i]);
                    subsets.Add(subset);
                }
            }

            return subsets;
        }
    }
}
