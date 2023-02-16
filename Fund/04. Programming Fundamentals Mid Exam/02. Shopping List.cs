using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_List
{
	class ShoppingList
	{
		static void Main(string[] args)
		{
			List<string> shoppingList = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

			StringBuilder sb = new StringBuilder();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("go shopping!"))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string command = input[0];
					string firstArgument = input[1];

					switch (command.ToLower())
					{
						case "urgent":
							if (!shoppingList.Contains(firstArgument))
							{
								shoppingList.Insert(0, firstArgument);
							}
							break;
						case "unnecessary":
							shoppingList.Remove(firstArgument);
							break;
						case "rearrange":
							if (shoppingList.Remove(firstArgument))
							{
								shoppingList.Add(firstArgument);
							}
							break;
						case "correct":
							string secondArgument = input[2];
							int index = shoppingList.FindIndex(i => i == firstArgument);
							if (index > -1)
							{
								shoppingList[index] = secondArgument;
							}
							break;
						default:
							break;
					}
				}
			}// while (!isExitLoop)

			Console.WriteLine(string.Join(", ", shoppingList));
		}
	}
}
//It’s the end of the week and it is time for you to go shopping, so you need to create a shopping list first.
//Input
//You will receive an initial list with groceries separated by "!".
//After that you will be receiving 4 types of commands, until you receive "Go Shopping!"
//•	Urgent {item} -add the item at the start of the list.  If the item already exists, skip this command.
//•	Unnecessary {item} -remove the item with the given name, only if it exists in the list. Otherwise skip this command.
//•	Correct {oldItem} { newItem} – if the item with the given old name exists, change its name with the new one.If it doesn 't exist, skip this command.
//•	Rearrange
//{ item}
//- if the grocery exists in the list, remove it from its current position and add it at the end of the list.
//Constraints
//•	There won`t be any duplicate items in the initial list
//Output
//Print the list with all the groceries, joined by ", ".
//•	"{firstGrocery}, {secondGrocery}, …{nthGrocery}"
//Това е краят на седмицата и е време да пазарувате, така че трябва да създадете списък за пазаруване първо.
//Въвеждане
//Ще получите първоначален списък с хранителни продукти, "!".
//След това ще получавате 4 вида команди, докато не получите "Пазаруване!"
//•         Спешни {елемент} -добавяне на елемент в началото на списъка. Ако елементът вече съществува, пропуснете тази команда.
//•         Ненужен {item} -премахване на елемент с дадено име, само ако той съществува в списъка. В противен случай пропуснете тази команда.
//•         Коригиране на {oldItem} { newItem} – ако елементът с даденото старо име съществува, променете името си с новия. Ако не съществува, пропуснете тази команда.
//•         Пренареждане {item} -ако има в списъка, премахнете го от текущата му позиция и го добавете в края на списъка.
//Ограничения
//•         Няма да има дублиращи се елементи в първоначалния списък
//Изход
//Отпечатайте списъка с всички хранителни стоки, ", ".
//•         {първозакотности}, { второзаконие}, ... {
//	nth: y)"
