using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace CodeWars._6kyu
{
	//DESCRIPTION:
	//Create a function taking a positive integer between 1 and 3999 (both included) as its
	//parameter and returning a string containing the Roman Numeral representation of that integer.

	//Modern Roman numerals are written by expressing each digit separately
	//starting with the left most digit and skipping any digit with a value of zero.
	//In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC.
	//2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.

	//Example:
	//RomanConvert.Solution(1000) -- should return "M"

	internal class RomanNumeralsEncoder
	{
		static Dictionary<int, string> NumberRomanDictionary = new Dictionary<int, string>
		{
			{ 1000, "M" },
			{ 900, "CM" },
			{ 500, "D" },
			{ 400, "CD" },
			{ 100, "C" },
			{ 90, "XC" },
			{ 50, "L" },
			{ 40, "XL" },
			{ 10, "X" },
			{ 9, "IX" },
			{ 5, "V" },
			{ 4, "IV" },
			{ 1, "I" },
		};

		public static string Solution(int n)
		{
			var roman = new StringBuilder();

			foreach (var item in NumberRomanDictionary)
			{
				if(n == 0)
				{
					break;
				}

				while (n >= item.Key)
				{
					roman.Append(item.Value);
					n -= item.Key;
				}
			}

			return roman.ToString();
		}

		public static string Solution2(int n)
		{
			string roman = string.Empty;
			string[] thousand = { "", "M", "MM", "MMM" };
			string[] hundred = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
			string[] ten = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
			string[] one = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

			roman += thousand[(n / 1000) % 10];
			roman += hundred[(n / 100) % 10];
			roman += ten[(n / 10) % 10];
			roman += one[n % 10];

			return roman;

		}
	}


	[TestFixture]
	public class RomanConvertTests
	{
		[TestCase(1, "I")]
		[TestCase(2, "II")]
		[TestCase(4, "IV")]
		[TestCase(500, "D")]
		[TestCase(1000, "M")]
		[TestCase(1954, "MCMLIV")]
		[TestCase(1990, "MCMXC")]
		[TestCase(2008, "MMVIII")]
		[TestCase(2014, "MMXIV")]
		public void Test(int value, string expected)
		{
			Assert.AreEqual(expected, RomanNumeralsEncoder.Solution(value));
		}
		[TestCase(1, "I")]
		[TestCase(2, "II")]
		[TestCase(4, "IV")]
		[TestCase(500, "D")]
		[TestCase(1000, "M")]
		[TestCase(1954, "MCMLIV")]
		[TestCase(1990, "MCMXC")]
		[TestCase(2008, "MMVIII")]
		[TestCase(2014, "MMXIV")]
		public void Test2(int value, string expected)
		{
			Assert.AreEqual(expected, RomanNumeralsEncoder.Solution2(value));
		}
	}
}
