using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
	class Messaging
	{
		static int SumNumber(int item)
		{
			int result = 0;
			while (item > 0)
			{
				result += item % 10;
				item /= 10;
			}

			return result;
		}// int SumNumber(int item)

		static void Main(string[] args)
		{
			List<int> list = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
			StringBuilder source = new StringBuilder(Console.ReadLine());
			StringBuilder target = new StringBuilder();

			int index = 0;

			foreach (int item in list)
			{
				index = SumNumber(item) % source.Length;

				target.Append(source[index]);
				source.Remove(index, 1);
			}
			
			Console.WriteLine(target);
		}
	}
}
//You will be given a list of numbers and a string. For each element of the list you have to calculate the sum of its digits and take the element, corresponding to that index from the text. If the index is greater than the length of the text, start counting from the beginning (so that you always have a valid index). After you get that element from the text, you must remove the character you have taken from it (so for the next index, the text will be with one character less).
//	Ще ви бъде даден списък с номера и низ. За всеки елемент от списъка трябва да изчислите сумата от неговите цифри и да вземете елемента, съответстващ на този индекс от текста.
//	Ако индексът е по-голям от дължината на текста, започнете да броите от самото начало (така че винаги да имате валиден индекс).
//	След като получите този елемент от текста, трябва да премахнете знака, който сте взели от него (така че за следващия индекс текстът ще бъде с един знак по-малко).