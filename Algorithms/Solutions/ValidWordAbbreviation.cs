using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    A string can be abbreviated by replacing any number of non-adjacent substrings with their lengths. For example, a string such as "substitution" could be abbreviated as (but not limited to):

    "s10n" ("s ubstitutio n")
    "sub4u4" ("sub stit u tion")
    "12" ("substitution")
    "su3i1u2on" ("su bst i t u ti on")
    "substitution" (no substrings replaced)
    Note that "s55n" ("s ubsti tutio n") is not a valid abbreviation of "substitution" because the replaced substrings are adjacent.

    Given a string s and an abbreviation abbr, return whether the string matches with the given abbreviation.

    https://leetcode.com/problems/valid-word-abbreviation/
    */
    class ValidWordAbbreviationSolution
    {
        public static void Test()
        {
            ValidWordAbbreviationSolution solution = new ValidWordAbbreviationSolution();

            Console.WriteLine("internationalization, i12iz4n = " + solution.ValidWordAbbreviation("internationalization", "i12iz4n"));
            Console.WriteLine("apple, a2e = " + solution.ValidWordAbbreviation("apple", "a2e"));
        }

        public bool ValidWordAbbreviation(string word, string abbr)
        {

            int w = 0, a = 0;
            int num = 0;

            while (w < word.Length && a < abbr.Length)
            {
                if (char.IsNumber(abbr[a]))
                {
                    // number
                    num = (num * 10) + (abbr[a] - '0');
                    if (num == 0) return false;

                    a++;
                }
                else
                {
                    // character
                    w += num;
                    num = 0;

                    if (w >= word.Length || abbr[a] != word[w])
                    {
                        return false;
                    }
                    else
                    {
                        a++;
                        w++;
                    }
                }
            }

            return a == abbr.Length && w + num == word.Length;
        }
    }
}

