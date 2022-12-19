using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWars
{
	public class DetectPangram
	{
		public static bool IsPangram(string str)
		{
			str = str.ToLower();
			var str2 = str.Distinct();
			//формула
			int sum = (97 + 122) * (122 - 97 + 1) / 2;

			foreach(char c in str2)
			{
				int v = (int)c;
				if(v >= 97 && v <= 122)
				{
					sum -= v;
				}
			}

			if(sum == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool IsPangram2(string str)
		{
			return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
		}

		public static bool IsPangram3(string str) =>
			  str.ToLower()
				 .Where(Char.IsLetter)
				 .Distinct()
				 .Count() == 26;
	}


	[TestFixture]
	public class TestsDetectPangram
	{
		[Test]
		public void SampleTests()
		{
			Assert.AreEqual(true, DetectPangram.IsPangram("The quick brown fox jumps over the lazy dog."));
			Assert.AreEqual(true, DetectPangram.IsPangram2("The quick brown fox jumps over the lazy dog."));
			Assert.AreEqual(true, DetectPangram.IsPangram3("The quick brown fox jumps over the lazy dog."));
		}
	}

	//вычисление суммы
	//int sum = 0;
	//for(int i = 97; i <= 122; i++)
	//{
	//	sum += i;
	//}
}
