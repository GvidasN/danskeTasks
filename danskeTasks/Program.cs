using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace danskeTasks
{
	class Program
	{
		const int dataNumber = 9;
		static void Main(string[] args)
		{
			// neaprasytas
			int[][] array = new int[dataNumber][];
			//validSolution(array);



			// Fb
			// did not manage to make it for 400000 million properly
			Console.WriteLine(calculateSumFib(1000).ToString());
			Console.Read();
		}

		static bool validSolution(int [][] array)
		{
			for (int i = 0; i < dataNumber; i++)
			{
				for ( int z = 0; z < dataNumber; z++)
				{
					if (checkLine(array, array[i][z], i)) return false;
					if (checkBlock(array, array[i][z], i, z)) return false;
				}

			}

			return true;
		}

		static bool checkLine(int [][] array, int number, int row)
		{
			for (int i = 0; i < dataNumber; i++)
			{
				if (array[row][i] == 0) continue;
				if (array[row][i] == number) return true;				
			}

			return false;
		}

		static bool checkBlock(int[][] array, int number, int row, int column)
		{
			int rows = dataNumber;
			int columns = dataNumber;


			if (row < 8)
			{
				rows = 8;
			}
			if (row < 4)
			{
				rows = 4;
			}

			if (column < 8)
			{
				columns = 8;
			}
			if (column < 4)
			{
				columns = 4;
			}


			int[][] tempArray = new int[columns][];

			for (int i = 0; i < rows; i++)
			{
				tempArray[i] = new int[columns];
			}
			for (int i = 0; i < rows; i++)
			{
				for (int z = 0; z < columns; z++)
				{
					tempArray[i][z] = array[i][z];
				}
			}

			for ( int i = 0; i < rows; i ++)
			{
				for (int z = 0; z < columns; z++)
				{					
					if (checkLine(tempArray, tempArray[i][z], i)) return false;
				}				
			}

			return true;
		}

		static BigInteger calculateSumFib(BigInteger n)
		{
			if (n <= 0)
				return 0;

			BigInteger[] fibo = new BigInteger[(int)(n + 1)];
			fibo[0] = 0; 
			fibo[1] = 1;

			// Initialize result 
			BigInteger sum = fibo[0] + fibo[1];

			// Add remaining terms 
			for (int i = 2; i <= n; i++)
			{
				fibo[i] = fibo[i - 1] + fibo[i - 2];
				if (fibo[i] % 2 == 0) sum += fibo[i];
			}

			return sum;
		}


	}
}
