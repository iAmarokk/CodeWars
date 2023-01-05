using NUnit.Framework;
using System.Linq;
using System.Numerics;

namespace CodeWars._4kyu
{
	//We need to sum big numbers and we require your help.

	//Write a function that returns the sum of two numbers.The input numbers are strings and the function must return a string.

	//Example
	//add("123", "321"); -> "444"
	//add("11", "99");   -> "110"
	//Notes
	//The input numbers are big.
	//The input is a string of only digits
	//The numbers are positives

	internal class AddingBigNumbers
	{
		public static string Add(string a, string b)
		{
			while (b.Length < a.Length)
			{
				b = "0" + b;
			}

			while (a.Length < b.Length)
			{
				a = "0" + a;
			}

			int[] c = new int[a.Length + 1];
			int p = 0;
			for (int i = a.Length - 1; i >= 0; i--)
			{
				c[i + 1] = (a.ElementAt(i) - '0') + (b.ElementAt(i) - '0') + p;
				if (c[i + 1] > 9)
				{
					c[i + 1] %= 10;
					p = 1;
				}
				else
				{
					p = 0;
				}
			}
			if (p == 1)
			{
				c[0] = p;
			}
			var numbersList = c.ToList();
			if(numbersList.ElementAt(0) == 0)
			{
				numbersList.Remove(0);
			}

			return string.Join("", numbersList);
		}

		public static string Add2(string a, string b)
		{
			return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString();
		}

		public static string Add3(string a, string b)
		{
			return $"{BigInteger.Parse(a) + BigInteger.Parse(b)}";
		}
	}

	[TestFixture]
	public class AddingBigNumbersTest
	{
		[Test]
		public void ASimpleKataTest()
		{
			Assert.AreEqual("222", AddingBigNumbers.Add("111", "111"));
			Assert.AreEqual("110", AddingBigNumbers.Add("91", "19"));
			Assert.AreEqual("1111111111", AddingBigNumbers.Add("123456789", "987654322"));
			Assert.AreEqual("1000000000", AddingBigNumbers.Add("999999999", "1"));
			Assert.AreEqual("1000000000", AddingBigNumbers.Add2("999999999", "1"));
		}
	}
}
