using Datastructure.Solutions;
using System;
using System.Collections.Generic;

namespace Datastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var array = new int[] { 3, 2, 4 };
            //var result = Solution.TwoSum(array, 6);

            //if (result != null)
            //{
            //    Console.WriteLine(result[0] + " ");
            //    Console.WriteLine(result[1] + " ");
            //}

            var tasks = new char[] { 'A', 'B', 'A', 'A', 'B', 'C', 'A', 'A' };
            //var tasks = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            // var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'D' };
            var cooldown = 2;

            //Console.WriteLine(Solution.LeastInerval(tasks, cooldown));

            AddTwoNumbers.Test1();

        }

        public class Solution
        {
            public static int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> seen = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int b = nums[i];
                    int a = target - b;

                    if (seen.ContainsKey(a))
                    {
                        return new int[] { seen[a], i };
                    }

                    seen.Add(b, i);
                }

                return null;
            }



            /// <summary>
            /// Total CPU intervals is determined by busy and idle item slots
            /// Busy timeslots is defined by the total tasks (len(Tasks))
            /// Idle timeslots is bound by the frequency of the most frequency task (idle_time <= (f_max - 1) * n)
            /// 
            /// 1. Get frequency of each tasks in array[26]
            /// 2. Sort decending order and most frequent task (f_max)
            /// 3. Iterate descending list decreasing idle_time min(f_max - 1, f)
            /// 4. Return len(tasks) + idel_time
            ///
            /// https://leetcode.com/problems/task-scheduler/
            /// 
            /// </summary>
            /// <param name="tasks"></param>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int LeastInerval(char[] tasks, int n)
            {
                // Leasst Interval = total Tasks + idle_time
                // Total tasks = tasks.length
                // Idle_time = (f_max - 1) * n

                // Sort tasks by frequency

                int[] freq = new int[26]; 
                for( int i = 0; i < tasks.Length; i++)
                {
                    freq[tasks[i] - 'A']++;
                }

                Array.Sort(freq);

                // Get most frequent and idle times
                int f_max = freq[25];
                int idle_max = (f_max - 1) * n;

                // Reduce idle_time with additiion task taht can tak that timeslot
                for(int i = freq.Length - 2; i >= 0 && idle_max > 0; i--)
                {
                    idle_max -= Math.Min(f_max - 1, freq[i]);
                }

                // Ensure idle_time is not negative
                idle_max = Math.Max(0, idle_max);

                return tasks.Length + idle_max;
            }
        }        
    }
}
