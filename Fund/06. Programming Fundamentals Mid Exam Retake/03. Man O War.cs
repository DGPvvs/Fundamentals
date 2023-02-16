using System;
using System.Linq;

namespace Man_O_War
{
	class ManOWar
	{
		static bool ValidIndex(int length, int index)
		{
			bool result = false;
			if ((index >= 0) && (index <= length))
			{
				result = true;
			}
			return result;
		}// bool ValidIndex(int length, int index)

		static void Main(string[] args)
		{
			int[] statusPirateShip = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int[] statusManOWar = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int maxHealthCapacity = int.Parse(Console.ReadLine());

			bool isLoopExit = false;
			bool isPirateSink = false;
			bool isManOWarSink = false;

			while ((!isLoopExit) && (!isPirateSink) && (!isManOWarSink))
			{
				string input = Console.ReadLine();

				if (input.ToLower().Equals("retire"))
				{
					isLoopExit = true;
				}
				else
				{
					string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

					string command = commands[0];

					switch (command.ToLower())
					{
						case "fire":
							int index = int.Parse(commands[1]);
							int damage = int.Parse(commands[2]);

							if (ValidIndex(statusManOWar.Length - 1, index))
							{
								statusManOWar[index] -= damage;

								if (statusManOWar[index] <= 0)
								{
									Console.WriteLine("You won! The enemy ship has sunken.");
									isManOWarSink = true;
								}
							}							
							break;
						case "defend":
							int startIndex = int.Parse(commands[1]);
							int endIndex = int.Parse(commands[2]);
							damage = int.Parse(commands[3]);
							bool isValidIndex = ((ValidIndex(statusPirateShip.Length - 1, startIndex)) && (ValidIndex(statusPirateShip.Length - 1, endIndex)));
							if (isValidIndex)
							{
								int i = startIndex;
								while ((i <= endIndex) && (!isPirateSink))
								{
									statusPirateShip[i] -= damage;

									if (statusPirateShip[i] <= 0)
									{
										Console.WriteLine("You lost! The pirate ship has sunken.");
										isPirateSink = true;
									}
									i++;
								}								
							}
							break;
						case "repair":
							index = int.Parse(commands[1]);
							int health = int.Parse(commands[2]);

							if (ValidIndex(statusPirateShip.Length - 1, index))
							{
								statusPirateShip[index] += health;

								if (statusPirateShip[index] > maxHealthCapacity)
								{
									statusPirateShip[index] = maxHealthCapacity;
								}
							}
							break;
						case "status":
							int count = 0;
							double twentyPercentOfMaxHealthCapacity = maxHealthCapacity * .2;

							foreach (int item in statusPirateShip)
							{
								if (item < twentyPercentOfMaxHealthCapacity)
								{
									count++;
								}
							}
							Console.WriteLine($"{count} sections need repair.");
							break;
						default:
							break;
					}
				}
			}

			if ((!isPirateSink) && (!isManOWarSink))
			{
				int sum = 0;

				foreach (int item in statusPirateShip)
				{
					sum += item;
				}

				Console.WriteLine($"Pirate ship status: {sum}");

				sum = 0;

				foreach (int item in statusManOWar)
				{
					sum += item;
				}

				Console.WriteLine($"Warship status: {sum}");
			}			
		}
	}
}
//The pirates encounter a huge Man-O-War at sea. 
//Create a program that tracks the battle and either chooses a winner or prints a stalemate.
//On the first line you will receive the status of the pirate ship, which is a string representing integer sections separated by '>'. On the second line you will receive the same type of status, but for the warship: 
//"{section1}>{section2}>{section3}… {sectionn}"
//On the third line you will receive the maximum health capacity a section of the ship can reach. 
//The following lines represent commands until "Retire":
//•	Fire
//{ index}
//{ damage} – the pirate ship attacks the warship with the given damage at that section. Check if the index is valid and if not skip the command.
//If the section breaks (health <= 0) the warship sinks, print the following and stop the program:
//"You won! The enemy ship has sunken."
//•	Defend
//{ startIndex}
//{ endIndex}
//{ damage}
//-the warship attacks the pirate ship with the given damage at that range (indexes are inclusive).
//Check if both indexes are valid and if not skip the command. If the section breaks (health <= 0) the pirate ship sinks, print the following and stop the program:
//"You lost! The pirate ship has sunken."
//•	Repair
//{ index}
//{ health}
//-the crew repairs a section of the pirate ship with the given health. Check if the index is valid and if not skip the command.
//The health of the section cannot exceed the maximum health capacity.
//•	Status – prints the count of all sections of the pirate ship that need repair soon, which are all sections that are lower than 20% of the maximum health capacity.
//Print the following:
//"{count} sections need repair."
//In the end if a stalemate occurs print the status of both ships, which is the sum of their individual sections in the following format:
//"Pirate ship status: {pirateShipSum}"
//"Warship status: {warshipSum}"
//Input
//•	On the 1st line you are going to receive the status of the pirate ship (integers separated by '>')
//•	On the 2nd line you are going to receive the status of the warship
//•	On the 3rd line you are going receive the maximum health a section of a ship can reach.
//•	On the next lines, until "Retire", you will be receiving commands.
//Output
//•	Print the output in the format described above.
//Constraints
//•	The section numbers will be integers in the range [1….1000]
//•	The indexes will be integers [-200….200]
//•	The damage will be an integer in the range [1….1000]
//•	The health will be an integer in the range [1….1000]
//Пиратите срещат огромна Ман-О-Война в морето.
//Създайте програма, която проследява битката и или избира победител, или отпечатва застой.
//На първия ред ще получите статуса на пиратския кораб, който е низ, представляващ цяло число секции, разделени с '>'.
//На втората линия ще получите същия вид статут, но за военния кораб:
//"{раздел1}>{раздел2}>{раздел3}... {разделn}"
//На третата линия ще получите максималния здравен капацитет, до който може да достигне участък от кораба.
//Следните редове представляват команди до "Пенсиониране":
//•         Пожар
//{ index}
//{ damage} – пиратския кораб атакува военния кораб с дадените щети в този участък.
//Проверете дали индексът е валиден и ако не пропуснете командата. Ако разделът прекъсне (здраве <= 0) военният кораб потъва, отпечатайте следното и спрете програмата:
//"Спечели! Вражеският кораб потъна."
//•         Защитавайте
//{ startIndex}
//{ endIndex}
//{ damage}
//-военният кораб атакува пиратския кораб с дадените щети в този диапазон (индексите са включително). Проверете дали и двата индекса са валидни и ако не пропуснете командата.
//Ако разделът прекъсне (здраве <= 0) пиратския кораб потъва, отпечатайте следното и спрете програмата:
//"Загуби! Пиратския кораб потъна."
//•         Ремонт
//{ index}
//{ health}
//-екипажът поправя участък от пиратския кораб с даденото здраве. Проверете дали индексът е валиден и ако не пропуснете командата.
//Здравето на раздела не може да надвишава максималния здравен капацитет.
//•         Статус – отпечатва броя на всички участъци от пиратския кораб, които се нуждаят от ремонт скоро, които са всички секции,
//които са по-ниски от 20% от максималния здравен капацитет. Отпечатайте следното:
//"{брой} секции се нуждаят от ремонт."
//В крайна сметка, ако възникне застой, отпечатайте състоянието на двата кораба, което е сумата от отделните им секции в следния формат:
//"Статут на пиратски кораб: {пиратски корабSum}"
//"Статут на военен кораб: {военен корабSum}"
//Въвеждане
//•         На 1 - вата линия ще получите статуса на пиратския кораб ( цялочисло, отделено от '>')
//•         На 2 - ра линия ще получите статут на военния кораб
//•         На 3-тата линия, до която отивате, получавате максималното здраве, до което може да достигне участък от кораб.
//•         На следващите редове, до "Пенсиониране", ще получавате команди.
//Изход
//•         Отпечатване на изхода във формат, описан по-горе.
//Ограничения
//•         Номерата на секциите ще бъдат цяло число в диапазона [1....1000]
//•         Индексите ще бъдат цяло число [-200....200]
//•         Щетите ще бъдат цяло число в диапазона [1....1000]
//•         Здравето ще бъде цяло число в диапазона [1....1000]
