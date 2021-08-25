using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     
    HARD
    
    There is a new alien language that uses the English alphabet. However, the order among the letters is unknown to you.

    You are given a list of strings words from the alien language's dictionary, where the strings in words are sorted lexicographically by the rules of this new language.

    Return a string of the unique letters in the new alien language sorted in lexicographically increasing 
    order by the new language's rules. If there is no solution, return "". If there are multiple solutions, return any of them.

    A string s is lexicographically smaller than a string t if at the first letter where they differ, 
    the letter in s comes before the letter in t in the alien language. If the first min(s.length, t.length) l
    etters are the same, then s is smaller if and only if s.length < t.length.

    https://leetcode.com/problems/alien-dictionary/
    */
    class AlienDictionary
    {
        public static void Test()
        {
            string[] words = new string[] { "wrt", "wrf", "er", "ett", "rftt" };

            AlienDictionary solution = new AlienDictionary();
            Console.WriteLine(solution.AlienOrder(words));
        }

        public string AlienOrder(string[] words)
        {
            // Step 0: create data structure and fin all unique letters
            Dictionary<char, List<char>> adjList = new Dictionary<char, List<char>>();
            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach(string word in words)
            {
                foreach(char c in word)
                {
                    counts.Add(c, 0);
                    adjList.Add(c, new List<char>());
                }
            }

            // Step 1: Find All Edges
            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];

                // Check that word2 is not a prefix of word 1
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return "";
                }

                // Find the first non match and isnert the correspondign relation
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        adjList[word1[j]].Add(word2[j]);
                        counts.Add(word2[j], counts[word2[j]] + 1);
                        break;
                    }
                }
            }

            // Step 2: Breadth-first search
            StringBuilder sb = new StringBuilder();
            Queue<char> queue = new Queue<char>();

            foreach(char c in counts.Keys)
            {
                if (counts[c].Equals(0))
                {
                    queue.Enqueue(c);
                }
            }

            while(queue.Count > 0)
            {
                char c = queue.Dequeue();
                sb.Append(c);
                
                foreach(char next in adjList[c])
                {
                    counts.Add(next, counts[next] - 1);
                    if (counts[next].Equals(0))
                    {
                        {
                            queue.Enqueue(next);
                        } }
                }
            }

            if (sb.Length < counts.Count)
            {
                return "";
            }

            return sb.ToString();
        }
    }
}
