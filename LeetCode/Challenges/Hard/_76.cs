using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Hard
{
    [TestClass]
    public class _76
    {
        [TestMethod]
        [DataRow("ADOBECODEBANC", "ABC", "BANC")]
        public void Main(string s, string t, string expected)
        {
            Assert.AreEqual(expected, MinWindow(s, t));
        }

        public string MinWindow(string s, string t)
        {
            string output = null;
            var reference = new Dictionary<char, int>();
            var items = new Dictionary<char, int>();
            var left = 0;
            var right = 0;

            foreach (var item in t)
            {
                if (!reference.TryAdd(item, 1))
                    reference[item] += 1;
            }

            while (right < s.Length)
            {
                if (!items.TryAdd(s[right], 1))
                    items[s[right]] += 1;

                while (HasAll(reference, items))
                {
                    if (output is null || right - left + 1 < output.Length)
                    {
                        output = s.Substring(left, right - left + 1);
                    }

                    items[s[left]] = Math.Max(items[s[left]] - 1, 0);
                    left++;
                }

                right++;
            }

            return output ?? string.Empty;
        }

        private bool HasAll(Dictionary<char, int> left, Dictionary<char, int> right)
        {
            foreach (var (key, expected) in left)
            {
                if (!right.TryGetValue(key, out var response)) return false;

                if (response < expected)
                    return false;
            }

            return true;
        }
    }
}