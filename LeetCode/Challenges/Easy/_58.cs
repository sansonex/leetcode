using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _58
    {
        [TestMethod]
        [DataRow("Hello World", 5)]
        [DataRow("   fly me   to   the moon  ", 4)]
        [DataRow("luffy is still joyboy", 6)]
        public void Main(string s, int expected)
        {
            // Act
            var result = LengthOfLastWord(s);

            // Assert
            Assert.AreEqual(expected, result);
        }

        public int LengthOfLastWord(string s)
        {
            var count = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (char.IsLetter(s[i]))
                {
                    count++;
                    continue;
                }

                if (count > 0)
                {
                    return count;
                }
            }

            return count;
        }
    }
}