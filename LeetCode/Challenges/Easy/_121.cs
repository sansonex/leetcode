using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy;

[TestClass]
public class _121
{
    [TestMethod]
    [DataRow(new[] {7, 1, 5, 3, 6, 4}, 5)]
    [DataRow(new[] {2, 1, 4}, 3)]
    public void Main(int[] nums, int k)
    {
        Assert.AreEqual(k, MaxProfit(nums));
    }

    public int MaxProfit(int[] prices)
    {
        var left = 0;
        var right = 0;
        var maxProfit = 0;

        while (right <= prices.Length - 2)
        {
            right++;
            var profit = prices[right] - prices[left];
            if (profit > maxProfit)
            {
                maxProfit = profit;
            }

            if (prices[right] < prices[left])
            {
                left = right;
            }
        }

        return maxProfit;
    }
}