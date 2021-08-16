using System;
using System.Collections.Generic;
using System.Text;
using static Datastructure.Algorithms.Solutions.BinarySearchTreeIterator;

namespace Datastructure.Algorithms.Practice
{
    /*
    Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree(BST) :

    BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor.The pointer should be initialized to a non-existent number smaller than any element in the BST.
    boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
    int next() Moves the pointer to the right, then returns the number at the pointer.
    Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

    You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.

    https://leetcode.com/problems/binary-search-tree-iterator/
    */
    public class BinarySearchTreeIterator
    {
        class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public static void Test()
        {
            TreeNode root = new TreeNode
            {
                val = 6,
                left = new TreeNode()
                {
                    val = 4,
                    left = new TreeNode(2),
                    right = new TreeNode(5)
                },
                right = new TreeNode()
                {
                    val = 10,
                    left = new TreeNode(8),
                    right = new TreeNode(12)
                }
            };

            BSTIterator obj = new BSTIterator(root);

            while (obj.HasNext())
            {
                Console.WriteLine(obj.Next());
            }
        }

        class BSTIterator
        {
            public BSTIterator(TreeNode root)
            {
            }

            public int Next()
            {
                throw new NotImplementedException();
            }

            public bool HasNext()
            {
                throw new NotImplementedException();
            }
        }

        /*
         class BSTIterator
        {
            public BSTIterator(TreeNode root)
            {
            }

            public int Next()
            {
        throw new NotImplementedException();
            }

            public bool HasNext()
            {
        throw new NotImplementedException();
            }
        }
        */
    }
}
