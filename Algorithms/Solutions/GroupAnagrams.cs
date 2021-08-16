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
    class GroupAnagrams
    {
        public List<List<String>> groupAnagrams(String[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach(string s in strs)
            {
                char[] ca = s.ToCharArray();
                Array.Sort(ca);

                string key = string.Join(",", ca);
                if (!map.ContainsKey(key))
                    map.Add(key, new List<string>());

                map[key].Add(s);
            }

            return map.Values.ToList();
        }
    }
}
