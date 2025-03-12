using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _151
    {
        [TestMethod]
        [DataRow("the sky", "sky the")]
        [DataRow("  hello world  ", "world hello")]
        public void Main(string str, string expected)
        {
            // Arrange & Act & Assert
            Assert.AreEqual(expected, ReverseWords(str));
        }

        public string ReverseWords(string s)
        {
            var left = 0;
            var right = 0;
            var words = new List<string>();

            while (right < s.Length)
            {
                if (s[right] == ' ' || right == s.Length - 1)
                {
                    var word = s.Substring(left, right - left + 1).Trim();
                    if (word != "")
                    {
                        words.Add(word);
                        left = right;
                    }
                }

                right++;
            }

            words.Reverse();
            return string.Join(" ", words);
        }
    }
}