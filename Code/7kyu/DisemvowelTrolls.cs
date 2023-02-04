using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars._7kyu
{
	//Trolls are attacking your comment section!

	//A common way to deal with this situation is to remove all of the vowels from the trolls' comments, neutralizing the threat.

	//Your task is to write a function that takes a string and return a new string with all vowels removed.

	//For example, the string "This website is for losers LOL!" would become "Ths wbst s fr lsrs LL!".

	//Note: for this kata y isn't considered a vowel.

	internal class DisemvowelTrolls
	{
		public static string Disemvowel(string str)
		{
			HashSet<char> vowel = new HashSet<char>
			{
				'a', 'e', 'i', 'o', 'u',
				'A', 'E', 'I', 'O', 'U'
			};

			return string.Join("", str.ToCharArray().Where(m => !vowel.Contains(m)));
		}

		public static string Disemvowel2(string str)
		{
			return string.Concat(str.Where(ch => !"aeiouAEIOU".Contains(ch)));
		}
	}

	[TestFixture]
	public class DisemvowelTest
	{
		[Test]
		public void ShouldRemoveAllVowels()
		{
			Assert.AreEqual("Ths wbst s fr lsrs LL!", DisemvowelTrolls.Disemvowel("This website is for losers LOL!"));
			Assert.AreEqual("Ths wbst s fr lsrs LL!", DisemvowelTrolls.Disemvowel2("This website is for losers LOL!"));
		}

		[Test]
		public void MultilineString()
		{
			Assert.AreEqual("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd", DisemvowelTrolls.Disemvowel("No offense but,\nYour writing is among the worst I've ever read"));
			Assert.AreEqual("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd", DisemvowelTrolls.Disemvowel2("No offense but,\nYour writing is among the worst I've ever read"));
		}

		[Test]
		public void OneMoreForGoodMeasure()
		{
			Assert.AreEqual("Wht r y,  cmmnst?", DisemvowelTrolls.Disemvowel("What are you, a communist?"));
			Assert.AreEqual("Wht r y,  cmmnst?", DisemvowelTrolls.Disemvowel2("What are you, a communist?"));
		}
	}
}
