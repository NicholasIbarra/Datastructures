using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /// <summary>
    /// Given a string s and a dictionary of strings wordDict, return true 
    /// if s can be segmented into a space-separated sequence of one or more dictionary words.
    /// Note that the same word in the dictionary may be reused multiple times in the segmentation.
    /// 
    /// https://leetcode.com/problems/word-break/
    /// </summary>
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
            HashSet<string> wordDictSet = new HashSet<string>(wordDict);
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
                    if (wordDictSet.Contains(substring))
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
