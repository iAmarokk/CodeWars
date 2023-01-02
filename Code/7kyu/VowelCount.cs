using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars._7kyu
{
    //    Return the number(count) of vowels in the given string.

    //We will consider a, e, i, o, u as vowels for this Kata (but not y).

    //The input string will only consist of lower case letters and/or spaces.

    internal class VowelCount
	{
        public static int GetVowelCount(string str)
        {
            HashSet<char> vowel = new HashSet<char>
            {
                'a', 'e', 'i', 'o', 'u'
            };

            return str.ToCharArray().Where(m => vowel.Contains(m)).Count();

        }

        public static int GetVowelCount2(string str)
        {
            return str.Count(i => "aeiou".Contains(i));
        }

        [TestFixture]
        public class KataTests
        {
            [Test]
            public void TestCase1()
            {
                Assert.AreEqual(5, VowelCount.GetVowelCount("abracadabra"), "Nope!");
                Assert.AreEqual(5, VowelCount.GetVowelCount2("abracadabra"), "Nope!");
                Assert.AreEqual(5, VowelCount.GetVowelCount("aeiou"), "Nope!");
            }
        }
    }
}
