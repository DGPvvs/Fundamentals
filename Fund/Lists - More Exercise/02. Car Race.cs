using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Race
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> list = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
			int midIndex = (list.Count / 2);
			double firstSpeed = 0;
			double secondSpeed = 0;

			for (int i = 0; i < midIndex; i++)
			{
				firstSpeed += list[i];
				secondSpeed += list[list.Count - 1 - i];
				if (list[i] == 0)
				{
					firstSpeed *= .8;
				}
				if (list[list.Count - 1 - i] == 0)
				{
					secondSpeed *= .8;
				}
			}
			if (firstSpeed <= secondSpeed)
			{
				Console.WriteLine($"The winner is left with total time: {firstSpeed}");
			}
			else
			{
				Console.WriteLine($"The winner is right with total time: {secondSpeed}");
			}
			
		}
	}
}
//Write a program to calculate the winner of a car race. You will receive an array of numbers. Each element of the array represents the time needed to pass through that step (the index). There are going to be two cars. One of them starts from the left side and the other one starts from the right side. The middle index of the array is the finish line. The number of elements in the array will always be odd. Calculate the total time for each racer to reach the finish, which is the middle of the array, and print the winner with his total time (the racer with less time). If you have a zero in the array, you have to reduce the time of the racer that reached it by 20% (from his current time).
//Print the result in the following format "The winner is {left/right} with total time: {total time}".
//Напишете програма за изчисляване на победителя в състезанието за коли.
//Ще получите масив от числа. Всеки елемент от масива представлява времето, необходимо за преминаване през тази стъпка (индекса).
//Ще има две коли. Едната започва от лявата страна , а другата започва от дясната страна.
//Средният индекс на масива е финалната линия. Броят на елементите в масива винаги ще бъде нечетен.
//Изчислете общото време за всеки състезател, за да достигне финала, който е средата на масива, и отпечатайте победителя с общото си време (състезателя с по-малко време).
//Ако имате нула в масива, трябва да намалите времето на състезателя, достигнал до него с 20 % (от неговото време )).
//Отпечатайте резултата в следния формат "Победителят е {ляво/дясно} с общото време: {общо време}".
