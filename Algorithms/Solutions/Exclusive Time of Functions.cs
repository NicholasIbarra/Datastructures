using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/exclusive-time-of-functions/
    // Run: O(n)
    // Space: O(n)
    class Exclusive_Time_of_Functions
    {
        public static void Test()
        {
            Exclusive_Time_of_Functions solution = new Exclusive_Time_of_Functions();

            Console.WriteLine(string.Join(" ", solution.ExclusiveTime(1, new List<string>() { "0:start:0", "0:end:0" })));
            Console.WriteLine(string.Join(" ", solution.ExclusiveTime(2, new List<string>() { "0:start:0", "1:start:2", "1:end:5", "0:end:6" })));
            Console.WriteLine(string.Join(" ", solution.ExclusiveTime(2, new List<string>() { "0:start:0", "0:start:2", "0:end:5", "1:start:6", "1:end:6", "0:end:7" })));
            Console.WriteLine(string.Join(" ", solution.ExclusiveTime(2, new List<string>() { "0:start:0", "0:start:2", "0:end:5", "1:start:7", "1:end:7", "0:end:8" })));
        }

        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            int[] result = new int[n];
            Stack<Log> stack = new Stack<Log>();

            foreach(string content in logs)
            {
                Log log = new Log(content);

                if (log.isStart)
                {
                    stack.Push(log);
                }
                else
                {
                    Log top = stack.Pop();
                    int runTime = (log.time - top.time + 1);

                    result[top.id] += runTime;

                    if (stack.Count > 0)
                    {
                        result[stack.Peek().id] -= runTime;
                    }
                }
            }


            return result;
        }

        public class Log
        {
            public int id;
            public bool isStart;
            public int time;

            public Log(string content)
            {
                string[] strs = content.Split(":");

                int.TryParse(strs[0], out id);
                isStart = strs[1].Equals("start");
                int.TryParse(strs[2], out time);
            }
        }
    }
}
