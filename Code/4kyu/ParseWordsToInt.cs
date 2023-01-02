using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars._4kyu
{
	//In this kata we want to convert a string into an integer. The strings simply represent the numbers in words.

	//Examples:
	//"one" => 1
	//"twenty" => 20
	//"two hundred forty-six" => 246
	//"seven hundred eighty-three thousand nine hundred and nineteen" => 783919
	//Additional Notes:

	//The minimum number is "zero" (inclusively)
	//The maximum number, which must be supported is 1 million (inclusively)
	//The "and" in e.g. "one hundred and twenty-four" is optional, in some cases it's present and in others it's not
	//All tested numbers are valid, you don't need to validate them

	internal class ParseWordsToInt
	{
		private static Dictionary<string, int> numberTable = new Dictionary<string, int>{
		{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},
		{"seven",7},{"eight",8},{"nine",9},{"ten",10},{"eleven",11},{"twelve",12},
		{"thirteen",13},{"fourteen",14},{"fifteen",15},{"sixteen",16},{"seventeen",17},
		{"eighteen",18},{"nineteen",19},{"twenty",20},{"thirty",30},{"forty",40},
		{"fifty",50},{"sixty",60},{"seventy",70},{"eighty",80},{"ninety",90},
		{"hundred",100},{"thousand",1000},{"lakh",100000},{"million",1000000},
		{"billion",1_000_000_000}
		};

		public static int ConvertToNumbers(string numberString)
		{
			var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
					.Select(m => m.Value.ToLowerInvariant())
					.Where(v => numberTable.ContainsKey(v))
					.Select(v => numberTable[v]);
			int acc = 0, total = 0;
			foreach (var n in numbers)
			{
				if (n >= 1000)
				{
					total += acc * n;
					acc = 0;
				}
				else if (n >= 100)
				{
					acc *= n;
				}
				else acc += n;
			}
			return (total + acc);
		}

		public static int ParseInt(string s)
		{
			return ConvertToNumbers(s);
		}
	}

	public class SolutionTest
	{
		[Test]
		public void FixedTests()
		{
			Assert.AreEqual(1, ParseWordsToInt.ParseInt("one"));
			Assert.AreEqual(20, ParseWordsToInt.ParseInt("twenty"));
			Assert.AreEqual(246, ParseWordsToInt.ParseInt("two hundred forty-six"));
		}
	}
}
