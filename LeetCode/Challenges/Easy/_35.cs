using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _35
    {
        [TestMethod]
        [DataRow(new[] {1, 3, 5, 6}, 5, 2)]
        [DataRow(new[] {1, 3, 5, 6}, 2, 1)]
        [DataRow(new[] {1, 3, 5, 6}, 7, 4)]
        public void Main(int[] nums, int target, int expected)
        {
            // Arrange & Act & Assert
            Assert.AreEqual(SearchInsert(nums, target), expected);
        }

        public int SearchInsert(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return left;
        }
    }
}