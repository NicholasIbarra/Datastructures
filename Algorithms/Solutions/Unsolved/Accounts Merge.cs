using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given a list of accounts where each element accounts[i] 
    is a list of strings, where the first element accounts[i][0] 
    is a name, and the rest of the elements are emails representing emails of the account.

    Now, we would like to merge these accounts. Two accounts definitely 
    belong to the same person if there is some common email to both accounts. 
    Note that even if two accounts have the same name, they may belong to different 
    people as people could have the same name. A person can have any number of accounts 
    initially, but all of their accounts definitely have the same name.

    After merging the accounts, return the accounts in the following 
    format: the first element of each account is the name, and the rest of 
    the elements are emails in sorted order. The accounts themselves can be returned in any order.

    https://leetcode.com/problems/accounts-merge/
    */
    class Accounts_Merge
    {
        public static void Test()
        {
            Accounts_Merge soltuion = new Accounts_Merge();

            var accounts = new List<IList<string>>()
            {
                new List<string>(){ "John","johnsmith@mail.com","john_newyork@mail.com"},
                new List<string>(){ "John", "johnsmith@mail.com", "john00@mail.com" },
                new List<string>(){ "Mary", "mary@mail.com" },
                new List<string>(){ "John","johnnybravo@mail.com" }
            };

            soltuion.AccountsMerge(accounts).ToList().ForEach(a =>
            {
                Console.WriteLine(string.Join(",", a));
            });
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, IList<string>> merged = new Dictionary<string, IList<string>>();

            if (merged == null || merged.Count == 0)
            {
                return new List<IList<string>>(merged.Values);
            }

            foreach(var account in accounts)
            {
                string name = account[0];
                account.Skip(1);

                if (!merged.ContainsKey(name))
                {
                    merged.Add(name, account);
                }
                else
                {

                }

            }


            return new List<IList<string>>(merged.Values);
        }
    }
}
