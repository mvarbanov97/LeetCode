using System;

namespace _02.AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ListNode testL1 = new ListNode(2);
            testL1.next = new ListNode(4, new ListNode(3));
            var testL2 = new ListNode(5);
            testL2.next = new ListNode(6, new ListNode(4));

            var result = AddTwoNumbers(testL1, testL2);
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode head = dummyHead;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int sum = carry;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum = sum % 10;
                }
                else
                {
                    carry = 0;
                }

                dummyHead.next = new ListNode(sum);
                dummyHead = dummyHead.next;
            }

            if (carry > 0)
            {
                dummyHead.next = new ListNode(carry);
            }

            return head = head.next;
        }
    }
}
