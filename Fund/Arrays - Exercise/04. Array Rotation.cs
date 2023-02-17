using System;
using System.Linq;
using System.Text;


namespace Array_Rotation
{
	class ArrayRotation
	{
		static void ArrayRottate(ref int[] arr, int step)
		{
			int temp = arr[0];
			int index = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				index -= step;

				while (index < 0)
				{
					index += arr.Length;
				}				

				int swap = temp;
				temp = arr[index];
				arr[index] = swap;
			}
		}


		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();			
			sb.Append(Console.ReadLine());			

			int step = int.Parse(Console.ReadLine());
			
			int[] arr = sb.ToString().Split(' ').Select(int.Parse).ToArray();

			step = step % arr.Length;			

			if (step < 0)
			{
				step += arr.Length;
			}

			if (step != 0)
			{
				if ((step % 2) == 0)
				{
					ArrayRottate(ref arr, step - 1);
					ArrayRottate(ref arr, 1);
				}
				else
				{
					ArrayRottate(ref arr, step);
				}
			}										
			
			Console.WriteLine(string.Join(' ', arr));
		}
	}
}
//Write a program that receives an array and number of rotations you have to perform (first element goes at the end) Print the resulting array.
//	Напишете програма, която получава масив и брой завъртания, които трябва да изпълните (първият елемент отива в края) Отпечатайте получения масив.