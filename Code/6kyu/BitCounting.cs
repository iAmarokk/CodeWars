using NUnit.Framework;
using System.Numerics;

namespace CodeWars._6kyu
{
	//	Write a function that takes an integer as input, and returns the number of bits
	//	that are equal to one in the binary representation of that number.You can guarantee that input is non-negative.

	//Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case

	internal class BitCounting
	{
		public static int CountBits(int n)
		{
			int sum = 0;
			for (int i = 0; n > 0; i++)
			{
				sum += n % 2;
				n = n / 2;
			}
			return sum;
		}

		public static int CountBits2(int n)
		{
			return BitOperations.PopCount((uint)n);
		}
	}

	[TestFixture]
	public class BitCountingTest
	{
		[Test]
		public void CountBits()
		{
			Assert.AreEqual(0, BitCounting.CountBits(0));
			Assert.AreEqual(1, BitCounting.CountBits(4));
			Assert.AreEqual(3, BitCounting.CountBits(7));
			Assert.AreEqual(2, BitCounting.CountBits(9));
			Assert.AreEqual(2, BitCounting.CountBits(10));
			Assert.AreEqual(2, BitCounting.CountBits2(10));
		}
	}
}
