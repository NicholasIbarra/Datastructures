using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
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
            Dictionary<char, int> orderSorted = new Dictionary<char, int>();

            // O(26)
            for (int i = 0; i < order.Length; i++ )
            {
                orderSorted.Add(order[i], i);
            }

            // O(N)
            for (int start = 0; start < words.Length; start++)
            {
                for (int end = start + 1; end < words.Length; end++)
                {
                    if (!Compare(words[start], words[end], orderSorted))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Compare(string word1, string word2, Dictionary<char, int> orderSorted)
        {
            for(int i = 0; i < Math.Min(word1.Length, word2.Length); i ++)
            {
                int diff = orderSorted[word2[i]] - orderSorted[word1[i]];
                
                if (diff == 0)
                {
                    continue;
                }

                return diff >= 0;
            }

            return word1.Length <= word2.Length;
        }

        public bool AdjustCompareSolution(string[] words, string order)
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

                    if (words[i][j] != words[i][j])
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
