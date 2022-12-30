using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars
{
	internal class TopWords
	{
		public static List<string> Top3(string s)
		{
			s = Regex.Replace(s, "[^a-zA-Z0-9_']+", " ");

			string[] data = s.ToLower().Split(' ');
			
			Dictionary<string, int> map = new Dictionary<string, int>();
			for (int i = 0; i < data.Count(); i++)
			{
				//string word = Regex.Replace(data[i], "[^a-zA-Z0-9_']+", "");
				string word = data[i];
				Match m = Regex.Match(word, "([\\w]+[']+)");
				if (word == string.Empty
					||
					(word.Contains("'") && m.Success == false))
				{
					continue;
				}

				if (map.ContainsKey(word))
				{
					map[word]++;
				}
				else
				{
					map[word] = 1;
				}
			}

			return map.OrderByDescending(x => x.Value).Select(x=> x.Key).Take(3).ToList();
		}
	}

	public class TopWordsTest
	{

		[Test]
		public void SampleTests()
		{
			Assert.AreEqual(new List<string> { "zhheecrdv", "kfbsmxyyd", "zbyuuh" }, TopWords.Top3("PvJZQkgd pvMxP ZhHEeCrDV Yplb:ZhHEeCrDV:kFBSMXyyd' ? pvMxP-ZhHEeCrDV ZhHEeCrDV?kFBSMXyyd'_kFBSMXyyd' cgFv pvMxP_Yplb:PvJZQkgd.ZhHEeCrDV ZhHEeCrDV.PvJZQkgd-cgFv!kFBSMXyyd'!PvJZQkgd/ZhHEeCrDV zbyUuh Yplb PvJZQkgd!kFBSMXyyd' cgFv ZhHEeCrDV,Yplb.ZhHEeCrDV PvJZQkgd cgFv!cgFv cgFv PvJZQkgd pvMxP.kFBSMXyyd'.kFBSMXyyd' ZhHEeCrDV Yplb ZhHEeCrDV PvJZQkgd ZhHEeCrDV zbyUuh kFBSMXyyd';kFBSMXyyd'-cgFv?pvMxP/ZhHEeCrDV kFBSMXyyd' pvMxP ZhHEeCrDV?zbyUuh ZhHEeCrDV_Yplb ZhHEeCrDV?Yplb-zbyUuh zbyUuh zbyUuh zbyUuh_Yplb.ZhHEeCrDV.pvMxP zbyUuh zbyUuh?Yplb ZhHEeCrDV zbyUuh ZhHEeCrDV:zbyUuh,ZhHEeCrDV kFBSMXyyd' zbyUuh kFBSMXyyd'-ZhHEeCrDV-ZhHEeCrDV,cgFv!ZhHEeCrDV kFBSMXyyd' tvo Yplb.zbyUuh cgFv?PvJZQkgd:kFBSMXyyd' Yplb cgFv-ZhHEeCrDV zbyUuh kFBSMXyyd' pvMxP pvMxP;cgFv Yplb kFBSMXyyd'!Yplb!ZhHEeCrDV;pvMxP zbyUuh kFBSMXyyd',kFBSMXyyd'-pvMxP_PvJZQkgd_PvJZQkgd zbyUuh.pvMxP zbyUuh;PvJZQkgd kFBSMXyyd':ZhHEeCrDV/ZhHEeCrDV/cgFv;tvo,kFBSMXyyd' PvJZQkgd:PvJZQkgd,zbyUuh"));

			Assert.AreEqual(new List<string> { "e", "d", "a" }, TopWords.Top3("a a a  b  c c  d d d d  e e e e e"));
			Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, TopWords.Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
			Assert.AreEqual(new List<string> { "won't", "wont", "wont'" }, TopWords.Top3("  //wont won't won't wont' "));
			Assert.AreEqual(new List<string> { "e" }, TopWords.Top3("  , e   .. "));
			Assert.AreEqual(new List<string> { }, TopWords.Top3("  ...  "));
			Assert.AreEqual(new List<string> { }, TopWords.Top3("  '  "));
			Assert.AreEqual(new List<string> { "pfzvwzpxpr" }, TopWords.Top3("  pfzvwzpxpr   pfzvwzpxpr pfzvwzpxpr"));
			Assert.AreEqual(new List<string> { }, TopWords.Top3("  '''  "));
			Assert.AreEqual(new List<string> { "a", "of", "on" }, TopWords.Top3(
				string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
				  "mind, there lived not long since one of those gentlemen that keep a lance",
				  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
				  "coursing. An olla of rather more beef than mutton, a salad on most",
				  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
				  "on Sundays, made away with three-quarters of his income." })));
		}
	}
}
