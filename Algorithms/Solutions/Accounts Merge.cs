using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/accounts-merge/
    // 
    // Time: O(nlogn) because of Union Find & List<>.Sort()
    // Space: O(n)
    // n = length of all email addresses

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

        private int findParent(int i, int[] accP)
        {
            if (accP[i] != i) accP[i] = findParent(accP[i], accP);
            return accP[i];
        }

        private void union(int i, int j, int[] accP, int[] accCnt)
        {
            int iP = findParent(i, accP);
            int jP = findParent(j, accP);
            if (iP != jP)
            {
                if (accCnt[iP] >= accCnt[jP])
                {
                    accP[jP] = iP;
                    accCnt[iP] += accCnt[jP];
                    accCnt[jP] = 0;
                }
                else
                {
                    accP[iP] = jP;
                    accCnt[jP] += accCnt[iP];
                    accCnt[iP] = 0;
                }
            }
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] acc = new string[accounts.Count];
            int[] accCnt = new int[accounts.Count];
            int[] accP = new int[accounts.Count];

            for (int i = 0; i < accounts.Count; i++)
            {
                acc[i] = accounts[i][0];
                accCnt[i] = accounts[i].Count - 1;
                accP[i] = i;
                int accI = i;
                for (int j = 1; j < accounts[i].Count; j++)
                {
                    if (dic.ContainsKey(accounts[i][j]))
                    {
                        union(dic[accounts[i][j]], accI, accP, accCnt);
                    }
                    else dic.Add(accounts[i][j], accI);
                }
            }
            int[] accMap = new int[acc.Length];
            int mapCnt = 0;
            IList<IList<string>> ansList = new List<IList<string>>();
            for (int i = 0; i < accCnt.Length; i++)
            {
                if (accCnt[i] > 0)
                {
                    accMap[i] = mapCnt;
                    ansList.Add(new List<string>());
                    ansList[mapCnt].Add(acc[i]);
                    mapCnt++;
                }
            }
            foreach (var kv in dic) ansList[accMap[findParent(kv.Value, accP)]].Add(kv.Key);
            for (int i = 0; i < ansList.Count; i++)
            {
                List<string> list = (List<string>)ansList[i];
                list.Sort(1, ansList[i].Count - 1, StringComparer.Ordinal);
                ansList[i] = list;
            }
            return ansList;
        }
    }
}
