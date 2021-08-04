using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Solutions
{
    class SubsetsII
    {
        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 3 };
            var result = SubsetsWithDup(nums);
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            return RecursiveSolution(nums);
        }

        /// <summary>
        /// Solve powerset recussively by first checking if array is empty
        /// if Has values, go to last elemnt in the set and and return {} and {last num}
        /// Then union results with element n - 1
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

        public static IList<IList<int>> BacktrackingSolution(int[] nums)
        {
            var emptySEt = new List<int> { };

            if (nums.Length == 0)
            {
                return new List<IList<int>> { emptySEt };
            }

            // Sort so duplicates are next to each other
            Array.Sort(nums);
            Backtracking(0, new List<int>(), nums);

            return result;
        }

        public static void Backtracking(int start, IList<int> curr, int[] nums)
        {
            result.Add(new List<int>(curr));

            for(int i = start; i < nums.Length; i++)
            {
                // Check for duplicates by comparing if the current elemnt is the same as the previous
                // Check against starting element to ensure index 0 is accounted for
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }

                curr.Add(nums[i]);
                Backtracking(i + 1, curr, nums);

                curr.Remove(curr.Count - 1);
            }
        }
    }
}
