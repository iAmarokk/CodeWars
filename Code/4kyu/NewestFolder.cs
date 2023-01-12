using NUnit.Framework;
using System.IO;
using System.Linq;

namespace CodeWars._4kyu
{
	internal class NewestFolder
	{
		public static string Folder(string path)
		{
			var item = new DirectoryInfo(path).GetDirectories()
							.OrderByDescending(d => d.LastWriteTime).First();
			return item.FullName;
		}
	}

	public class NewestFolderTest
	{
		[Test]
		public void SimpleTest()
		{
			Assert.AreEqual("E:\\Temp\\FinistSBP_221122_1.3.1.3", NewestFolder.Folder("E:\\Temp"));
		}
	}
}
