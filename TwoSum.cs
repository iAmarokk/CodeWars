using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
	static class TwoSumKata
	{
		public static int[] TwoSum(int[] numbers, int target)
		{
			bool result = true;
			int[] indexes = new int[2];
			int summa = 0;
			int k = 0;
			indexes[0] = k;
			summa = numbers[k];
			k++;

			do
			{
				for (int i = k; i < numbers.Length; i++)
				{
					if (summa + numbers[i] == target)
					{
						result = false;
						indexes[1] = i;
						break;
					}
				}
				if (result)
				{
					indexes[0] = k;
					summa = numbers[k];
					k++;
				}
			}
			while (result);
			return indexes.ToArray();
		}

		public static int[] TwoSum2(int[] numbers, int target)
		{
			for (int i = 0; i < numbers.Length - 1; i++)
			{
				for (int u = i + 1; u < numbers.Length; u++)
				{
					if (numbers[i] + numbers[u] == target)
						return new int[] { i, u };
				}
			}
			return null;
		}
	}

	[TestFixture]
	public class TwoSumKataTests
	{
		[Test]
		public void BasicTests()
		{
			Assert.AreEqual(new[] { 0, 2 }, TwoSumKata.TwoSum(new[] { 1, 2, 3 }, 4).OrderBy(a => a).ToArray());
			Assert.AreEqual(new[] { 1, 2 }, TwoSumKata.TwoSum(new[] { 1234, 5678, 9012 }, 14690).OrderBy(a => a).ToArray());
			Assert.AreEqual(new[] { 0, 1 }, TwoSumKata.TwoSum(new[] { 2, 2, 3 }, 4).OrderBy(a => a).ToArray());
		}
	}
}
