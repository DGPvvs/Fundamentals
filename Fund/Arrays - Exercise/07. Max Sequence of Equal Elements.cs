using System;
using System.Linq;
using System.Text;

namespace Max_Sequence_of_Equal_Elements
{
	class MaxSequenceofEqualElements
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();

			int[] arr = sb.Append(Console.ReadLine()).ToString().Split(' ').Select(int.Parse).ToArray();

			int counter = 0;
			int currentCounter = 1;
			int index = 0;
			int currentIndex = 0;
			int num = arr[0];

			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] == num)
				{
					currentCounter++;
				}
				else if (currentCounter > counter)
				{
					index = currentIndex;
					counter = currentCounter;
					currentCounter = 1;
					num = arr[i];
					currentIndex = i;
				} 	
				else
				{
					currentCounter = 1;
					num = arr[i];
					currentIndex = i;
				}
			}

			if (currentCounter > counter)
			{
				index = currentIndex;
				counter = currentCounter;
			}

			for (int i = index; i <= index + counter - 1; i++)
			{
				Console.Write($"{arr[i]} ");
			}
			
		}
	}
}
//Write a program that finds the longest sequence of equal elements in an array of integers. If several longest sequences exist, print the leftmost one.
//	Напишете програма, която намира най-дългата последователност от еднакви елементи в масив от цели числа. Ако има няколко най-дълги последователности, отпечатайте най-лявата.