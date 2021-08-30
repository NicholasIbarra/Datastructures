using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    // https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/submissions/
    class ReadNCharactersGivenRead4II
    {
        private int tmpPtr = 0;
        private int tmpCnt = 0;
        private char[] tmp = new char[4];

        public int Read(char[] buf, int n)
        {
            //throw new NotImplementedException();
            int total = 0;

            while (total < n)
            {
                if (tmpPtr == 0)
                {
                    tmpCnt = Read4(tmp);
                }

                if (tmpCnt == 0) break;
            
                // Laod buffer and return count
                while (total < n && tmpPtr < tmpCnt)
                {
                    buf[total++] = tmp[tmpPtr++];
                }

                // Reset
                if (tmpPtr >= tmpCnt) tmpPtr = 0;
                if (tmpCnt < 4) break;
            }

            return total;
        }

        public int Read4(char[] buf4)
        {
            return buf4.Length;
        }
    }
}
