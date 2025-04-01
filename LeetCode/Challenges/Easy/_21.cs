using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _21
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
        public void Main(ListNode list1, ListNode list2, ListNode expected)
        {
            var response = MergeTwoLists(list1, list2);
            
            Assert.IsTrue(CompareListNode(expected, response));
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var values = ExtractAllValues(list1).Concat(ExtractAllValues(list2)).Order();

            ListNode head = null;
            var tail = head;

            foreach (var value in values)
            {
                if (head is null)
                {
                    head = new ListNode(value);
                    tail = head;
                }
                else
                {
                    var node = new ListNode(value);
                    tail.next = node;
                    tail = node;
                }
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

        private List<int> ExtractAllValues(ListNode listNode)
        {
            var response = new List<int>();
            var current = listNode;
            while (current is not null)
            {
                response.Add(current.val);
                current = current.next;
            }

            return response;
        }

        private static IEnumerable<object[]> Data1 =>
        [
            [new ListNode(1, new ListNode(2, new ListNode(4))), new ListNode(1, new ListNode(3, new ListNode(4))), new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))))],
            [new ListNode(), new ListNode(), new ListNode(0, new ListNode(0))],
            [null, null, null],
        ];
    }
}