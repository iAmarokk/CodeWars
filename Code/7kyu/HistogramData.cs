using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars._7kyu
{
	internal class HistogramData
	{
		public static uint[] Histogram(uint[] data, uint binWidth)
		{
			if(data.Count() < 1)
			{
				return new uint[] {};
			}

			SortedDictionary<uint, int> numberCount = new SortedDictionary<uint, int>();

			for (int i = 0; i < data.Length; i++)
			{
				uint n = data[i];
				if (numberCount.ContainsKey(n))
				{
					numberCount[n]++;
				}
				else
				{
					numberCount[n] = 1;
				}
			}

			for (uint i = 0; i < numberCount.Last().Key; i++)
			{
				if (!numberCount.ContainsKey(i))
				{
					numberCount.Add(i, 0);
				}
			}

			var h = numberCount.GroupBy(x => x.Key / binWidth).Select(k => (uint)k.Sum(x=> x.Value)).ToArray();


			return h;
		}

		public static uint[] Histogram2(uint[] data, uint binWidth)
		{
			if (data.Length == 0) return new uint[0];
			uint[] hist = new uint[data.Max() / binWidth + 1];
			foreach (uint num in data) hist[num / binWidth]++;
			return hist;
		}

		public static uint[] Histogram3(uint[] data, uint binWidth)
		{
			return data.Length == 0
				? data
				: new int[data.Max() / binWidth + 1].Select((_, i) => (uint)data.Count(u => u / binWidth == i)).ToArray();
		}
	}

	[TestFixture]
	public class HistogramTest
	{
		[Test]
		public void SimpleTest()
		{
			uint[] data = new uint[] { 1, 1, 0, 1, 3, 2, 6 };
			Assert.AreEqual(new uint[] { 1, 3, 1, 1, 0, 0, 1 }, HistogramData.Histogram(data, 1));
			Assert.AreEqual(new uint[] { 4, 2, 0, 1 }, HistogramData.Histogram(data, 2));
			Assert.AreEqual(new uint[] { 4, 2, 0, 1 }, HistogramData.Histogram2(data, 2));
			Assert.AreEqual(new uint[] { 4, 2, 0, 1 }, HistogramData.Histogram3(data, 2));
		}
	}
}
