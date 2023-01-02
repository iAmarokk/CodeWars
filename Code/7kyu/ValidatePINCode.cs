using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars
{
	public class ValidatePINCode
	{
		public static bool ValidatePin(string pin)
		{
			int count = pin.Where(Char.IsDigit).Count();
			if(pin.Length == count)
			{
				if (count == 4 || count == 6)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		public static bool ValidatePin2(string pin)
		{
			return Regex.IsMatch(pin, @"^(\d{6}|\d{4})\z");
		}

		public static bool ValidatePin3(string pin) =>
		  (pin.Length == 4 || pin.Length == 6) && pin.All(Char.IsDigit);
	}

	[TestFixture]
	public class ValidatePINCodeTest
	{
		[Test, Description("ValidatePin should return false for pins with length other than 4 or 6")]
		public void LengthTest()
		{
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("1"), "Wrong output for \"1\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("12"), "Wrong output for \"12\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("123"), "Wrong output for \"123\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("12345"), "Wrong output for \"12345\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("1234567"), "Wrong output for \"1234567\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("-1234"), "Wrong output for \"-1234\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("1.234"), "Wrong output for \"1.234\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("00000000"), "Wrong output for \"00000000\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin2("00000000"), "Wrong output for \"00000000\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin3("00000000"), "Wrong output for \"00000000\"");
		}

		[Test, Description("ValidatePin should return false for pins which contain characters other than digits")]
		public void NonDigitTest()
		{
			Assert.AreEqual(false, ValidatePINCode.ValidatePin("a234"), "Wrong output for \"a234\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin(".234"), "Wrong output for \".234\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin2(".234"), "Wrong output for \".234\"");
			Assert.AreEqual(false, ValidatePINCode.ValidatePin3(".234"), "Wrong output for \".234\"");
		}

		[Test, Description("ValidatePin should return true for valid pins")]
		public void ValidTest()
		{
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("1234"), "Wrong output for \"1234\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("0000"), "Wrong output for \"0000\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("1111"), "Wrong output for \"1111\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("123456"), "Wrong output for \"123456\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("098765"), "Wrong output for \"098765\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("000000"), "Wrong output for \"000000\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin("090909"), "Wrong output for \"090909\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin2("090909"), "Wrong output for \"090909\"");
			Assert.AreEqual(true, ValidatePINCode.ValidatePin3("090909"), "Wrong output for \"090909\"");
		}
	}
}
