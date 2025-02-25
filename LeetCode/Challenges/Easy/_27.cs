using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Easy;

[TestClass]
public class _27
{
    [TestMethod]
    [DataRow(new[] {3, 2, 2, 3}, 3, 2)]
    [DataRow(new[] {0, 1, 2, 2, 3, 0, 4, 2}, 2, 5)]
    public void Main(int[] nums, int val, int expected)
    {
        // Act
        var result = RemoveElement(nums, val);

        // Assert
        Assert.AreEqual(expected, result);
    }

    public int RemoveElement(int[] nums, int val)
    {
        var i = 0;
        for (var index = 0; index < nums.Length; index++)
        {
            if (nums[index] != val)
            {
                var temp = nums[i];
                nums[i] = nums[index];
                nums[index] = temp;
                i++;
            }
        }

        return i;
    }
}