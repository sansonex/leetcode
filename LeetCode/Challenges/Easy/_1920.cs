using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _1920
    {
        [TestMethod]
        [DataRow(new[] {0, 2, 1, 5, 3, 4}, new[] {0, 1, 2, 4, 5, 3})]
        [DataRow(new[] {5,0,1,2,3,4}, new[] {4,5,0,1,2,3})]
        public void Main(int[] nums, int[] expected)
        {
            var response = BuildArray(nums);
            for (int i = 0; i < response.Length; i++)
            {
                Assert.AreEqual(response[i], expected[i]);
            }
        }

        public int[] BuildArray(int[] nums)
        {
            var copy = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                copy[i] = nums[nums[i]];
            }

            return copy;
        }
    }
}