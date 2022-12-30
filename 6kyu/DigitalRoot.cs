using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWars._6kyu
{
	internal class DigitalRoot
	{
		public int Root(long n)
		{
			while(n.ToString().Length > 1)
			{
				n = (long)n
					.ToString()
					.ToCharArray()
					.Select(char.GetNumericValue)
					.Sum(x => x);
			}

			return (int)n;
		}

		public long Root2(long n)
		{
			return n < 10 ? n : Root2(n / 10 + n % 10);
		}

		public int Root3(long n)
		{
			while (n > 9)
			{
				n = n.ToString().Select(c => Convert.ToInt32(c.ToString())).Sum();
			}
			return (int)n;
		}

		public int Root4(long n)
		{
			return (int)(1 + (n - 1) % 9);
		}
	}

	[TestFixture]
	public class NumberTest
	{
		private DigitalRoot num;

		[SetUp]
		public void SetUp()
		{
			num = new DigitalRoot();
		}

		[TearDown]
		public void TearDown()
		{
			num = null;
		}

		[Test]
		public void Tests()
		{
			Assert.AreEqual(7, num.Root(16));
			Assert.AreEqual(6, num.Root(456));

			Assert.AreEqual(6, num.Root2(456));
			Assert.AreEqual(6, num.Root3(456));
			Assert.AreEqual(6, num.Root4(456));
		}
	}
}
