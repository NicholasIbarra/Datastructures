using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
    // Run: O(n)
    // Space: O(n)
    class Minimum_Add_to_Make_Parentheses_Valid
    {
        public static void Test()
        {
            Minimum_Add_to_Make_Parentheses_Valid solution = new Minimum_Add_to_Make_Parentheses_Valid();

            Console.WriteLine(solution.MinAddToMakeValid("())"));
        }

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
