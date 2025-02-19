using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges;

[TestClass]
public class _26
{
    [TestMethod]
    [DataRow(new[] {1, 1, 2}, 2, new[] {1, 2})]
    [DataRow(new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4}, 5, new[] {0, 1, 2, 3, 4})]
    public void Main(int[] nums, int k, int[] expectedArray)
    {
        // Arrange
        var response = RemoveDuplicates(nums);

        Assert.AreEqual(response, k);
        for (int i = 0; i < expectedArray.Length; i++)
        {
            Assert.AreEqual(nums[i], expectedArray[i]);
        }
    }

    public int RemoveDuplicates(int[] nums)
    {
        var index = 0;
        var hash = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (hash.Contains(nums[i]))
            {
                continue;
            }

            nums[index] = nums[i];
            index++;
            hash.Add(nums[i]);
        }

        return hash.Count;
    }
}