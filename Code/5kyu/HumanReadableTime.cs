using NUnit.Framework;

namespace CodeWars._5kyu
{
	//Write a function, which takes a non-negative integer(seconds) as input and returns the time in a human-readable format(HH:MM:SS)

	//HH = hours, padded to 2 digits, range: 00 - 99
	//MM = minutes, padded to 2 digits, range: 00 - 59
	//SS = seconds, padded to 2 digits, range: 00 - 59
	//The maximum time never exceeds 359999 (99:59:59)

	//You can find some examples in the test fixtures.


	internal class HumanReadableTime
	{
		public static string GetReadableTime(int seconds)
		{
			int[] time = new int[3];
			if(seconds > 3599)
			{
				time[0] = seconds / 3600;
				seconds -= time[0] * 3600;
			}
			if(seconds > 59)
			{
				time[1] = seconds / 60;
				seconds -= time[1] * 60;
			}
			time[2] = seconds;

			return string.Format("{0:d2}:{1:d2}:{2:d2}", time[0], time[1], time[2]);
		}

		public static string GetReadableTime2(int seconds)
		{
			var item = string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);
			return item;
		}

		public static string GetReadableTime3(int seconds)
		{
			int sec = (seconds % 60);
			int min = ((seconds - sec) / 60) % 60;
			int hour = (seconds - sec - (60 * min)) / (60 * 60);

			return (hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00"));
		}
	}

	[TestFixture]
	public class HumanReadableTimeTest
	{
		[Test]
		public void HumanReadableTest()
		{
			Assert.AreEqual("00:00:00", HumanReadableTime.GetReadableTime(0));
			Assert.AreEqual("00:00:00", HumanReadableTime.GetReadableTime2(0));
			Assert.AreEqual("00:00:00", HumanReadableTime.GetReadableTime3(0));
			Assert.AreEqual("00:00:05", HumanReadableTime.GetReadableTime(5));
			Assert.AreEqual("00:01:00", HumanReadableTime.GetReadableTime(60));
			Assert.AreEqual("00:02:10", HumanReadableTime.GetReadableTime(130));
			Assert.AreEqual("23:59:59", HumanReadableTime.GetReadableTime(86399));
			Assert.AreEqual("99:59:59", HumanReadableTime.GetReadableTime(359999));
			Assert.AreEqual("99:59:59", HumanReadableTime.GetReadableTime2(359999));
			Assert.AreEqual("99:59:59", HumanReadableTime.GetReadableTime3(359999));
		}
	}
}
