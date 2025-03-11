using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _274
    {
        [TestMethod]
        [DataRow(new[] {3, 0, 6, 1, 5}, 3)]
        [DataRow(new[] {1, 3, 1}, 1)]
        [DataRow(new[] {100}, 1)]
        [DataRow(new[] {0, 0, 2}, 1)]
        public void Main(int[] nums, int expected)
        {
            // Arrange & Act & Assert
            Assert.AreEqual(expected, HIndex(nums));
        }

        public int HIndex(int[] citations)
        {
            var h = 0;
            Array.Sort(citations);
            Array.Reverse(citations);

            for (var i = 0; i < citations.Length; i++)
            {
                if (citations[i] >= i + 1)
                {
                    h = i + 1;
                }
                else
                {
                    break;
                }
            }

            return h;
        }
    }
}