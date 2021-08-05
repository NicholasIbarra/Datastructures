using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /// <summary>
    /// Given a characters array tasks, representing the tasks a CPU needs to do, where each letter represents 
    /// a different task. Tasks could be done in any order. Each task is done in one unit of time. 
    /// For each unit of time, the CPU could complete either one task or just be idle.
    /// 
    /// However, there is a non-negative integer n that represents the cooldown period between two same 
    /// tasks(the same letter in the array), that is that there must be at least n units of time between any two same tasks.
    /// Return the least number of units of times that the CPU will take to finish all the given tasks.
    /// 
    /// https://leetcode.com/problems/task-scheduler/
    /// </summary>
    public static class TaskScheduler
    {
        public static void Test()
        {
            var tasks = new char[] { 'A', 'B', 'A', 'A', 'B', 'C', 'A', 'A' };
            //var tasks = new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            // var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'D' };
            var cooldown = 2;

            Console.WriteLine(LeastInerval(tasks, cooldown));

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
            for (int i = 0; i < tasks.Length; i++)
            {
                freq[tasks[i] - 'A']++;
            }

            Array.Sort(freq);

            // Get most frequent and idle times
            int f_max = freq[25];
            int idle_max = (f_max - 1) * n;

            // Reduce idle_time with additiion task taht can tak that timeslot
            for (int i = freq.Length - 2; i >= 0 && idle_max > 0; i--)
            {
                idle_max -= Math.Min(f_max - 1, freq[i]);
            }

            // Ensure idle_time is not negative
            idle_max = Math.Max(0, idle_max);

            return tasks.Length + idle_max;
        }
    }
}
