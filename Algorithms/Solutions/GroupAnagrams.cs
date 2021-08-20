using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given an array of strings strs, group the anagrams together. 
    You can return the answer in any order.

    An Anagram is a word or phrase formed by rearranging the letters 
    of a different word or phrase, typically using all the original letters exactly once.

    https://leetcode.com/problems/group-anagrams/
    */
    class GroupAnagramsSolution
    {
        public static void Test()
        {
            GroupAnagramsSolution solution = new GroupAnagramsSolution();

            List<string> strs = new List<string> { "eat", "tea", "tan", "ate", "nat", "bat" };

            solution.groupAnagrams(strs.ToArray()).ForEach(x => Console.WriteLine(string.Join(",", x)));
        }

        public List<List<string>> groupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return new List<List<string>>();
            }

            Dictionary<string, List<string>> answer = new Dictionary<string, List<string>>();
            int[] count = new int[26];

            foreach(string s in strs)
            {
                Array.Fill(count, 0);

                foreach (char c in s) count[c - 'a']++;

                StringBuilder sb = new StringBuilder();

                for(int i = 0; i < 26; i++)
                {
                    sb.Append("#");
                    sb.Append(count[i]);
                }

                string key = sb.ToString();
                if (!answer.ContainsKey(key))
                    answer.Add(key, new List<string>());

                answer[key].Add(s);
            }

            return new List<List<string>>(answer.Values);
        }
    }
}
