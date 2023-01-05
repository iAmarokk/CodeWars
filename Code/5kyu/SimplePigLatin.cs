using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars._5kyu
{
	//DESCRIPTION:
	//Move the first letter of each word to the end of it, then add "ay" to the end of the word.
	//Leave punctuation marks untouched.

	internal class SimplePigLatin
	{
		private const string pattern = @"[.!?\\-]";
		public static string PigIt(string str)
		{
			var data = str.Split(' ');
			List<string> r = new List<string>();
			foreach (var it in data)
			{
				if(Regex.Matches(it, pattern).Count < 1)
				{
					r.Add(string.Concat(it.Substring(1, it.Length - 1), it.ElementAt(0), "ay"));
				}
				else
				{
					r.Add(it);
				}
			}
			return string.Join(" ", r);
		}

		public static string PigIt2(string str)
		{
			return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));
		}

		public static string PigIt3(string str)
		{
			return Regex.Replace(str, @"((\S)(\S+))", "$3$2ay");
		}

		public static string PigIt4(string str)
		{
			return Regex.Replace(str, @"\b(\w)(\w+)\b", "$2$1ay");
		}
	}

	[TestFixture]
	public class SimplePigLatinTest
	{
		[Test]
		public void KataTests()
		{
			Assert.AreEqual("igPay atinlay siay oolcay", SimplePigLatin.PigIt("Pig latin is cool"));
			Assert.AreEqual("hisTay siay ymay tringsay", SimplePigLatin.PigIt("This is my string"));
			Assert.AreEqual("hisTay siay ymay tringsay", SimplePigLatin.PigIt2("This is my string"));
			Assert.AreEqual("hisTay siay ymay tringsay", SimplePigLatin.PigIt3("This is my string"));
			Assert.AreEqual("hisTay siay ymay tringsay", SimplePigLatin.PigIt4("This is my string"));
			Assert.AreEqual("elloHay orldway !", SimplePigLatin.PigIt("Hello world !"));
		}
	}
}
