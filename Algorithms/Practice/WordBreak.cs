using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    // https://leetcode.com/problems/word-break/
    // Time complexity: O(n^3) For every starting index, the search can continue till the end of the given string.
    // Space complexity: O(n)
    class WordBreak
    {
        public static void Test()
        {
            string input = "catsandog";
            List<string> dictionary = new List<string> { "and", "cats", "dog", "sand", "cat" };

            //string input = "cars";
            //List<string> dictionary = new List<string> { "car", "ca", "rs" };

            WordBreak solution = new WordBreak();
            Console.WriteLine(solution.Solution(input, dictionary));
        }

        private bool Solution(string s, List<string> wordDict)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[s.Length];

            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int start = queue.Dequeue();
                if (visited[start]) continue;

                for(int i = start + 1; i <= s.Length; i++)
                {
                    string substr = s.Substring(start, i - start);
                    if (wordDict.Contains(substr))
                    {
                        queue.Enqueue(i);

                        if (i == s.Length)
                        {
                            return true;
                        }
                    }
                }

                visited[start] = true;
            }

            return false;
        }
    }
}
