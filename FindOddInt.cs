using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
	internal class FindOddInt
	{
		public static int find_it(int[] seq)
		{
			Dictionary<int,int> map = new Dictionary<int,int>();
			for (int i = 0; i < seq.Count(); i++)
			{
				if (map.ContainsKey(seq[i]))
				{
					map[seq[i]]++;
				}
				else
				{
					map[seq[i]] = 1;
				}
			}

			foreach (KeyValuePair<int, int> item in map)
			{
				if(item.Value % 2 != 0)
				{
					return item.Key;
				}
			}
			return -1;
		}

		public static int find_it2(int[] seq)
		{
			return seq.GroupBy(x => x).Where(s => s.Count() % 2 == 1).First().ElementAt(0);
		}

		public static int find_it3(int[] seq)
		{
			return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
		}

		public static int find_it4(int[] seq)
		{
			return seq.First(x => seq.Count(s => s == x) % 2 == 1);
		}

		[TestFixture]
		public class FindOddIntTest
		{
			[Test]
			public void Tests()
			{
				Assert.AreEqual(5, FindOddInt.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
				Assert.AreEqual(4, FindOddInt.find_it(new[] { 1, 2, 2, 3, 3, 3, 4, 3, 3, 3, 2, 2, 1 }));
				Assert.AreEqual(0, FindOddInt.find_it(new[] { 0, 1, 0, 1, 0 }));

				Assert.AreEqual(4, FindOddInt.find_it2(new[] { 1, 2, 2, 3, 3, 3, 4, 3, 3, 3, 2, 2, 1 }));
				Assert.AreEqual(0, FindOddInt.find_it2(new[] { 0, 1, 0, 1, 0 }));

				Assert.AreEqual(4, FindOddInt.find_it3(new[] { 1, 2, 2, 3, 3, 3, 4, 3, 3, 3, 2, 2, 1 }));
				Assert.AreEqual(0, FindOddInt.find_it3(new[] { 0, 1, 0, 1, 0 }));

				Assert.AreEqual(4, FindOddInt.find_it4(new[] { 1, 2, 2, 3, 3, 3, 4, 3, 3, 3, 2, 2, 1 }));
				Assert.AreEqual(0, FindOddInt.find_it4(new[] { 0, 1, 0, 1, 0 }));
			}
		}
	}
}
