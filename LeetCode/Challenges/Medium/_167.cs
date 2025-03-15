using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _167
    {
        [TestMethod]
        [DataRow(new[] {2, 7, 11, 15}, 9, new[] {1, 2})]
        [DataRow(new[] {2, 3, 4}, 6, new[] {1, 3})]
        [DataRow(new[] {0, 0, 3, 4}, 0, new[] {1, 2})]
        [DataRow(new[] {5, 25, 75}, 100, new[] {2, 3})]
        [DataRow(new[] {-5, -3, 0, 2, 4, 6, 8}, 5, new[] {2, 7})]
        public void Main(int[] nums, int target, int[] expected)
        {
            var response = TwoSum(nums, target);
            CollectionAssert.AreEqual(expected, response);
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                if (numbers[left] + numbers[right] > target)
                {
                    right--;
                    continue;
                }

                if (numbers[left] + numbers[right] < target)
                {
                    left++;
                    continue;
                }

                break;
            }

            return [left + 1, right + 1];
        }
    }
}