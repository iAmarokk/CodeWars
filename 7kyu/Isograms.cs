using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
	public class Isograms
	{
		public static bool IsIsogram(string str)
		{
			Dictionary<char,int> numberChars = new Dictionary<char, int>();
            char[] obj = str.ToLower().ToCharArray();
            for (int i = 0; i < obj.Length; i++)
			{
                char c = obj[i];
				if (numberChars.ContainsKey(c))
				{
                    numberChars[obj[i]]++;
				}
				else
				{
                    numberChars[c] = 1;
				}
			}
            bool duplicate = true;
            foreach(int entry in numberChars.Values.ToList())
			{
                if (entry > 1)
				{
                    duplicate = false;
				}
			}
			return duplicate;
		}

        public static bool IsIsogram2(string str)
        {
            return str.Length == new HashSet<char>(str.ToLower()).Count;
        }

        public static bool IsIsogram3(string str)
        {
            return str.ToLower().Distinct().Count() == str.Length;
        }
    }

	public class IsogramTests
	{
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("Dermatoglyphics").Returns(true);
                yield return new TestCaseData("isogram").Returns(true);
                yield return new TestCaseData("moose").Returns(false);
                yield return new TestCaseData("isIsogram").Returns(false);
                yield return new TestCaseData("aba").Returns(false);
                yield return new TestCaseData("moOse").Returns(false);
                yield return new TestCaseData("thumbscrewjapingly").Returns(true);
                yield return new TestCaseData("").Returns(true);
            }
        }

        [Test, TestCaseSource("testCases")]
        public bool Test(string str) => Isograms.IsIsogram(str);
        [Test, TestCaseSource("testCases")]
        public bool Test2(string str) => Isograms.IsIsogram2(str);
        [Test, TestCaseSource("testCases")]
        public bool Test3(string str) => Isograms.IsIsogram3(str);
    }
}
