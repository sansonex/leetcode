using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _189
    {
        [TestMethod]
        [DataRow(new[] {1, 2, 3, 4, 5, 6, 7}, 3, new[] {5, 6, 7, 1, 2, 3, 4})]
        public void Main(int[] nums, int k, int[] expected)
        {
            Rotate(nums, k);
            CollectionAssert.AreEqual(nums,expected);
        }

        public void Rotate(int[] nums, int k)
        {
            var copy = new int[nums.Length];
            Array.Copy(nums, copy, nums.Length);
            
            for (var x = 0; x < copy.Length; x++)
            {
                var index = 0;
                if (x + (k % copy.Length) >= nums.Length)
                {
                    index = Math.Abs(0 + copy.Length - (x + (k % copy.Length)));
                }
                else
                {
                    index = k % copy.Length + x;
                }

                nums[index] = copy[x];
            }
        }
    }
}