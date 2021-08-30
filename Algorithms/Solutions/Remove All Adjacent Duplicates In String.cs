using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/

    // Run: O(N)
    // Space: O(N - dupes)
    class Remove_All_Adjacent_Duplicates_In_String
    {
        public string RemoveDuplicates(string s)
        {
            StringBuilder sb = new StringBuilder();
            int sbLength = 0;

            foreach(char c in s.ToCharArray())
            {
                if (sbLength != 0 && c == sb[sbLength - 1])
                {
                    sb.Remove(sbLength- 1, 1);
                    sbLength--;
                }
                else
                {
                    sb.Append(c);
                    sbLength++;
                }
            }

            return sb.ToString();
        }
    }
}
