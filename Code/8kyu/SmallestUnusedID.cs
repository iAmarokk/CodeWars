using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWars._8kyu
{

	//Hey awesome programmer!

	//You've got much data to manage and of course you use zero-based and non-negative ID's to make each data item unique!

	//Therefore you need a method, which returns the smallest unused ID for your next new data item...

	//Note: The given array of used IDs may be unsorted.For test reasons there may be duplicate IDs,
	//but you don't have to find or remove them!

	//Go on and code some pure awesomeness!

	internal class SmallestUnusedID
	{
		public static int NextId(int[] ids)
		{
			Array.Sort(ids);
			if (!ids.Contains(0))
			{
				return 0;
			}

			for(int i = 1; i < ids.Length; i++)
			{
				if(ids[i] != i)
				{
					return i;
				}
			}

			return ids.Max() + 1;
		}

		public static int NextId2(int[] ids)
		{
			int i = 0;
			while (ids.Contains(i))
			{
				i++;
			}

			return i;
		}

		public static int NextId3(int[] ids)
		{
			return Enumerable.Range(0, ids.Length + 1).Except(ids).Min();
		}
	}

	[TestFixture]
	public class SmallestUnusedIDTests
	{
		[Test]
		[TestCase(new int[] { 0, 1, 2, 3, 5 }, ExpectedResult = 4)]
		[TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, ExpectedResult = 11)]
		[TestCase(new int[] { 9, 9, 8 }, ExpectedResult = 0)]
		public static int FixedTest(int[] ids)
		{
			return SmallestUnusedID.NextId(ids);
		}

		[Test]
		[TestCase(new int[] { 0, 1, 2, 3, 5 }, ExpectedResult = 4)]
		[TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, ExpectedResult = 11)]
		[TestCase(new int[] { 9, 9, 8 }, ExpectedResult = 0)]
		public static int FixedTest2(int[] ids)
		{
			return SmallestUnusedID.NextId2(ids);
		}

		[Test]
		[TestCase(new int[] { 0, 1, 2, 3, 5 }, ExpectedResult = 4)]
		[TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, ExpectedResult = 11)]
		[TestCase(new int[] { 9, 9, 8 }, ExpectedResult = 0)]
		public static int FixedTest3(int[] ids)
		{
			return SmallestUnusedID.NextId3(ids);
		}
	}
}
