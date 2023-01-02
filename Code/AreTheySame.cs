using NUnit.Framework;

namespace CodeWars
{
	internal class AreTheySame
	{
		public static bool comp(int[] a, int[] b)
		{
			bool result = false;
			for (int i = 0; i < b.Length; i++)
			{
				result = false;
				for (int j = 0; j < a.Length; j++)
				{
					if (b[i] % a[j] == a[j] || b[i] % a[j] == 0)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}
	}

	[TestFixture]
	public class AreTheySameTests
	{

		[Test]
		public void Test1()
		{
			int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
			int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
			bool r = AreTheySame.comp(a, b); // True
			Assert.AreEqual(true, r);
		}
	}
}
