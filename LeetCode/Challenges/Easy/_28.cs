using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _28 
    {
        [TestMethod]
        [DataRow("sadbutsad", "sad", 0)]
        [DataRow("leetcode", "leeto", -1)]
        public void Main(string haystack, string needle, int expected)
        {
            Assert.AreEqual(StrStr(haystack, needle), expected);
        }

        public int StrStr(string haystack, string needle)
        {
            var left = 0;
            var right = 0;
            var p = 0;

            while (right < haystack.Length)
            {
                if (haystack[right] == needle[p])
                {
                    right++;
                    p++;
                    if (p == needle.Length)
                    {
                        return left;
                    }
                }
                else
                {
                    left++;
                    right = left;
                    p = 0;
                }
            }

            return -1;
        }
    }
}