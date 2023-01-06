using NUnit.Framework;
using System;
using System.Linq;
using System.Net;

namespace CodeWars._5kyu
{
	internal class CountIPAddresses
	{
		//Implement a function that receives two IPv4 addresses, and returns the number
		//of addresses between them(including the first one, excluding the last one).

		//All inputs will be valid IPv4 addresses in the form of strings.The last address
		//will always be greater than the first one.

		public static long IpsBetween(string start, string end)
		{
			var a = start.Split('.')
			.Select(long.Parse)
			.Aggregate((c, d) => (c << 8) + d);

			var b = end.Split('.')
			.Select(long.Parse)
			.Aggregate((c, d) => (c << 8) + d);

			return b - a;
		}

		public static long IpsBetween2(string start, string end)
		{
			return (uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(end).Address) -
					(uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(start).Address);
		}

		public static long IpsBetween3(string start, string end)
		{
			return GetSum(end) - GetSum(start);
		}

		public static long GetSum(string ip)
		{
			byte[] addressBytes = IPAddress
			  .Parse(ip)
			  .GetAddressBytes()
			  .Reverse()
			  .ToArray();

			return BitConverter.ToUInt32(addressBytes, 0);
		}
	}

	public class CountIPAddressesTest
	{
		[Test]
		public void SmapleTest()
		{
			Assert.AreEqual(50, CountIPAddresses.IpsBetween("10.0.0.0", "10.0.0.50"));
			Assert.AreEqual(246, CountIPAddresses.IpsBetween("20.0.0.10", "20.0.1.0"));
			Assert.AreEqual(246, CountIPAddresses.IpsBetween2("20.0.0.10", "20.0.1.0"));
			Assert.AreEqual(246, CountIPAddresses.IpsBetween3("20.0.0.10", "20.0.1.0"));
			Assert.AreEqual((1L << 32) - 1L, CountIPAddresses.IpsBetween("0.0.0.0", "255.255.255.255"));
		}
	}
}
