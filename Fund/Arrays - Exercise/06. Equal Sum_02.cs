using System;
using System.Linq;
using System.Text;

namespace Equal_Sum
{
	class EqualSum
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			
			int[] arr = sb.Append(Console.ReadLine()).ToString().Split(' ').Select(int.Parse).ToArray();

			bool isEqual = false;
			int i = 0;
			int index = 0;

			while ((i <= arr.Length - 1) && (!isEqual))
			{
				int sumL = 0;
				int sumR = 0;

				for (int j = 0; j <= i - 1; j++)
				{
					if (i > 0)
					{
						sumL += arr[j];
					}
				}

				for (int j = i + 1; j <= arr.Length - 1; j++)
				{
					if (i < arr.Length - 1)
					{
						sumR += arr[j];
					}
				}

				if(sumL == sumR)
				{
					index = i;
					isEqual = true;
				}

				i++;
			}

			if (isEqual)
			{
				Console.WriteLine(index);
			}
			else
			{
				Console.WriteLine("no");
			}
			
		}
	}
}
//Write a program that determines if there exists an element in the array such that the sum of the elements on its left is equal to the sum of the elements on its right (there will never be more than 1 element like that). If there are no elements to the left / right, their sum is considered to be 0. Print the index that satisfies the required condition or "no" if there is no such index.
//	Напишете програма, която определя дали съществува елемент в масива, така че сумата от елементите отляво да е равна на сумата от елементите от дясно (никога няма да има повече от 1 елемент като този). Ако няма елементи от ляво / дясно, сумата им се счита за 0. Отпечатайте индекса, който отговаря на необходимото условие или "не", ако няма такъв индекс.