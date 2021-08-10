using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
        In an alien language, surprisingly they also use english lowercase letters, 
        but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

        Given a sequence of words written in the alien language, and the order of the alphabet, 
        return true if and only if the given words are sorted lexicographicaly in this alien language.

        https://leetcode.com/problems/verifying-an-alien-dictionary/
     * */
    public class VerifyinganAlienDictionary
    {
        public static void Test()
        {
            VerifyinganAlienDictionary solution = new VerifyinganAlienDictionary();

            string[] words = new string[] { "word", "world", "row" };
            string order = "worldabcefghijkmnpqstuvxyz";
            Console.WriteLine(solution.IsAlienSorted(words, order));

            string[] words2 = new string[] { "hello", "leetcode" };
            string order2 = "hlabcdefgijkmnopqrstuvwxyz";
            Console.WriteLine(solution.IsAlienSorted(words2, order2));

            string[] words3 = new string[] { "apple", "app" };
            string order3 = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine(solution.IsAlienSorted(words3, order3));

        }

        private bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, int> orderMap = new Dictionary<char, int>();

            for (int i = 0; i < order.Length; i++)
            {
                orderMap.Add(order[i], i);
            }

            // traverse
            // a > b > c, a > c
            for (int i = 0; i < words.Length - 1; i++)
            {
                // traverse the word
                for(int j = 0; j < words[i].Length; j++)
                {
                    // the word is longer then the next
                    if (j >= words[i + 1].Length) return false;

                    char a = words[i][j];
                    char b = words[i + 1][j];

                    // letters are differeint
                    if (a != b)
                    {
                        // in correct order
                        if (orderMap[a] > orderMap[b])
                            return false;
                        else
                            // out of order, stop
                            break;
                    }
                }
            }

            return true;
        }
    }
}
