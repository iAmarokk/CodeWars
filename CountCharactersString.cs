using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
	public class CountCharactersString
	{
        public static Dictionary<char, int> Count(string str)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (char c in str)
			{
				if (result.ContainsKey(c))
				{
                    result[c] = result[c] + 1;
				}
				else
				{
                    result[c] = 1;
				}
			}
            return result;
        }

        public static Dictionary<char, int> Count2(string str)
        {
            return str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public static void FixedTest_aaaa()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 4);
            Assert.AreEqual(d, CountCharactersString.Count("aaaa"));
        }

        [Test]
        public static void FixedTest_aabb()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 2);
            d.Add('b', 2);
            Assert.AreEqual(d, CountCharactersString.Count("aabb"));
            Assert.AreEqual(d, CountCharactersString.Count2("aabb"));
        }
    }
}
