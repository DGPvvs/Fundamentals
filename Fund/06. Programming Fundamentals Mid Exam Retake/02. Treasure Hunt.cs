using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
	class TreasureHunt
	{
		static void Main(string[] args)
		{
			List<string> treasureChest = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

			bool isLoopExit = false;

			while (!isLoopExit)
			{
				string input = Console.ReadLine();
				if (input.ToLower().Equals("yohoho!"))
				{
					isLoopExit = true;
				}
				else
				{
					string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string command = commands[0];

					switch (command.ToLower())
					{
						case "loot":
							for (int i = 1; i < commands.Length; i++)
							{
								if (!treasureChest.Contains(commands[i]))
								{
									treasureChest.Insert(0, commands[i]);
								}
							}
							break;
						case "drop":
							int index = int.Parse(commands[1]);
							if ((index >= 0) && (index <= treasureChest.Count - 1))
							{
								treasureChest.Add(treasureChest[index]);
								treasureChest.RemoveAt(index);
							}							
							break;
						case "steal":
							int count = int.Parse(commands[1]);
							if (count >= treasureChest.Count)
							{
								Console.WriteLine(string.Join(", ", treasureChest));
								treasureChest.Clear();
							}
							else
							{
								string[] steals = new string[count];
								for (int i = 0; i < count; i++)
								{
									steals[i] = treasureChest[treasureChest.Count - 1];
									treasureChest.RemoveAt(treasureChest.Count - 1);
								}
								steals = steals.Reverse().ToArray();
								Console.WriteLine(string.Join(", ", steals));
							}
							break;
						default:
							break;
					}
				}
			}

			if (treasureChest.Count > 0)
			{
				int sum = 0;
				foreach (string item in treasureChest)
				{
					sum += item.Length;
				}

				double averageGain = 1.0 * sum / treasureChest.Count;  

				Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
			}
			else
			{
				Console.WriteLine("Failed treasure hunt.");
			}			
		}
	}
}
//The pirates need to carry a treasure chest safely back to the ship. Looting along the way.
//Create a program that manages the state of the treasure chest along the way. On the first line you will receive the initial loot of the treasure chest, which is a string of items separated by a '|'.
//"{loot1}|{loot2}|{loot3}… {lootn}"
//The following lines represent commands until "Yohoho!" which ends the treasure hunt:
//•	Loot
//{ item1}
//{ item2}…{ itemn} – pick up treasure loot along the way. Insert the items at the beginning of the chest. If an item is already contained don't insert it.
//•	Drop {index} – remove the loot at the given position and add it at the end of the treasure chest. If the index is invalid skip the command.
//•	Steal {count} – someone steals the last count loot items. If there are less items than the given count remove as much as there are. Print the stolen items separated by ', ':
//{ item1}, { item2}, { item3} … { itemcount}
//In the end output the average treasure gain which is the sum of all treasure items length divided by the count of all items inside the chest formatted to the second decimal point:
//"Average treasure gain: {averageGain} pirate credits."
//If the chest is empty print the following message:
//"Failed treasure hunt."
//Input
//•	On the 1st line you are going to receive the initial treasure chest (loot separated by '|')
//•	On the next lines, until "Yohoho!", you will be receiving commands.
//Output
//•	Print the output in the format described above.
//Constraints
//•	The loot items will be strings containing any ASCII code.
//•	The indexes will be integers in the range [-200…200]
//•	The count will be an integer in the range [1….100]
//Пиратите трябва да носят съкровищница безопасно обратно на кораба. Плячкосване по пътя.
//Създайте програма, която управлява състоянието на съкровищницата по пътя.
//На първия ред ще получите първоначалната плячка на съкровищния гръден кош, който е низ от елементи, разделени с '|'.
//"{плячка1}| {плячка2}| {плячка3}... {плячкаn}"
//Следващите редове представляват команди до "Йохохо!" който приключва лова на съкровища:
//•         Плячкоснете
//{ елемент1}
//{ елемент2}
//... { елементn} – вземете съкровище плячка по пътя. Поставете елементите в началото на гръдния кош. Ако даден елемент вече се съдържа, не го вмъквайте.
//•         Пуснете {index} – извадете плячката в дадената позиция и я добавете в края на съкровищния гръден кош. Ако индексът е невалиден пропуснете командата.
//•         Откраднете {count} – някой краде последните брой плячка елементи. Ако има по-малко елементи от дадения брой премахнете толкова, колкото има.
//Отпечатване на откраднатите предмети, разделени с', ':
//{ точка1}, { артикул2}, { артикул3}
//... { брой елементи}
//В крайната продукция средната печалба от съкровища, която е сумата от всички съкровищни елементи дължина,
//разделена на броя на всички предмети вътре в гърдите форматирани до втория десетичен знак:
//"Средна печалба от съкровища: {средноGain} пиратски кредити."
//Ако гръдният кош е празен печат на следното съобщение:
//"Провален лов на съкровища."
//Въвеждане
//•         На 1 - вата линия ще получите първоначалното съкровищно сандъче (плячка, разделена от '|')
//•         На следващите линии, докато "Йохохо! ", ще получавате команди.
//Изход
//•         Отпечатване на изхода във формат, описан по-горе.
//Ограничения
//•         Елементите на плячката ще бъдат низове, съдържащи всеки ASCII код.
//•         Индексите ще бъдат цяло число в диапазона [-200... 200 г.]
//•         Броят ще бъде цяло число в диапазона [1....100]
