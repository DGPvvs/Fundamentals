using System;
using System.Linq;
using System.Text;

namespace Common_Elements
{
	class CommonElements
	{
		static void Main(string[] args)
		{
			string[] arr1 = Console.ReadLine().Split(' ').ToArray();
			string[] arr2 = Console.ReadLine().Split(' ').ToArray();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < arr2.Length; i++)
			{
				for (int j = 0; j < arr1.Length; j++)
				{
					if (arr2[i] == arr1[j])
					{
						sb.Append(arr1[j]);
						sb.Append(" ");
					} 
				}
			}


			Console.WriteLine(sb.ToString());
		}
	}
}
//Write a program, which prints common elements in two arrays. You have to compare the elements of the second array to the elements of the first.
//	Напишете програма, която отпечатва общи елементи в два масива. Трябва да сравните елементите на втория масив с елементите на първия.