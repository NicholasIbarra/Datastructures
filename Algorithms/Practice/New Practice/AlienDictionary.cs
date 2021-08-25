using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{

    /*
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
            throw new NotImplementedException();
        }
    }
}
