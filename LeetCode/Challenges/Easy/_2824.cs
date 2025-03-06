using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _2824
    {
        [TestMethod]
        [DataRow(new[] {-1, 1, 2, 3, 1}, 2, 3)]
        [DataRow(new[] {-6, 2, 5, -2, -7, -1, 3}, -2, 10)]
        public void Main(int[] nums, int target, int expected)
        {
            Assert.AreEqual(expected, CountPairs(nums, target));
        }

        public int CountPairs(IList<int> nums, int target)
        {
            var s = 0;
            for (int x = 0; x < nums.Count; x++)
            {
                for (int i = x + 1; i < nums.Count; i++)
                {
                    if (nums[x] + nums[i] < target)
                        s++;
                }
            }

            return s;
        }
    }
}