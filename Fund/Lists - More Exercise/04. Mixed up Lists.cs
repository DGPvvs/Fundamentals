using System;
using System.Collections.Generic;
using System.Linq;

namespace Mixed_up_Lists
{
	class MixedupLists
	{
		static void Main(string[] args)
		{
			List<int> firstList = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
			List<int> secondList = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
			List<int> mixedList = new List<int>();

			secondList.Reverse();

			int minCount = Math.Min(firstList.Count, secondList.Count);

			for (int i = 0; i < minCount; i++)
			{
				mixedList.Add(firstList[0]);
				mixedList.Add(secondList[0]);
				firstList.RemoveAt(0);
				secondList.RemoveAt(0);
			}

			int minRange, maxRange;

			if (firstList.Count > 0)
			{
				minRange = Math.Min(firstList[0], firstList[1]);
				maxRange = Math.Max(firstList[0], firstList[1]);
			}
			else
			{
				minRange = Math.Min(secondList[0], secondList[1]);
				maxRange = Math.Max(secondList[0], secondList[1]);
			}

			mixedList.RemoveAll(n => n <= minRange);
			mixedList.RemoveAll(n => n >= maxRange);
			mixedList.Sort();

			Console.WriteLine(string.Join(' ', mixedList));
		}
	}
}
//Write a program that mixes up two lists by some rules. You will receive two lines of input, each one being a list of numbers. The rules for mixing are:
//•	Start from the beginning of the first list and from the ending of the second.
//•	Add element from the first and element from the second.
//•	At the end there will always be a list, in which there are 2 elements remaining.
//•	These elements will be the range of the elements you need to print.
//•	Loop through the result list and take only the elements that fulfill the condition.
//•	Print the elements ordered in ascending order and separated by a space.

//5.	Напишете програма, която смесва два списъка с някои правила. Ще получите два реда за въвеждане, всеки от които е списък с числа. Правилата за смесване са:
//6.  •         Започнете от началото на първия списък и от края на втория.
//7.	•         Добавяне на елемент от първия и елемент от втория.
//8.	•         В края винаги ще има списък, в който остават 2 елемента.
//9.	•         Тези елементи ще бъдат диапазонът на елементите, които трябва да отпечатате.
//10.	•         Завъртете списъка с резултати и вземете само елементите, които отговарят на условието.
//11.	•         Отпечатайте подредените елементи във възходящ ред и разделени от интервал.
