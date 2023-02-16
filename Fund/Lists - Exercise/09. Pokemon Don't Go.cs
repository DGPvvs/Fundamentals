using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
	class PokemonDon_tGo
	{
		static void ListModify(List<int> list, int currentOut)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] <= currentOut )
				{
					list[i] += currentOut;
				}
				else
				{
					list[i] -= currentOut;
				}
			}
		}// void ListModify(List<int> list, int currentOut)

		static void Main(string[] args)
		{
			List<int> list = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();

			int sum = 0;
			int currentOut = 0;

			while (list.Count > 0)
			{
				int index = int.Parse(Console.ReadLine());
				if (index < 0)
				{
					currentOut = list[0];
					list[0] = list[list.Count - 1];					
				}
				else if (index > list.Count - 1)
				{
					currentOut = list[list.Count - 1];
					list[list.Count - 1] = list[0];					
				}
				else
				{
					currentOut = list[index];
					list.RemoveAt(index);
				}

				ListModify(list, currentOut);
				sum += currentOut;

			}

			Console.WriteLine(sum);
		}
	}
}
//Ely likes to play Pokemon Go a lot. But Pokemon Go bankrupted … So the developers made Pokemon Don’t Go out of depression. And so Ely now plays Pokemon Don’t Go. In Pokemon Don’t Go, when you walk to a certain pokemon, those closer to you, naturally get further, and those further from you, get closer.
//You will receive a sequence of integers, separated by spaces – the distances to the pokemons. Then you will begin receiving integers, which will correspond to indexes in that sequence.
//When you receive an index, you must remove the element at that index from the sequence (as if you’ve captured the pokemon).
//•	You must increase the value of all elements in the sequence, which are less or equal to the removed element, with the value of the removed element.
//•	You must decrease the value of all elements in the sequence, which are greater than the removed element, with the value of the removed element.
//If the given index is less than 0, remove the first element of the sequence, and copy the last element to its place.
//If the given index is greater than the last index of the sequence, remove the last element from the sequence, and copy the first element to its place.
//The increasing and decreasing of elements should be done in these cases, also. The element, whose value you should use is the removed element.
//The program ends when the sequence has no elements (there are no pokemons left for Ely to catch).
//Input
//•	On the first line of input you will receive a sequence of integers, separated by spaces.
//•	On the next several lines you will receive integers – the indexes.
//Output
//•	When the program ends, you must print the summed value of all removed elements.
//Constrains
//•	The input data will consist only of valid integers in the range [-2.147.483.648, 2.147.483.647].

//Ели обича да играе Pokemon Go много. Но Покемон Отиди банкрутирал ...
//Така че разработчиците са направили Pokemon Don't излиза от депресия.
//И така, Ели сега играе Покемон Не отивай.
//В Pokemon Don't Go, когато вървите към определен покемон, тези, които по-близо до вас, естествено се по-далеч, и тези по-далеч от вас, се по-близо.
//Ще получите поредица от цели числа, разделени от интервали – разстоянията до pokemons.
//След това ще започнете да получавате цели числа, които ще съответстват на индексите в тази последователност.
//Когато получите индекс, трябва да премахнете елемента в този индекс от последователността (като че сте пленили pokemon).
//•         Трябва да увеличите стойността на всички елементи в последователността, които са по-малки или равни на отстранения елемент, със стойността на отстранения елемент.
//•         Трябва да намалите стойността на всички елементи в последователността, които са по-големи от премахнатия елемент, със стойността на отстранения елемент.
//Ако даденият индекс е по-малък от 0, премахнете първия елемент от последователносттаи копирайте последния елемент на мястото му.
//Ако даденият индекс е по-голям от последния индекс на последователността, премахнете последния елемент от последователността и копирайте първия елемент на мястото му.
//В тези случаи трябва да се извършва и увеличаване и намаляване на елементите . Елементът, чиято стойност трябва да използвате, е премахнатият елемент.
//Програмата завършва, когато последователността няма елементи (няма pokemons оставени за Ely да улови).
//въвеждане
//•         На първия ред на въвеждане ще получите поредица от числа, разделени с интервали.
//•         На следващите няколко реда ще получите цели числа – индексите.
//изход
//•         Когато програмата приключи, трябва да отпечатате сумата на всички премахнати елементи.
//Ограничения
//•         Входните данни ще се състоят само от валидни цели числа в диапазона [-2.147.483.648, 2.147.483.647].
