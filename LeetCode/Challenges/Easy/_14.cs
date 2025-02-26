using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy
{
    [TestClass]
    public class _14
    {
        [TestMethod]
        [DataRow(new[] {"flower", "flow", "flight"}, "fl")]
        [DataRow(new[] {"dog", "racecar", "car"}, "")]
        public void Main(string[] strings, string expected)
        {
            Assert.AreEqual(LongestCommonPrefix(strings), expected);
        }

        public string LongestCommonPrefix(string[] strs)
        {
            var output = string.Empty;
            if (strs.Length == 0)
                return output;

            var dic = new Dictionary<string, int>();
            var parameter = strs[0];

            for (int i = 0; i < parameter.Length; i++)
            {
                var str = parameter.Substring(0, i + 1);
                var count = strs.Count(x => x.StartsWith(str));
                dic.Add(str, count);

                if (count < strs.Length || i == parameter.Length - 1)
                {
                    var pairs = dic
                        .Where(x => x.Value == strs.Length);

                    if (!pairs.Any())
                    {
                        return output;
                    }

                    return pairs.MaxBy(x => x.Key.Length).Key;
                }
            }

            return output;
        }
    }
}