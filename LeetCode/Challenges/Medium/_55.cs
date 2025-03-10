using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _55
    {
        [TestMethod]
        [DataRow(new[] {2, 3, 1, 1, 4}, true)]
        [DataRow(new[] {3, 2, 1, 0, 4}, false)]
        [DataRow(new[] {2, 0, 0}, true)]
        [DataRow(new[] {3, 0, 8, 2, 0, 0, 1}, true)]
        public void Main(int[] nums, bool expected)
        {
            // Arrange & Act & Assert
            Assert.AreEqual(CanJump(nums), expected);
        }

        public bool CanJump(int[] nums)
        {
            if (nums.Length <= 1)
                return true;

            var x = 0;
            var t = nums.Length - 1;

            while (t > 0 && x < t)
            {
                if (nums[x] + x >= t)
                {
                    t = x;
                    x = 0;
                }
                else
                {
                    x++;
                }
            }

            return t == 0;
        }
    }
}