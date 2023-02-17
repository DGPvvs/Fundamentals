using System;
using System.Linq;
using System.Text;

namespace Zig_Zag_Arrays
{
	class Zig_ZagArrays
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			StringBuilder sb = new StringBuilder();

			int[] arr1 = new int[n];
			int[] arr2 = new int[n];
			
			for (int i = 0; i < n; i++)
			{
				sb.Clear();
				sb.Append(Console.ReadLine());
				int[] arr = sb.ToString().Split(' ').Select(int.Parse).ToArray();

				if ((i % 2) == 0)
				{
					arr1[i] = arr[0];
					arr2[i] = arr[1];
				}
				else
				{
					arr2[i] = arr[0];
					arr1[i] = arr[1];
				}
				
			}

			Console.WriteLine($"{string.Join(' ', arr1)}\n{string.Join(' ', arr2)}");
		}
	}
}
//Write a program which creates 2 arrays. You will be given an integer n. On the next n lines you get 2 integers. Form 2 arrays as shown below.
//Напишете програма, която създава 2 масива. Ще ви бъде дадено цяло число. На следващите n линии получавате 2 цели числа. Форма 2 масиви, както е показано по-долу.