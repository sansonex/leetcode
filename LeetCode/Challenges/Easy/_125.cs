using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _125
    {
        [TestMethod]
        [DataRow("A man, a plan, a canal: Panama", true)]
        [DataRow("race a car", false)]
        public void Main(string nums, bool expected)
        {
            Assert.AreEqual(expected, IsPalindrome(nums));
        }

        public bool IsPalindrome(string s)
        {
            var l = 0;
            var r = s.Length - 1;

            while (l < r)
            {
                if (!char.IsLetterOrDigit(s[l]))
                {
                    l++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[r]))
                {
                    r--;
                    continue;
                }

                if (char.ToLowerInvariant(s[l]) == char.ToLowerInvariant(s[r]))
                {
                    l++;
                    r--;
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}