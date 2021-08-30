using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given a file and assume that you can only read the file using 
    a given method read4, implement a method read to read n characters.
    Your method read may be called multiple times.

    Method read4:

    The API read4 reads four consecutive characters from file, then writes those characters into the buffer array buf4.
    The return value is the number of actual characters read.
    Note that read4() has its own file pointer, much like FILE *fp in 
    */
    class ReadNCharactersGivenRead4II
    {
        private int tmpPtr = 0;
        private int tmpCnt = 0;
        private char[] tmp = new char[4];

        public int Read(char[] buf, int n)
        {
            int total = 0;

            while (total < n)
            {
                if (tmpPtr == 0)
                {
                    tmpCnt = Read4(tmp);
                }

                if (tmpCnt == 0) break;

                while (total < n && tmpPtr < tmpCnt)
                {
                    buf[total++] = tmp[tmpPtr++];
                }

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
