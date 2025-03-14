using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Challenges.Medium
{
    [TestClass]
    public class _134
    {
        [TestMethod]
        [DataRow(new[] {1, 2, 3, 4, 5}, new[] {3, 4, 5, 1, 2}, 3)]
        [DataRow(new[] {2, 3, 4}, new[] {3, 4, 3}, -1)]
        [DataRow(new[] {4, 5, 3, 1, 4}, new[] {5, 4, 3, 4, 2}, -1)]
        [DataRow(new[] {2}, new[] {2}, 0)]
        public void Main(int[] gas, int[] cost, int expected)
        {
            // Arrange & Act & Assert
            Assert.AreEqual(expected, CanCompleteCircuit(gas, cost));
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Sum() < cost.Sum())
                return -1;

            var highGasWithLessCost = GetHighGasWithLessCost(gas, cost);

            foreach (var index in highGasWithLessCost)
            {
                var tank = 0;
                var p = index;

                while (true)
                {
                    tank += gas[p];
                    var temp = p;

                    if (p + 1 > gas.Length - 1)
                        p = 0;
                    else
                        p++;

                    tank -= cost[temp];

                    if (tank < 0)
                        break;

                    if (p == index)
                        return p;
                }
            }

            return -1;
        }

        public int[] GetHighGasWithLessCost(int[] gas, int[] cost)
        {
            var list = new List<int>();
            for (int i = 0; i < gas.Length; i++)
            {
                if (gas[i] >= cost[i])
                    list.Add(i);
            }

            return list.ToArray();
        }
    }
}