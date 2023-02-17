using System;
using System.Linq;
using System.Text;

namespace Top_Integers
{
	class TopIntegers
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Console.ReadLine());			

			int[] arr = sb.ToString().Split(' ').Select(int.Parse).ToArray();

			int index = arr.Length - 1;

			for (int i = arr.Length-2; i >= 0; i--)
			{
				if (arr[i] > arr[index])
				{
					index--;
					arr[index] = arr[i];
				}
			}

			sb.Clear();

			for (int i = index; i < arr.Length; i++)
			{
				sb.Append($"{arr[i]} ");
			}


			Console.WriteLine(sb.ToString());
		}
	}
}
//Write a program to find all the top integers in an array. A top integer is an integer which is bigger than all the elements to its right.
//	Напишете програма, за да намерите всички водещи числа в масив. Горното цяло число е цяло число, което е по-голямо от всички елементи вдясно.