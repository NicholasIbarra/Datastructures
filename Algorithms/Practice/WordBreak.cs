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
            Console.WriteLine(solution.Solution(input, dictionary));
        }

        private bool Solution(string input, List<string> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
