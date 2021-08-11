namespace Datastructure.Algorithms.Solutions
{
    class AddTwoNumers
    {
        class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        
        public static void Test()
        {
            ListNode n1 = new ListNode(2);
            ListNode n2 = new ListNode(4);
            ListNode n3 = new ListNode(3);

            n2.next = n3;
            n1.next = n2;

            ListNode m1 = new ListNode(5);
            ListNode m2 = new ListNode(6);
            ListNode m3 = new ListNode(4);

            m2.next = m3;
            m1.next = m2;

            AddTwoNumers solution = new AddTwoNumers();
            ListNode result = solution.AddTwoNumbers(n1, m1);
        }

        ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);

            ListNode curr = dummyHead;
            int carryOver = 0;

            while(l1 != null || l2 != null)
            {
                int x = l1 == null ? 0 : l1.val;
                int y = l2 == null ? 0 : l2.val;

                int sum = x + y + carryOver;
                carryOver = sum / 10;

                curr.next = new ListNode(sum % 10);
                curr = curr.next;

                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }

            if (carryOver > 0)
            {
                curr.next = new ListNode(carryOver);
            }

            return dummyHead.next;
        }
    }
}
