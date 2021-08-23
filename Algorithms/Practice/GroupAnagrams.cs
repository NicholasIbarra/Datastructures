using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
            throw new NotImplementedException();
        }
    }
}
