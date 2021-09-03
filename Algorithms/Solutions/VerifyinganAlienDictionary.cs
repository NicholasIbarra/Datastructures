using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
        In an alien language, surprisingly they also use english lowercase letters, 
        but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

        Given a sequence of words written in the alien language, and the order of the alphabet, 
        return true if and only if the given words are sorted lexicographicaly in this alien language.

        https://leetcode.com/problems/verifying-an-alien-dictionary/
     * */
    class VerifyinganAlienDictionary
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

        public bool IsAlienSorted(string[] words, string order)
        {
            int[] orderMap = new int[26];

            for (int i = 0; i < order.Length; i++)
            {
                orderMap[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    // World is longer then next
                    if (j >= words[i + 1].Length) return false;

                    if (words[i][j] != words[i + 1][j])
                    {
                        int currentWordChar = words[i][j] - 'a';
                        int nextWordChar = words[i + 1][j] - 'a';

                        if (orderMap[currentWordChar] > orderMap[nextWordChar])
                        {
                            return false;
                        }
                        else
                        {
                            // if we find the first different letter and they are sorted,
                            // then there's no need to check remaining letters
                            break;
                        }
                    }
                }
            }

            return true;
        }
    }
}
