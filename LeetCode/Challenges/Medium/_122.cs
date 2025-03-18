using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _122
    {
        [TestMethod]
        [DataRow(new[] {7, 1, 5, 3, 6, 4}, 7)]
        [DataRow(new[] {1,2,3,4,5}, 4)]
        [DataRow(new[] {7,6,4,3,1}, 0)]
        public void Main(int[] prices, int expected)
        {
            // Arrange &&
            Assert.AreEqual(expected, MaxProfit(prices));
        }

        public int MaxProfit(int[] prices)
        {
            var left = 0;
            var right = 0;
            var profit = 0;

            while (right < prices.Length)
            {
                if (prices[right] <= prices[left])
                {
                    left = right;
                    right++;
                    continue;
                }

                if (prices[right] > prices[left])
                {
                    profit += prices[right] - prices[left];
                    left = right;
                    right++;
                }
            }

            return profit;
        }
    }
}