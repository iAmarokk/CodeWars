using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars._6kyu
{
    //Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.
    //It should remove all values from list a, which are present in list b keeping their order.

    public class ArrayDiffCl
    {

        public static int[] ArrayDiff(int[] a, int[] b)
		{
            var u2 = b.ToHashSet();
            var res = new List<int>();
			for(int i = 0; i < a.Length; i++)
			{
				if (!u2.Contains(a[i]))
				{
                    res.Add(a[i]);
				}
			}
            return res.ToArray();
        }

        public static int[] ArrayDiff2(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n)).ToArray();
        }

        public static int[] ArrayDiff3(int[] a, int[] b)
        {
            // With a hashset, we won't have to iterate over b for every item in a.
            // Instead, we can check if an item exists in constant time
            HashSet<int> bSet = new HashSet<int>(b);

            return a.Where(v => !bSet.Contains(v)).ToArray();
        }

        public static int[] ArrayDiff4(int[] a, int[] b) => Array.FindAll(a, m => !b.Contains(m));
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest()
        {
			Assert.AreEqual(new int[] { 2 }, ArrayDiffCl.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
			Assert.AreEqual(new int[] { 2, 2 }, ArrayDiffCl.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }));
			Assert.AreEqual(new int[] { 1 }, ArrayDiffCl.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 2 }));
			Assert.AreEqual(new int[] { 1, 2, 2 }, ArrayDiffCl.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { }));
			Assert.AreEqual(new int[] { }, ArrayDiffCl.ArrayDiff(new int[] { }, new int[] { 1, 2 }));
			Assert.AreEqual(new int[] { 3 }, ArrayDiffCl.ArrayDiff(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
			Assert.AreEqual(new int[] { 3 }, ArrayDiffCl.ArrayDiff2(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
			Assert.AreEqual(new int[] { 3 }, ArrayDiffCl.ArrayDiff3(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
			Assert.AreEqual(new int[] { 3 }, ArrayDiffCl.ArrayDiff4(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
		}
    }
}
