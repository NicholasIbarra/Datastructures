using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/alien-dictionary/
    // Time: O(C), C = length of all words added togetehr
    // Space: O(1) 
    //        O(U + min(U^2, N)), U = unique letters, N = total items in list
    //        but since only 26 letters, will never be greater then O(26 ^ 2) == O(1)
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
            if (words == null || words.Length == 0)
                return string.Empty;

            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
            Dictionary<char, int> indegree = new Dictionary<char, int>();

            Queue<char> q = new Queue<char>();
            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
                foreach (var c in word)
                {
                    if (!graph.ContainsKey(c))
                        graph.Add(c, new List<char>());

                    if (!indegree.ContainsKey(c))
                        indegree.Add(c, 0);
                }


            for (int i = 0; i < words.Length - 1; i++)
            {
                int len = Math.Min(words[i].Length, words[i + 1].Length);
                bool found = false;

                for (int j = 0; j < len; j++)
                    if (words[i][j] != words[i + 1][j])
                    {
                        graph[words[i][j]].Add(words[i + 1][j]);

                        found = true;
                        break;
                    }

                if (!found && words[i].Length > words[i + 1].Length)
                    return string.Empty;
            }

            foreach (var l in graph.Values)
                foreach (var n in l)
                    indegree[n] += 1;

            foreach (var n in indegree.Keys)
                if (indegree[n] == 0)
                    q.Enqueue(n);

            while (q.Count > 0)
            {
                char cur = q.Dequeue();

                sb.Append(cur);

                foreach (var n in graph[cur])
                    if (--indegree[n] == 0)
                        q.Enqueue(n);
            }

            return sb.Length == indegree.Count ? sb.ToString() : string.Empty;
        }
    }
}
