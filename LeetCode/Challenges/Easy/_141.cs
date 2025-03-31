using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _141
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
        [DynamicData(nameof(Data1), DynamicDataSourceType.Method)]
        public void Main(ListNode input, bool expected)
        {
            Assert.AreEqual(expected, HasCycle(input));
        }

        public bool HasCycle(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast?.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }

        private static IEnumerable<object[]> Data1()
        {
            // Case 1: Cycle exists
            var node1 = new ListNode(3);
            var node2 = new ListNode(2);
            var node3 = new ListNode(0);
            var node4 = new ListNode(-4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node2; // cycle here
            yield return [node1, true];

            // Case 2: No cycle
            var node5 = new ListNode(1);
            var node6 = new ListNode(2);
            node5.next = node6;
            yield return [node5, false];

            // Case 3: Single node, no cycle
            var node7 = new ListNode(1);
            yield return [node7, false];
        }
    }
}