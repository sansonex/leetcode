using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _209
    {
        [TestMethod]
        [DataRow(7, new[] {2, 3, 1, 1, 4,3}, 2)]
        [DataRow(4, new[] {1, 4, 4}, 1)]
        [DataRow(11, new[] {1,1,1,1,1,1,1,1}, 0)]
        [DataRow(6, new[] {10,2,3}, 1)]
        [DataRow(7, new[] {1,1,1,1,7}, 1)]
        public void Main(int target, int[] nums, int expected)
        {
            Assert.AreEqual(expected, MinSubArrayLen(target, nums));
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            var left = 0;
            var right = 0;
            var sum = nums[right];
            if (sum >= target)
                return 1;

            var sb = int.MaxValue;
            while (right < nums.Length -1)
            {
                right++;
                sum += nums[right];

                while (sum >= target && left <= nums.Length)
                {
                    sb = Math.Min(sb,right - left + 1);
                    sum -= nums[left];
                    left++;
                }
            }

            return sb == int.MaxValue ? 0 : sb;
        }
    }
}