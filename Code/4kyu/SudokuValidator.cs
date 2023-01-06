using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars._4kyu
{
	//Sudoku Background
	//Sudoku is a game played on a 9x9 grid.The goal of the game is to fill all cells of 
	//	the grid with digits from 1 to 9, so that each column, each row, and each 
	//	of the nine 3x3 sub-grids (also known as blocks) contain all of the digits from 1 to 9.
	//(More info at: http://en.wikipedia.org/wiki/Sudoku)

	//Sudoku Solution Validator
	//Write a function validSolution/ValidateSolution/valid_solution() that accepts a 2D array representing 
	//	a Sudoku board, and returns true if it is a valid solution, or false otherwise.The cells 
	//	of the sudoku board may also contain 0's, which will represent empty cells. 
	//Boards containing one or more zeroes are considered to be invalid solutions.

	//The board is always 9 cells by 9 cells, and every cell only contains integers from 0 to 9.

	internal class SudokuValidator
	{
		public static bool ValidateSolution(int[][] board)
		{
			for (short i = 0; i < 9; i++)
			{
				int sum = 0;
				for (short j = 0; j < 9; j++)
				{
					sum += board[j][i];
				}
				if (sum != 45)
				{
					return false;
				}
			}

			for (int i = 0; i < 9; i++)
			{
				if (board[i].Sum(x => x) != 45)
				{
					return false;
				}
			}

			List<(int, int)> num = new List<(int, int)>
			{
				new (1,1),
				new (1,4),
				new (1,7),
				new (4,1),
				new (4,4),
				new (4,7),
				new (7,1),
				new (7,4),
				new (7,7)
			};

			foreach (var item in num)
			{
				if (Summa(item, board) != 45)
				{
					return false;
				}
			}

			return true;
		}

		public static int Summa((int, int) number, int[][] board)
		{
			var s =
				board[number.Item1][number.Item2] +
				board[number.Item1 + 1][number.Item2] +
				board[number.Item1][number.Item2 + 1] +
				board[number.Item1 - 1][number.Item2] +
				board[number.Item1][number.Item2 - 1] +
				board[number.Item1 + 1][number.Item2 + 1] +
				board[number.Item1 - 1][number.Item2 - 1] +
				board[number.Item1 + 1][number.Item2 - 1] +
				board[number.Item1 - 1][number.Item2 + 1];
			return s;
		}

		public static bool ValidateSolution2(int[][] board)
		{
			return Enumerable
			.Range(0, 9)
			.SelectMany(i => new[]
				{
				board[i].Sum(),
				board.Sum(b => b[i]),
				board.Skip(3 * (i / 3)).Take(3).SelectMany(r => r.Skip(3 * (i % 3)).Take(3)).Sum()
				})
			.All(i => i == 45);
		}

		public static bool ValidateSolution3(int[][] board) => Enumerable
		.Range(0, 9)
		.All(n => Enumerable
		.Range(3 * (n / 3), 3)    //3*3 matrix
		.SelectMany(i => board[i].Skip(3 * (n % 3)).Take(3))
		.Sum(x => x < 1 || x > 9 ? 0 : x) == 45);
	}

	[TestFixture]
	public class Sample_Tests
	{
		private static object[] testCases = new object[]
		{
		  new object[]
		  {
			true,
			new int[][]
			{
			  new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
			  new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
			  new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
			  new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
			  new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
			  new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
			  new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
			  new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
			  new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
			},
		  },

		  new object[]
		  {
			false,
			new int[][]
			{
			  new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
			  new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
			  new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
			  new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
			  new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
			  new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
			  new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
			  new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
			  new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
			},
		  },

		  new object[]
		  {
			false,
			new int[][]
			{
			  new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9},
			  new int[] {2, 3, 1, 5, 6, 4, 8, 9, 7},
			  new int[] {3, 1, 2, 6, 4, 5, 9, 7, 8},
			  new int[] {4, 5, 6, 7, 8, 9, 1, 2, 3},
			  new int[] {5, 6, 4, 8, 9, 7, 2, 3, 1},
			  new int[] {6, 4, 5, 9, 7, 8, 3, 1, 2},
			  new int[] {7, 8, 9, 1, 2, 3, 4, 5, 6},
			  new int[] {8, 9, 7, 2, 3, 1, 5, 6, 4},
			  new int[] {9, 7, 8, 3, 1, 2, 6, 4, 5},
			},
		  }
		};

		[Test, TestCaseSource("testCases")]
		public void Test(bool expected, int[][] board) => Assert.AreEqual(expected, SudokuValidator.ValidateSolution(board));
		[Test, TestCaseSource("testCases")]
		public void Test2(bool expected, int[][] board) => Assert.AreEqual(expected, SudokuValidator.ValidateSolution2(board));
		[Test, TestCaseSource("testCases")]
		public void Test3(bool expected, int[][] board) => Assert.AreEqual(expected, SudokuValidator.ValidateSolution3(board));
	}
}
