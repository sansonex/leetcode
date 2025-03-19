using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _3
    {
        [TestMethod]
        [DataRow("abcabcbb", 3)]
        [DataRow("bbbbb", 1)]
        [DataRow("pwwkew", 3)]
        [DataRow("dvdf", 3)]
        public void Main(string input, int expected)
        {
            Assert.AreEqual(expected, LengthOfLongestSubstring(input));
        }

        public int LengthOfLongestSubstring(string s)
        {
            var dic = new HashSet<char>();
            var left = 0;
            var right = 0;
            var max = 0;

            while (right < s.Length)
            {
                if (dic.Add(s[right]))
                {
                    max = Math.Max(max, right - left + 1);
                }
                else
                {
                    while (!dic.Add(s[right]))
                    {
                        dic.Remove(s[left]);
                        left++;
                    }
                }

                right++;
            }

            return max;
        }
    }
}