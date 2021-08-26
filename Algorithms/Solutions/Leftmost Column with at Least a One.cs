using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
        (This problem is an interactive problem.)

        A row-sorted binary matrix means that all elements are 0 or 1 and each row of the matrix is sorted 
        in non-decreasing order.

        Given a row-sorted binary matrix binaryMatrix, return the index (0-indexed) 
        of the leftmost column with a 1 in it. If such an index does not exist, return -1.

        You can't access the Binary Matrix directly. You may only access the matrix using a BinaryMatrix interface:

        BinaryMatrix.get(row, col) returns the element of the matrix at index (row, col) (0-indexed).
        BinaryMatrix.dimensions() returns the dimensions of the matrix as a list of 2 elements 
        [rows, cols], which means the matrix is rows x cols.
        Submissions making more than 1000 calls to BinaryMatrix.get will
        be judged Wrong Answer. Also, any solutions that attempt to circumvent the judge will result in disqualification.

        For custom testing purposes, the input will be the entire binary matrix mat. 
        You will not have access to the binary matrix directly.

        https://leetcode.com/problems/leftmost-column-with-at-least-a-one/
     */
    class Leftmost_Column_with_at_Least_a_One
    {
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// Runtime: O(N Log M)
        /// Space: O(1)
        /// 
        /// </summary>
        /// <param name="binaryMatrix"></param>
        /// <returns></returns>
        public int BinarySearchSolution(BinaryMatrix binaryMatrix)
        {
            int rows = binaryMatrix.Dimensions()[0];
            int cols = binaryMatrix.Dimensions()[1];
            int samllestIndex = cols;

            for (int row = 0; row < rows; row++)
            {
                // Binary search the first row
                int lo = 0, hi = cols - 1;
                
                while (lo < hi)
                {
                    int mid = (hi - lo) / 2;
                    if (binaryMatrix.Get(row, mid) == 0)
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid;
                    }
                }

                if (binaryMatrix.Get(row, lo) == 1)
                {
                    samllestIndex = Math.Min(samllestIndex, lo);
                }
            }

            // if the smallest index still equasls cols, then there is no 1
            return samllestIndex == cols ? -1 : samllestIndex;
        }

        /// <summary>
        /// Runtime: O(N + M)
        /// Space: O(1)
        /// </summary>
        /// <param name="binaryMatrix"></param>
        /// <returns></returns>
        public int TopRightSolution(BinaryMatrix binaryMatrix)
        {
            int rows = binaryMatrix.Dimensions()[0];
            int cols = binaryMatrix.Dimensions()[1];

            // Set point to top-right corner of grid
            int currentRow = 0;
            int currentCol = cols - 1;

            while (currentRow < rows && currentCol >= 0)
            {
                if (binaryMatrix.Get(currentRow, currentCol) == 1)
                {
                    currentCol--;
                }
                else
                {
                    currentRow++;
                }
            }

            return currentCol == cols - 1 ? -1 : currentCol + 1;
        }
    }
}
