using NUnit.Framework;
using System.Linq;

namespace CodeWars
{
	public class AverageSolution
	{
		public static double FindAverage(double[] array)
		{
			if(array== null || array.Length == 0) return 0;
			return array.Sum() / array.Length;
		}

		public static double FindAverage2(double[] array)
		{
			return array.Length == 0 ? 0 : array.Average();
		}
	}

	[TestFixture]
	public class SolutionTest
	{
		[Test]
		public void ExampleTest()
		{
			double[] array = new double[] { 17, 16, 16, 16, 16, 15, 17, 17, 15, 5, 17, 17, 16 };
			Assert.AreEqual(200.0 / 13.0, AverageSolution.FindAverage(array));
			Assert.AreEqual(200.0 / 13.0, AverageSolution.FindAverage2(array));

			// Should return 0 on empty array
			Assert.AreEqual(0, AverageSolution.FindAverage(new double[] { }));

		}
	}
}
