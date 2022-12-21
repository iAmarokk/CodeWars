using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
	internal class WhoLikesIt
	{
		public static string Likes(string[] name)
		{
			switch (name.Length)
			{
				case 0:
					return "no one likes this";
				case 1:
					return $"{name[0]} likes this";
				case 2:
					return $"{name[0]} and {name[1]} like this";
				case 3:
					return $"{name[0]}, {name[1]} and {name[2]} like this";
				default:
					return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
			}
		}
	}

	[TestFixture]
	public class WhoLikesItTest
	{
		[Test, Description("It should return correct text")]
		public void SampleTest()
		{
			Assert.AreEqual("no one likes this", WhoLikesIt.Likes(new string[0]));
			Assert.AreEqual("Peter likes this", WhoLikesIt.Likes(new string[] { "Peter" }));
			Assert.AreEqual("Jacob and Alex like this", WhoLikesIt.Likes(new string[] { "Jacob", "Alex" }));
			Assert.AreEqual("Max, John and Mark like this", WhoLikesIt.Likes(new string[] { "Max", "John", "Mark" }));
			Assert.AreEqual("Alex, Jacob and 2 others like this", WhoLikesIt.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }));
		}
	}
}
