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

            //var tasks = new char[] { 'A', 'B', 'A', 'A', 'B', 'C', 'A', 'A' };
            //var tasks = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'D' };
            var cooldown = 2;

            Console.WriteLine(Solution.LeastInterval(tasks, cooldown));

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

            public static int LeastInterval2(char[] tasks, int n)
            {
                // frequency of the tasks
                var frequency = new int[26];

                for (int i = 0; i < tasks.Length; i++)
                    frequency[tasks[i] - 'A']++;

                Array.Sort(frequency);

                int f_max = frequency[25];
                int idle_time = (f_max - 1) * n;

                for (int i = frequency.Length - 2; i >= 0 && idle_time > 0; i--)
                {
                    idle_time -= Math.Min(f_max - 1, frequency[i]);
                }

                idle_time = Math.Max(0, idle_time);

                return idle_time + tasks.Length;
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
            /// </summary>
            /// <param name="tasks"></param>
            /// <param name="n"></param>
            /// <returns></returns>
            public static int LeastInterval(char[] tasks, int n)
            {
                // Find Frequency of each letter
                int[] freq = new int[26];

                for(int i = 0; i < tasks.Length; i++)
                {
                    freq[tasks[i] - 'A']++;
                }

                Array.Sort(freq);

                int f_max = freq[25];
                int idle_max = (f_max - 1) * n;

                // Fill idle timeslots wiht as many tasks as possible
                // Must keep idle_max > 0

                for(var i = freq.Length - 2; i >= 0 && idle_max > 0; i--)
                {
                    // Handle duplicate max freqencies
                    // Most spots that can be taken is (f_max - 1)
                    //idle_max = idle_max - freq[i];
                    idle_max = idle_max - Math.Min(f_max - 1, freq[i]);
                }

                // Ensure idle time > 0
                idle_max = Math.Max(0, idle_max);

                return tasks.Length + idle_max;
            }
        }        
    }
}
