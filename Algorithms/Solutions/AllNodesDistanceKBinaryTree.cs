using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Given the root of a binary tree, the value of a target node target, and an integer k, 
    return an array of the values of all nodes that have a distance k from the target node.

    You can return the answer in any order..

    https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
    
    */
    class AllNodesDistanceKBinaryTree
    {
        public static void Test()
        {
            // [3,5,1,6,2,0,8,null,null,7,4]
            // 5

            TreeNode root = new TreeNode
            {
                val = 3,
                left = new TreeNode
                {
                    val = 5,
                    left = new TreeNode(6),
                    right = new TreeNode
                    {
                        val = 2,
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode
                {
                    val = 1,
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };


            AllNodesDistanceKBinaryTree solution = new AllNodesDistanceKBinaryTree();
            Console.WriteLine(string.Join(",", solution.DistanceK(root, root.left, 2)));
        }

        List<int> ans;
        TreeNode target;
        int K;

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            ans = new List<int>();
            this.target = target;
            this.K = k;

            dfs(root);

            return ans;
        }

        public int dfs(TreeNode node)
        {
            if (node == null)
            {
                return -1;
            }
            else if(node == target)
            {
                subtreeAdd(node, 0);
                return 1;
            }
            else
            {
                int L = dfs(node.left);
                int R = dfs(node.right);

                if (L != -1)
                {
                    if (L == K) ans.Add(node.val);
                    subtreeAdd(node.right, L + 1);

                    return L + 1;
                }
                else if (R != -1)
                {
                    if (R == K) ans.Add(node.val);
                    subtreeAdd(node.left, R + 1);

                    return R + 1;
                }
                else
                {
                    return -1;
                }
            }    
        }

        public void subtreeAdd(TreeNode node, int dist)
        {
            if (node == null) return;
            if (dist == K)
            {
                ans.Add(node.val);
            }
            else
            {
                subtreeAdd(node.left, dist + 1);
                subtreeAdd(node.right, dist + 1);
            }
        }
    }
}
