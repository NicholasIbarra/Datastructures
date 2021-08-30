using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/word-break/
    // Time complexity : O(n^3) -- For every starting index, the search can continue till the end of the given string.
    // Space complexity : O(n) -- Queue of at most nn size is needed.

    public class WordBreak
    {
        public static void Test()
        {
            string input = "catsandog";
            List<string> dictionary = new List<string> { "and", "cats", "dog", "sand", "cat" };

            //string input = "cars";
            //List<string> dictionary = new List<string> { "car", "ca", "rs" };

            WordBreak solution = new WordBreak();
            Console.WriteLine(solution.DynamicProgrammingSolution(input, dictionary));
        }

        public bool BreadthFirstSolution(string s, IList<string> wordDict)
        {
            Queue<int> queue = new Queue<int>();

            bool[] visited = new bool[s.Length];
            queue.Enqueue(0);

            while(queue.Count > 0)
            {
                int start = queue.Dequeue();
                if (visited[start])
                    continue;

                for(int end = start + 1; end <= s.Length;  end++)
                {
                    string substring = s.Substring(start, end - start);
                    if (wordDict.Contains(substring))
                    {
                        queue.Enqueue(end);
                        if (end == s.Length)
                        {
                            return true;
                        }
                    }
                }
                visited[start] = true;
            }
            
            return false;
        }

        public bool DynamicProgrammingSolution(string s, IList<string> wordDict)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true; // null string

            for (int i = 1; i <= s.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    string substring = s.Substring(j, i - j);
                    if (dp[j] && wordDict.Contains(substring))
                    {
                        dp[i] = true;
                        break; 
                    }
                }
            }

            return dp[s.Length];
        }
    }
}
