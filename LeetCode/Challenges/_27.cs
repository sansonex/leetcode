using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges;

[TestClass]
public class _27
{
    [TestMethod]
    [DataRow(new[] {3, 2, 2, 3}, 3, 2)]
    public void Main(int[] nums, int val, int expected)
    {
        // Act
        var result = RemoveElement(nums, val);

        // Assert
        Assert.AreEqual(expected, result);
    }

    public int RemoveElement(int[] nums, int val)
    {
        return 1;
    }
}