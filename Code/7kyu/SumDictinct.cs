using NUnit.Framework;
using System.Linq;

namespace CodeWars
{
	internal class SumDictinct
	{
		public static int SumNoDuplicates(int[] arr)
		{
			int sum = 0;
			arr.GroupBy(x => x)
				.Select(x => new { Value = x.Key, Count = x.Count() })
				.Where(x => x.Count == 1).ToList()
				.ForEach(x => sum += x.Value);
			return sum;
		}

		public static int SumNoDuplicates2(int[] arr)
		{
			return arr.GroupBy(x => x).Where(s => s.Count() == 1).Sum(d => d.Key);
		}

		public static int SumNoDuplicates3(int[] arr)
		{
			return arr.Sum(x => arr.Count(i => i == x) == 1 ? x : 0);
		}
	}

	[TestFixture]
	public class SSumDictinctTest
	{
		[Test]
		public void MyTest()
		{
			Assert.AreEqual(5, SumDictinct.SumNoDuplicates(new int[] { 1, 1, 2, 3 }));
			Assert.AreEqual(3, SumDictinct.SumNoDuplicates(new int[] { 1, 1, 2, 2, 3 }));
			Assert.AreEqual(3, SumDictinct.SumNoDuplicates2(new int[] { 1, 1, 2, 2, 3 }));
			Assert.AreEqual(3, SumDictinct.SumNoDuplicates3(new int[] { 1, 1, 1, 2, 2, 3 }));
		}
	}
}
