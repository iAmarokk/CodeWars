using NUnit.Framework;

namespace CodeWars._6kyu
{
	//Write a function that accepts an array of 10 integers(between 0 and 9), 
	//that returns a string of those numbers in the form of a phone number.

	internal class CreatePhoneNumber
	{
        public static string Create(int[] numbers)
        {
            return $"({numbers[0]}{numbers[1]}{numbers[2]}) {numbers[3]}{numbers[4]}{numbers[5]}-{numbers[6]}{numbers[7]}{numbers[8]}{numbers[9]}";
        }

        public static string Create2(int[] numbers)
        {
            return int.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, ExpectedResult = "(123) 456-7890")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]
        public static string FixedTest(int[] numbers)
        {
            return CreatePhoneNumber.Create(numbers);
        }        
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, ExpectedResult = "(123) 456-7890")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]
        public static string FixedTest2(int[] numbers)
        {
            return CreatePhoneNumber.Create2(numbers);
        }
    }
}
