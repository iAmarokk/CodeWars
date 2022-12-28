using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
	internal class SquareEveryDigit
	{
		public static int SquareDigits(int n)
		{
			List<int> digits = new List<int>();
			string s = n.ToString();
			for (int i = 0; i < s.Length; i++)
			{
				digits.Add((int)char.GetNumericValue(s[i]));
			}
			var s1 = digits.Select(x => x * x);
			var s2 = string.Join("",s1);
			return int.Parse(s2);
		}

		public static int SquareDigits2(int n)
		{
			var result =
				n
				.ToString()
				.ToCharArray()
				.Select(char.GetNumericValue)
				.Select(a => (a * a).ToString())
				.Aggregate("", (acc, s) => acc + s);
			return int.Parse(result);
		}

		public static int SquareDigits3(int n)
		{
			string output = string.Empty;
			foreach (char c in n.ToString())
			{
				int square = int.Parse(c.ToString());
				output += (square * square);
			}
			return int.Parse(output);
		}
	}

	[TestFixture]
	public class SquareEveryDigitTest
	{
		[Test]
		public void SquareDigitsTest()
		{
			Assert.AreEqual(811181, SquareEveryDigit.SquareDigits(9119));
			Assert.AreEqual(811181, SquareEveryDigit.SquareDigits2(9119));
			Assert.AreEqual(811181, SquareEveryDigit.SquareDigits3(9119));
			Assert.AreEqual(0, SquareEveryDigit.SquareDigits(0));
		}
	}
}
