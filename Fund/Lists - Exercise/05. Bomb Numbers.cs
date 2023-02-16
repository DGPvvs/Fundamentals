using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
	class BombNumbers
	{
		static void Main(string[] args)
		{
			List<int> list = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();

			List<string> command = Console.ReadLine()
				.Split(' ', '{', '}')
				.ToList();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				int bombIndex = list.FindIndex(n => n == int.Parse(command[0]));
				if (bombIndex == -1)
				{
					isExitLoop = true;
				}
				else
				{
					int startIndex = bombIndex - int.Parse(command[1]);
					if (startIndex < 0)
					{
						startIndex = 0;
					} 

					int endIndex = bombIndex + int.Parse(command[1]);
					if (endIndex > list.Count - 1)
					{
						endIndex = list.Count - 1;
					}

					for (int i = endIndex; i >= startIndex; i--)
					{
						list.RemoveAt(i);
					}
				}
			}

			Console.WriteLine(list.Sum());
		}
	}
}
//Write a program that reads a sequence of numbers and a special bomb number with a certain power. Your task is to detonate every occurrence of the special bomb number and according to its power - his neighbors from left and right. Detonations are performed from left to right and all detonated numbers disappear. Finally print the sum of the remaining elements in the sequence.
//	Напишете програма , която чете последователност от номера и специален номер на бомба с определена сила. Вашата задача е да взривите всяко прощяние на специалния номер на бомбата и според силата му - неговите съседи от ляво и дясно. Детоациите се извършват от ляво на дясно и всички взривени числа изчезват. Накрая отпечатайте сумата на останалите елементи в последователността.