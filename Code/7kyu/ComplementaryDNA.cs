using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars._7kyu
{
	//Deoxyribonucleic acid(DNA) is a chemical found in the nucleus of cells and carries 
	//the "instructions" for the development and functioning of living organisms.

	//If you want to know more: http://en.wikipedia.org/wiki/DNA

	//In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". 
	//Your function receives one side of the DNA(string, except for Haskell); you need 
	//to return the other complementary side.DNA strand is never empty or there is no 
	//DNA at all (again, except for Haskell).

	//More similar exercise are found here: http://rosalind.info/problems/list-view/ (source)

	//Example: (input --> output)

	//"ATTGC" --> "TAACG"
	//"GTAT" --> "CATA"

	internal class ComplementaryDNA
	{
		private static Dictionary<char, char> map = new Dictionary<char, char>
			{
				{'T', 'A'},
				{'A', 'T'},
				{'C', 'G'},
				{'G', 'C'}
			};

		public static string MakeComplement(string dna)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < dna.Length; i++)
			{
				switch (dna[i])
				{
					case 'A':
						sb.Append("T");
						break;
					case 'T':
						sb.Append("A");
						break;
					case 'C':
						sb.Append("G");
						break;
					case 'G':
						sb.Append("C");
						break;
				}
			}
			return sb.ToString();
		}

		public static string MakeComplement2(string dna)
		{
			return string.Concat(dna.Select(GetComplement));
		}

		public static char GetComplement(char symbol)
		{
			switch (symbol)
			{
				case 'A':
					return 'T';
				case 'T':
					return 'A';
				case 'C':
					return 'G';
				case 'G':
					return 'C';
				default:
					throw new ArgumentException();
			}
		}

		public static string MakeComplement3(string dna)
		{
			var mychars = dna.ToCharArray();

			var outChars = new String(mychars.Select(x => map[x]).ToArray());

			return outChars;
		}
	}

	[TestFixture]
	public class DnaStrandTest
	{
		[TestCase("AAAA", "TTTT")]
		[TestCase("ATTGC", "TAACG")]
		[TestCase("GTAT", "CATA")]
		[TestCase("AAGG", "TTCC")]
		[TestCase("CGCG", "GCGC")]
		[TestCase("ATTGC", "TAACG")]
		[TestCase("GTATCGATCGATCGATCGATTATATTTTCGACGAGATTTAAATATATATATATACGAGAGAATACAGATAGACAGATTA", "CATAGCTAGCTAGCTAGCTAATATAAAAGCTGCTCTAAATTTATATATATATATGCTCTCTTATGTCTATCTGTCTAAT")]
		public void SampleTests(string dna, string expected)
		{
			Assert.AreEqual(expected, ComplementaryDNA.MakeComplement(dna));
		}

		[TestCase("AAAA", "TTTT")]
		[TestCase("ATTGC", "TAACG")]
		[TestCase("GTAT", "CATA")]
		[TestCase("AAGG", "TTCC")]
		[TestCase("CGCG", "GCGC")]
		[TestCase("ATTGC", "TAACG")]
		[TestCase("GTATCGATCGATCGATCGATTATATTTTCGACGAGATTTAAATATATATATATACGAGAGAATACAGATAGACAGATTA", "CATAGCTAGCTAGCTAGCTAATATAAAAGCTGCTCTAAATTTATATATATATATGCTCTCTTATGTCTATCTGTCTAAT")]
		public void SampleTests2(string dna, string expected)
		{
			Assert.AreEqual(expected, ComplementaryDNA.MakeComplement2(dna));
		}

		[TestCase("AAAA", "TTTT")]
		[TestCase("ATTGC", "TAACG")]
		[TestCase("GTAT", "CATA")]
		[TestCase("AAGG", "TTCC")]
		[TestCase("CGCG", "GCGC")]
		[TestCase("ATTGC", "TAACG")]
		[TestCase("GTATCGATCGATCGATCGATTATATTTTCGACGAGATTTAAATATATATATATACGAGAGAATACAGATAGACAGATTA", "CATAGCTAGCTAGCTAGCTAATATAAAAGCTGCTCTAAATTTATATATATATATGCTCTCTTATGTCTATCTGTCTAAT")]
		public void SampleTests3(string dna, string expected)
		{
			Assert.AreEqual(expected, ComplementaryDNA.MakeComplement3(dna));
		}
	}
}
