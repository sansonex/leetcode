using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _15
    {
        [TestMethod]
        [DynamicData(nameof(Data1))]
        public void Main(int[] nums, IList<IList<int>> expected)
        {
            var response = ThreeSum(nums);

            CollectionAssert.AreEquivalent(
                expected.SelectMany(x => x).ToList(),
                response.SelectMany(x => x).ToList());
        }

        public static IEnumerable<object[]> Data1 =>
        [
            [new[] {-1, 0, 1, 2, -1, -4}, new List<IList<int>> {new List<int> {-1, -1, 2}, new List<int> {-1, 0, 1}}],
            [new[] {0, 0, 0}, new List<IList<int>> {new List<int> {0, 0, 0}}],
            [new[] {-1, 0, 1, 2, -1, -4}, new List<IList<int>> {new List<int> {-1, -1, 2}, new List<int> {-1, 0, 1}}]
        ];

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var response = new List<IList<int>>();

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var num1 = nums[i];
                var left = i + 1;
                var right = nums.Length - 1;

                while (left < right)
                {
                    var sum = num1 + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        response.Add(new List<int> {num1, nums[left], nums[right]});

                        while (left < right && nums[left] == nums[left + 1])
                            left++;

                        while (left < right && nums[right] == nums[right - 1])
                            right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return response;
        }
    }
}