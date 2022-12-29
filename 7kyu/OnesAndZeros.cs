using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWars
{
	class OnesAndZeros
	{
		public static int binaryArrayToNumber(int[] binaryArray)
		{
			string s = string.Empty;
			for (int i = 0; i < binaryArray.Length; i++)
			{
				s += binaryArray[i];
			}
			return Convert.ToInt32(s, 2);
		}
	}

	[TestFixture]
	class OnesAndZerosTests
	{
		int[] Test1 = new int[] { 0, 0, 0, 0 };
		int[] Test2 = new int[] { 1, 1, 1, 1 };
		int[] Test3 = new int[] { 0, 1, 1, 0 };
		int[] Test4 = new int[] { 0, 1, 0, 1 };
		[Test]
		public void BasicTesting()
		{
			Assert.AreEqual(0, OnesAndZeros.binaryArrayToNumber(this.Test1));
			Assert.AreEqual(15, OnesAndZeros.binaryArrayToNumber(this.Test2));
			Assert.AreEqual(6, OnesAndZeros.binaryArrayToNumber(this.Test3));
			Assert.AreEqual(5, OnesAndZeros.binaryArrayToNumber(this.Test4));
		}
	}

	class Kata
	{
		public static int binaryArrayToNumber(int[] BinaryArray)
		{
			return Convert.ToInt32(string.Join("", BinaryArray), 2);
		}

		public static int binaryArrayToNumber2(int[] BinaryArray)
		{
			int sum = 0;
			int n = 0;
			for (int i = BinaryArray.Length - 1; i >= 0; i--)
			{
				if (BinaryArray[i] == 1)
				{
					sum += (int)Math.Pow(2, n);
				}
				n++;
			}
			return sum;
		}

		public static int binaryArrayToNumber3(int[] BinaryArray)
		{
			return (int)BinaryArray.Reverse().Select((x, i) => x * Math.Pow(2, i)).Sum();
		}
	}
}
