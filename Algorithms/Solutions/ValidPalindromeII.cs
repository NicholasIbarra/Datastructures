using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given a string s, return true if the s can be palindrome after deleting at most one character from it.
    https://leetcode.com/problems/valid-palindrome-ii/

     */
    class ValidPalindromeII
    {
        public static void Test()
        {
            List<string> words = new List<string> { "aba", "abca", "abc", "atbbga" };

            ValidPalindromeII solution = new ValidPalindromeII();

            foreach(var s in words)
            {
                Console.WriteLine(s + " " + solution.ValidPalindrome(s));
            }
        }

        public bool ValidPalindrome(string s)
        {
            if (s == null || s.Length <= 2)
            {
                return true;
            }

            int i = 0, j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return IsValid(s, i + 1, j) || IsValid(s, i, j - 1);
                }

                i++;
                j--;
            }

            return true;
        }

        private bool IsValid(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[++start] != s[--end])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
