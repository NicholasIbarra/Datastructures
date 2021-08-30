using Datastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    //https://leetcode.com/problems/merge-two-sorted-lists/
    // Runtime: O(N + M)
    // Space: O(1)
    class Merge_Two_Sorted_Lists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode preHead = new ListNode(-1);
            ListNode prev = preHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }

                prev = prev.next;
            }

            prev.next = l1 == null ? l2 : l1;
            return preHead.next;
        }
    }
}
