using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _876
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

        [TestMethod]
        [DynamicData(nameof(Data1))]
        public void Main(ListNode input, ListNode expected)
        {
            var response = MiddleNode(input);
            Assert.IsTrue(CompareListNode(expected, response));
        }

        public ListNode MiddleNode(ListNode head)
        {
            var ahead = head;
            while (ahead?.next != null)
            {
                head = head.next;
                ahead = ahead.next.next;
            }

            return head;
        }

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

        private static IEnumerable<object[]> Data1 =>
        [
            [new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), new ListNode(3, new ListNode(4, new ListNode(5)))]
        ];
    }
}