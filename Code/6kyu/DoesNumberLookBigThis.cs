using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

//A Narcissistic Number (or Armstrong Number) is a positive number which is the sum of its own digits,
//each raised to the power of the number of digits in a given base. In this Kata, we will restrict ourselves to decimal (base 10).

//For example, take 153 (3 digits), which is narcisstic:

//    1 ^ 3 + 5 ^ 3 + 3 ^ 3 = 1 + 125 + 27 = 153
//and 1652(4 digits), which isn't:

//    1^4 + 6^4 + 5^4 + 2^4 = 1 + 1296 + 625 + 16 = 1938

namespace CodeWars._6kyu
{
	internal class DoesNumberLookBigThis
	{
		public static bool Narcissistic(int value)
		{
			var r = value
				.ToString()
				.ToCharArray()
				.Select(char.GetNumericValue)
				.Select(x => Math.Pow(x, value.ToString().Length))
				.Sum(x => x);

			return r == value;
		}

		public static bool Narcissistic2(int value)
		{
			return $"{value}".Sum(c => Math.Pow(c - '0', $"{value}".Length)) == value;
		}

		public static bool Narcissistic3(int value)
		{
			var sValue = value.ToString();
			return sValue.Sum(x => Math.Pow(x - '0', sValue.Length)) == value;
		}

	}

	[TestFixture]
	public class DoesNumberLookBigThisTest
	{
		private static IEnumerable<TestCaseData> testCases
		{
			get
			{
				yield return new TestCaseData(1)
								.Returns(true)
								.SetDescription("1 is narcissitic");
				yield return new TestCaseData(371)
								.Returns(true)
								.SetDescription("371 is narcissitic");

			}
		}

		[Test, TestCaseSource("testCases")]
		public bool Test(int n) => DoesNumberLookBigThis.Narcissistic(n);
		[Test, TestCaseSource("testCases")]
		public bool Test2(int n) => DoesNumberLookBigThis.Narcissistic2(n);
		[Test, TestCaseSource("testCases")]
		public bool Test3(int n) => DoesNumberLookBigThis.Narcissistic3(n);
	}
}
