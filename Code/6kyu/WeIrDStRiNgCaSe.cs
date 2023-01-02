using NUnit.Framework;
using System.Linq;
using System.Text;

namespace CodeWars
{
	static class WeIrDStRiNgCaSe
	{
		public static string ToWeirdCase(string s)
		{
			string[] obj = s.Split(' ');
			for (int i = 0; i < obj.Length; i++)
			{
				char[] c = obj[i].ToCharArray();
				for (int j = 0; j < c.Length; j++)
				{
					if(j % 2 == 0)
					{
						c[j] = char.ToUpper(c[j]);
					}
					else
					{
						c[j] = char.ToLower(c[j]);
					}
				}
				obj[i] = new string(c);
			}
			return string.Join(' ', obj);
		}

		public static string ToWeirdCase2(string s)
		{
			return string.Join(" ",
			  s.Split(' ')
			  .Select(w => string.Concat(
				w.Select((ch, i) => i % 2 == 0 ? char.ToUpper(ch) : char.ToLower(ch)
			  ))));
		}

		public static string ToWeirdCase3(string s)
		{
			var stringBuilder = new StringBuilder();
			foreach (var str in s.Split(" "))
			{
				for (var i = 0; i < str.Length; i++)
					stringBuilder.Append(i % 2 == 0 ? char.ToUpper(str[i]) : char.ToLower(str[i]));
				stringBuilder.Append(" ");
			}
			return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
		}
	}

	[TestFixture]
	class WeIrDStRiNgCaSeTests
	{
		[Test]
		public static void ShouldWorkForSomeExamples()
		{
			Assert.AreEqual("ThIs", WeIrDStRiNgCaSe.ToWeirdCase("This"));
			Assert.AreEqual("Is", WeIrDStRiNgCaSe.ToWeirdCase("is"));
			Assert.AreEqual("ThIs Is A TeSt", WeIrDStRiNgCaSe.ToWeirdCase("This is a test"));
			Assert.AreEqual("S PmW Ua DiHy W Zd", WeIrDStRiNgCaSe.ToWeirdCase("S pmw ua dihy w zd"));
		}
	}
}
