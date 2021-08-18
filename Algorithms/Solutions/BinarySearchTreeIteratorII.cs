using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):

    BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor. The pointer should be initialized to a non-existent number smaller than any element in the BST.
    boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
    int next() Moves the pointer to the right, then returns the number at the pointer.
    boolean hasPrev() Returns true if there exists a number in the traversal to the left of the pointer, otherwise returns false.
    int prev() Moves the pointer to the left, then returns the number at the pointer.
    Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

    You may assume that next() and prev() calls will always be valid. That is, there will be at least a next/previous number in the in-order traversal when next()/prev() is called.

    https://leetcode.com/problems/binary-search-tree-iterator-ii/
    */
    class BinarySearchTreeIteratorII
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
                val = 7,
                left = new TreeNode(3),
                right = new TreeNode()
                {
                    val = 15,
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                }
            };

            BSTIterator obj = new BSTIterator(root);

            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Prev());
            Console.WriteLine(obj.Prev());
        }

        class BSTIterator
        {
            List<int> arr = new List<int>();
            int pointer;
            int n; 

            public BSTIterator(TreeNode root)
            {
                inorder(root, arr);

                n = arr.Count;
                pointer = -1;
            }

            private void inorder(TreeNode root, List<int> arr)
            {
                if (root == null) return;

                inorder(root.left, arr);
                arr.Add(root.val);
                inorder(root.right, arr);
            }

            public int Next()
            {
                return arr[++this.pointer];
            }

            public bool HasNext()
            {
                return pointer < n - 1;
            }

            public bool HasPrev()
            {
                return pointer > 0;
            }

            public int Prev()
            {
                return arr[--this.pointer];
            }
        }
    }
}
