using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
     A valid number can be split up into these components (in order):

        A decimal number or an integer.
        (Optional) An 'e' or 'E', followed by an integer.
        A decimal number can be split up into these components (in order):

        (Optional) A sign character (either '+' or '-').
        One of the following formats:
        One or more digits, followed by a dot '.'.
        One or more digits, followed by a dot '.', followed by one or more digits.
        A dot '.', followed by one or more digits.
        An integer can be split up into these components (in order):

        (Optional) A sign character (either '+' or '-').
        One or more digits.
        For example, all the following are valid numbers: ["2", "0089", "-0.1", "+3.14", "4.", 
                "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"], 
    
        while the following are not valid numbers: 
            ["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"].

        Given a string s, return true if s is a valid number.

    https://leetcode.com/problems/valid-number/
    
     */
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

        private bool IsNumber(string input)
        {
            throw new NotImplementedException();
        }
    }
}
