using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _13
    {
        [TestMethod]
        [DataRow("III", 3)]
        [DataRow("LVIII", 58)]
        [DataRow("MCMXCIV", 1994)]
        public void Main(string s, int expected)
        {
            // Arrange & Act & Assert
            Assert.AreEqual(RomanToInt(s), expected);
        }

        public int RomanToInt(string s)
        {
            var sum = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                var current = GetVal(s[i]);
                if (i == s.Length - 1)
                {
                    sum += GetVal(s[i]);
                    continue;
                }

                if (GetVal(s[i]) < GetVal(s[i + 1]))
                {
                    sum -= current;
                    continue;
                }

                sum += current;
            }

            return sum;

            // Better to use a switch statement than a dictionary for performance reasons
            int GetVal(char c)
            {
                return c switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                    _ => 0
                };
            }
        }
    }
}