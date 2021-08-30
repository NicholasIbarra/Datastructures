using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    // https://leetcode.com/problems/word-break-ii/
    class Word_Break_II
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> hash = new HashSet<string>(wordDict);
            return Helper(s, hash, 0);
            //return DFS(s, wordDict, new Dictionary<string, LinkedList<string>>());
        }

        private List<string> DFS(string s, IList<string> wordDict, Dictionary<string, LinkedList<string>> map)
        {
            if (map.ContainsKey(s))
            {
                return map[s].ToList();
            }

            var res = new LinkedList<String>();

            if (s.Length == 0)
            {
                res.AddLast("");
                return res.ToList();
            }

            foreach(string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    List<string> sublist = DFS(s.Substring(word.Length), wordDict, map);

                    foreach(string sub in sublist)
                    {
                        res.AddLast(word + (string.IsNullOrEmpty(sub) ? "" : " ") + sub);
                    }
                }
            }

            map.Add(s, res);
            return res.ToList();
        }

        private List<string> Helper(string s, HashSet<string> dict, int i)
        {
            List<string> cur = new List<string>();

            for (int j = i; j < s.Length; j++)
            {
                var sub = s.Substring(i, j - i + 1);
                if (dict.Contains(sub))
                {
                    if (j == s.Length - 1)
                        cur.Add(sub);
                    else
                        foreach (var str in Helper(s, dict, j + 1))
                            cur.Add(sub + " " + str);
                }
            }
            return cur;
        }
    }
}
