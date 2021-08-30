using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
    class Minimum_Add_to_Make_Parentheses_Valid
    {
        public int MinAddToMakeValid(string s)
        {
            int ans = 0, bal = 0;

            for (int i = 0; i < s.Length; i++)
            {
                bal += s[i] == '(' ? 1 : -1;

                if (bal == -1)
                {
                    ans++;
                    bal++;
                }
            }

            return ans + bal;
        }
    }
}
