using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    public class ValidNumber
    {
        public static void Test()
        {
            ValidNumber solution = new ValidNumber();

            List<string> validInput = new List<string>() { "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789", "4.", "+.8" };
            List<string> invalidInput = new List<string>() { "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53", "3+", ".", "4e+", "+." };

            Console.WriteLine("Should return true\n");

            foreach (string i in validInput)
            {
                var shouldBeTrue = solution.IsNumber(i).ToString();
                Console.WriteLine(i + " Result: " + shouldBeTrue);
            }

            Console.WriteLine("\nShould return false\n");

            foreach (string i in invalidInput)
            {
                Console.WriteLine(i + " Result: " + solution.IsNumber(i).ToString());
            }

            string input = "..2";
            Console.WriteLine(solution.IsNumber(input));
        }

        public bool IsNumber(string s)
        {
            throw new NotImplementedException();
        }
    }
}
