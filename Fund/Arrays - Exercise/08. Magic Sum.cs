using System;
using System.Linq;
using System.Text;

namespace Magic_Sum
{
	class MagicSum
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();

			int[] arr = sb.Append(Console.ReadLine()).ToString().Split(' ').Select(int.Parse).ToArray();

			int magicNum = int.Parse(Console.ReadLine());

			for (int i = 0; i < arr.Length-1; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					if ((arr[i] + arr[j]) == magicNum)
					{
						Console.WriteLine($"{arr[i]} {arr[j]}");
					}
				}
			}

			
		}
	}
}
//Write a program, which prints all unique pairs in an array of integers whose sum is equal to a given number. 
//	Напишете програма, която отпечатва всички уникални двойки в масив от цели числа, чиято сума е равна на дадено число.