using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy;

[TestClass]
public class _169
{
    [TestMethod]
    [DataRow(new[] {2, 2, 1, 1, 1, 2, 2}, 2)]
    [DataRow(new[] {3, 2, 3}, 3)]
    public void Main(int[] nums, int expected)
    {
        var response = MajorityElement(nums);

        Assert.AreEqual(expected, response);
    }

    public int MajorityElement(int[] nums)
    {
        var counter = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (counter.ContainsKey(nums[i]))
            {
                counter[nums[i]] += 1;
                if (counter[nums[i]] > nums.Length / 2)
                {
                    return nums[i];
                }
            }
            else
            {
                counter[nums[i]] = 1;
            }
        }

        return counter.First(x => x.Value > nums.Length / 2).Key;
    }
}