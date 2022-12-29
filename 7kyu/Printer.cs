using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace CodeWars
{
	static class Printer
	{
		public static string PrinterError(string s)
		{
			char[] letters = s.ToCharArray();
			int errorsCount = 0;
			for (int i = 0; i < letters.Length; i++)
			{
				if(letters[i] > 109)
				{
					errorsCount++;
				}
			}
			return string.Format("{0}/{1}", errorsCount, s.Length);
		}
	}

	[TestFixture]
	class PrinterTests
	{
		[Test]
		public static void test1()
		{
			Console.WriteLine("Testing PrinterError");
			string s = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
			Assert.AreEqual("3/56", Printer.PrinterError(s));
		}
	}

	static class Printer2
	{
		private const string pattern = @"[^a-m]";
		public static string PrinterError(String s)
		{
			return $"{Regex.Matches(s, pattern).Count}/{s.Length}";
		}
	}
}
