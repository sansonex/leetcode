using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _392
    {
        [TestMethod]
        [DataRow("abc", "ahbgdc", true)]
        [DataRow("axc", "ahbgdc", false)]
        [DataRow("b", "c", false)]
        [DataRow("acb", "ahbgdc", false)]
        public void Main(string s, string t, bool expected)
        {
            var response = IsSubsequence(s, t);

            Assert.AreEqual(expected, response);
        }

        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0)
                return true;

            var c = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == s[c])
                    c++;

                if (c == s.Length && c > 0)
                    return true;
            }

            return false;
        }
    }
}