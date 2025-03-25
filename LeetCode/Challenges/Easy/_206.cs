using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
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

    [TestClass]
    public class _206
    {
        [TestMethod]
        [DynamicData(nameof(Data1))]
        public void Main(ListNode input, ListNode expected)
        {
            var response = ReverseList(input);

            Assert.IsTrue(CompareListNode(expected, response));
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode next;
            ListNode prev = null;
            var current = head;

            while (current is not null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        private static IEnumerable<object[]> Data1 =>
        [
            [new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))))],
            [new ListNode(), new ListNode()],
        ];

        private bool CompareListNode(ListNode expected, ListNode response)
        {
            while (expected != null && response != null)
            {
                if (expected.val != response.val)
                {
                    return false;
                }

                expected = expected.next;
                response = response.next;
            }

            return expected == null && response == null;
        }
    }
}