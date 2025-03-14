using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _45
    {
        [TestMethod]
        [DataRow(new[] {2, 3, 1, 1, 4}, 2)]
        [DataRow(new[] {2, 3, 0, 1, 4}, 2)]
        public void Main(int[] nums, int expected)
        {
            Assert.AreEqual(expected, Jump(nums));
        }

        public int Jump(int[] nums)
        {
            if (nums.Length <= 1)
                return 0;
            
            var s = 0;
            var t = nums.Length - 1;

            var p = 0;

            while (p <= t)
            {
                if (p + nums[p] >= t)
                {
                    s++;
                    t = p;
                    p = 0;
                }
                else
                {
                    p++;
                }

                if (t == 0)
                    break;
            }

            return s;
        }
    }
}