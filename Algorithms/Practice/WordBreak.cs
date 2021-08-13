using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    class WordBreak
    {
        public static void Test()
        {
            string input = "catsandog";
            List<string> dictionary = new List<string> { "and", "cats", "dog", "sand", "cat" };

            //string input = "cars";
            //List<string> dictionary = new List<string> { "car", "ca", "rs" };

            WordBreak solution = new WordBreak();
            Console.WriteLine(solution.DynamicProgrammingSolution(input, dictionary));
        }

        private bool DynamicProgrammingSolution(string s, List<string> dictionary)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string substring = s.Substring(j, i - j);
                    if (dp[j] && dictionary.Contains(substring))
                    {
                        Console.WriteLine("[X]" + substring + " dp[j]: " + j + dp[j] + " dp[i]:" + i + dp[i]);
                        dp[i] = true;
                        break;
                    }

                    Console.WriteLine("[ ]" + substring + " dp[j]: " + j + dp[j] + " dp[i]:" + i + dp[i]);
                }
                Console.WriteLine("--------------------------");
            }

            return dp[s.Length];
        }
    }
}
