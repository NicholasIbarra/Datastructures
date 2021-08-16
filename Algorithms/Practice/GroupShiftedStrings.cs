using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
    We can shift a string by shifting each of its letters to its successive letter.

    For example, "abc" can be shifted to be "bcd".
    We can keep shifting the string to form a sequence.

    For example, we can keep shifting "abc" to form the sequence: "abc" -> "bcd" -> ... -> "xyz".
    Given an array of strings strings, group all strings[i] that belong to the same shifting sequence. 
    You may return the answer in any order.

    https://leetcode.com/problems/group-shifted-strings/
    */
    class GroupShiftedStrings
    {
        public static void Test()
        {

            GroupShiftedStrings soltuion = new GroupShiftedStrings();

            string[] strings = new string[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" };

            var result = soltuion.GroupStrings(strings);

            result.ToList().ForEach(s => Console.WriteLine(string.Join(",", s)));

        }

        private IList<IList<string>> GroupStrings(string[] strings)
        {
            throw new NotImplementedException();
        }
    }
}
