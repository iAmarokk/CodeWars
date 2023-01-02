using NUnit.Framework;
using System;

namespace CodeWars._6kyu
{
	internal class BankerPlan
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="f0">Deposit </param>
		/// <param name="p">Percent per year </param>
		/// <param name="c0">Withdraw </param>
		/// <param name="n">Years</param>
		/// <param name="i">Percent </param>
		/// <returns></returns>
		public static bool Fortune(int f0, double p, int c0, int n, double i)
		{
			for (int j = 1; j < n; j++)
			{
				f0 = (int)Math.Truncate(f0 + p / 100 * f0 - c0);
				c0 = (int)Math.Truncate(c0 + i / 100 * c0);

				if (f0 < 0)
				{
					return false;
				}
			}
			return true;
		}

		public static bool Fortune2(int f0, double p, int c0, int n, double i)
		{
			for (; n > 1; n--)
			{
				f0 += (int)(f0 * p / 100) - c0;
				c0 += (int)(c0 * i / 100);
			}
			return f0 >= 0;
		}

		public static bool Fortune3(int f0, double p, int c0, int n, double i)
		{
			for (var year = 1; year < n; year++)
			{
				f0 = (int)Math.Truncate(f0 + p / 100 * f0 - c0);
				c0 = (int)Math.Truncate(c0 + i / 100 * c0);
			}

			return f0 >= 0;
		}


		public static bool Fortune4(int f0, double p, int c0, int n, double i)
					 => n > 1 ? Fortune4(f0 + (int)(f0 * p / 100) - c0, p, c0 + (int)(c0 * i / 100), n -= 1, i) : f0 >= 0;
	}

	[TestFixture]
	public static class BankerPlanTests
	{

		private static void testing(Boolean actual, Boolean expected)
		{
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public static void test1()
		{
			Console.WriteLine("Testing Fortune");
			testing(BankerPlan.Fortune(100000, 1, 2000, 15, 1), true);
			testing(BankerPlan.Fortune(100000, 1, 9185, 12, 1), false);
			testing(BankerPlan.Fortune(100000000, 1, 100000, 50, 1), true);
			testing(BankerPlan.Fortune(100000000, 1.5, 10000000, 50, 1), false);
			testing(BankerPlan.Fortune(100000000, 5, 1000000, 50, 1), true);

			testing(BankerPlan.Fortune2(100000000, 5, 1000000, 50, 1), true);
			testing(BankerPlan.Fortune3(100000000, 5, 1000000, 50, 1), true);
			testing(BankerPlan.Fortune4(100000000, 5, 1000000, 50, 1), true);
		}
	}
}
