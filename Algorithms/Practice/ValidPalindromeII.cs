using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
     Given a string s, return true if the s can be palindrome after deleting at most one character from it.
    https://leetcode.com/problems/valid-palindrome-ii/

     */
    class ValidPalindromeII
    {
        public static void Test()
        {
            List<string> words = new List<string> { "atbbga", "aba", "abca", "abc", "atbbga" };

            ValidPalindromeII solution = new ValidPalindromeII();

            foreach (var s in words)
            {
                Console.WriteLine(s + " " + solution.ValidPalindrome(s));
            }
        }

        private bool ValidPalindrome(string s)
        {
            throw new NotImplementedException();
        }
    }
}
