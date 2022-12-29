using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CodeWars
{
	internal static class JadenCasingStrings
	{
		public static string ToJadenCase(this string phrase)
		{
			List<char> data = new List<char>(phrase);
			string result = string.Empty;
			for (int i = 0; i < data.Count; i++)
			{
				if(i == 0)
				{
					result += data[i].ToString().ToUpper();
				}
				else
				{
					if (char.IsWhiteSpace((data[i-1])))
					{
						result += data[i].ToString().ToUpper();
					}
					else
					{
						result += data[i].ToString();
					}
				}
			}
			return result;
		}

		public static string ToJadenCase2(this string phrase)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
		}

		public static string ToJadenCase3(this string phrase)
		{
			return string.Join(" ", phrase.Split(' ').Select(str => char.ToUpper(str[0]) + str.Substring(1)));
		}
	}

	[TestFixture]
	public class JadenCaseTest
	{
		[Test]
		public void FixedTest()
		{
			Assert.AreEqual("How Can Mirrors Be Real If Our Eyes Aren't Real",
							"How can mirrors be real if our eyes aren't real".ToJadenCase(),
							"Strings didn't match.");
			Assert.AreEqual("How Real",
				"How real".ToJadenCase2(),
				"Strings didn't match.");
			Assert.AreEqual("How Real",
				"How real".ToJadenCase3(),
				"Strings didn't match.");
		}
	}
}
