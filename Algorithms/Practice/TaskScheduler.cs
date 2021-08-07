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
            //var tasks = new char[] { 'A', 'B', 'A', 'A', 'B', 'C', 'A', 'A' };
            var tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            var cooldown = 2;

            Console.WriteLine(LeastInerval(tasks, cooldown));

        }

        public static int LeastInerval(char[] tasks, int n)
        {
            throw new NotImplementedException();
        }
    }
}
