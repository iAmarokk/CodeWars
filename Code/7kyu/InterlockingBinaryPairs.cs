using NUnit.Framework;
using System;
using System.Collections;

namespace CodeWars._7kyu
{

	//Task
	//Write a function that checks if two non-negative integers make an "interlocking binary pair".

	//Interlock?
	//numbers can be interlocked if their binary representations have no 1's in the same place
	//comparisons are made by bit position, starting from right to left(see the examples below)
	//when representations are of different lengths, the unmatched left-most bits are ignored

	//Examples
	//a = 9, b = 4
	//Stacking representations shows how they can interlock.

	// 9    1001
	// 4    0100

	internal class InterlockingBinaryPairs
	{
		public static bool Interlockable(ulong a, ulong b)
		{
			var aArray = new BitArray(BitConverter.GetBytes(a));
			var bArray = new BitArray(BitConverter.GetBytes(b));
			var result = aArray.And(bArray);
			for (int i = 0; i < result.Length; i++)
			{
				if (result[i])
				{
					return false;
				}
			}
			return true;
		}

		public static bool Interlockable2(ulong a, ulong b)
		{
			return (a & b) == 0;
		}
	}

	[TestFixture]
	public class Tester
	{
		[Test]
		public void SampleTests()
		{
			Object[][] tests = {
				new Object[] { true,  9UL, 4UL },
				new Object[] { false, 5UL, 6UL },
				new Object[] { true,  2UL, 5UL },
				new Object[] { false, 7UL, 1UL },
				new Object[] { true,  0UL, 8UL }
			};
			foreach (Object[] test in tests)
			{
				bool expected = (bool)test[0];
				ulong a = (ulong)test[1];
				ulong b = (ulong)test[2];

				bool submitted = InterlockingBinaryPairs.Interlockable(a, b);
				string message = "a = " + a + "\n  b = " + b;
				Assert.AreEqual(expected, submitted, message);

				submitted = InterlockingBinaryPairs.Interlockable2(a, b);
				message = "a = " + a + "\n  b = " + b;
				Assert.AreEqual(expected, submitted, message);
			}
		}
	}
}
