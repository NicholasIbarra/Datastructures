using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given two sparse vectors, compute their dot product.

    Implement class SparseVector:

    SparseVector(nums) Initializes the object with the vector nums
    dotProduct(vec) Compute the dot product between the instance of SparseVector and vec
    A sparse vector is a vector that has mostly zero values, you should store 
    the sparse vector efficiently and compute the dot product between two SparseVector.

    https://leetcode.com/problems/dot-product-of-two-sparse-vectors/
    */
    class Dot_Product_of_Two_Sparse_Vectors
    {
        public static void Test()
        {
            SparseVector v1 = new SparseVector(new int[] { 1, 0, 0, 2, 3 });
            SparseVector v2 = new SparseVector(new int[] { 0, 3, 0, 4, 0 });

            int ans = v1.DotProduct(v2);
            Console.WriteLine(ans);
        }

        public class SparseVector
        {
            Dictionary<int, int> mapping;

            public SparseVector(int[] nums)
            {
                mapping = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        mapping.Add(i, nums[i]);
                    }
                }
            }

            // Return the dotProduct of two sparse vectors
            public int DotProduct(SparseVector vec)
            {
                int result = 0;

                foreach (int i in this.mapping.Keys)
                {
                    if (vec.mapping.ContainsKey(i))
                    {
                        result += this.mapping[i] * vec.mapping[i];
                    }
                }

                return result;
            }
        }
    }
}
