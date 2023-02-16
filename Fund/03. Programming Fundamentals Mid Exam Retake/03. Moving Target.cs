using System;
using System.Collections.Generic;
using System.Linq;

namespace Moving_Target
{
	class MovingTarget
	{
		static bool IsRangeValid(List<int> targets, int startRangr, int endRange)
		{
			bool result = false;

			if ((startRangr >= 0) && (endRange < targets.Count))
			{
				result = true;
			}

			return result;

		}// bool IsRangevalid(List<int> targets, int startRangr, int endRange)

		static void Main(string[] args)
		{
			List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
			targets.RemoveAll(n => n <= 0);

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				string input = Console.ReadLine();
				if (input.ToLower().Equals("end"))
				{
					isExitLoop = true;
				}
				else
				{
					string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string command = commands[0];
					int index = int.Parse(commands[1]);
					switch (command.ToLower())
					{
						case "shoot":							
							int power = int.Parse(commands[2]);
							if (IsRangeValid(targets, index, index))
							{
								targets[index] -= power;
								if (targets[index] <= 0)
								{
									targets.RemoveAt(index);
								} 
							}
							break;
						case "add":							
							int value = int.Parse(commands[2]);
							if (IsRangeValid(targets, index, index))
							{
								targets.Insert(index, value);
							}
							else
							{
								Console.WriteLine("Invalid placement!");
							}
							break;
						case "strike":
							int radius = int.Parse(commands[2]);
							if (IsRangeValid(targets, index - radius, index + radius))
							{
								targets.RemoveRange(index - radius, 2 * radius + 1);
							}
							else
							{
								Console.WriteLine("Strike missed!");
							}
							break;
						default:
							break;
					}
				}
			}
			if (targets.Count > 0)
			{
				Console.WriteLine(string.Join("|", targets));
			}	
			
		}
	}
}
//You are at the shooting gallery again and you need a program that helps you keep track of moving targets. On the first line, you will receive a sequence of targets with their integer values, split by a single space. Then, you will start receiving commands for manipulating the targets, until the "End" command. The commands are the following:
//•	Shoot
//{ index}
//{ power}
//o Shoot the target at the index, if it exists by reducing its value by the given power (integer value).A target is considered shot when its value reaches 0.
//o	Remove the target, if it is shot.
//•	Add {index} { value}
//o Insert a target with the received value at the received index, if it exist. If not, print: "Invalid placement!"
//•	Strike
//{ index}
//{ radius}
//o Remove the target at the given index and the ones before and after it depending on the radius, if such exist. If any of the indices in the range is invalid print:
//"Strike missed!" and skip this command.
// Example:  Strike 2 2
//	{ radius} { radius} { strikeIndex} { radius} { radius}		

//•	End
//o	Print the sequence with targets in the following format:
//{ target1}|{ target2}…|{ targetn}
//Input / Constraints
//•	On the first line you will receive the sequence of targets – integer values [1-10000].
//•	On the next lines, until the "End" will be receiving the command described above – strings.
//•	There will never be a case when "Strike" command would empty the whole sequence.
//Output
//•	Print the appropriate message in case of "Strike" command if necessary.
//•	In the end, print the sequence of targets in the format described above.
//Вие сте в галерията за стрелба отново и имате нужда от програма, която ви помага да следите движещите се цели.
//На първия ред ще получите последователност от цели с техните цели стойности, разделени от едно място.
//След това ще започнете да получавате команди за манипулиране на целите, докато командата "Край". Командите са следните:
//•         Заснемане
//{ индекс}
//{ мощност}
//o Снимайте целта в индекса, ако тя съществува чрез намаляване на стойността му с дадената мощност ( цялочисло ). Целта се счита за изстрел, когато стойността й достига 0.
//o Премахване на целта, ако е заснет.
//•         Добавяне на {индекс} { стойност}
//o Въведете цел с получената стойност в получения индекс, ако съществува. Ако не, отпечатайте:: "Невалидно разположение!"
//•         Предупреждение {индекс} { радиус}
//o Премахване на целта в дадения индекс и тези преди и след него в зависимост от радиуса, ако такъв съществува. Ако някой от индексите в диапазона е невалиден печат:
//"Ударът пропусна!" и пропуснете тази команда.
//Пример: Удар 2 2
// 	{ радиус} { радиус} { стачкаИндекс} { радиус} { радиус}	 	 
 
//•         Край
//o Отпечатайте последователността с цели в следния формат:
//{ цел1}| { цел2}
//...| { целn}
//Вход / Ограничения
//•         На първия ред ще получите последователността от цели – цели стойности [1-10000].
//•         На следващите редове, докато "Край" ще бъде получаване на командата, описана по-горе – низове.
//•         Никога няма да има случай, когато командата "Strike" би изпразнила цялата последователност.
//Изход
//•         Отпечатайте съответното съобщение в случай на "Strike" команда, ако е необходимо.
//•         В крайна сметка отпечатайте последователността от цели във формат, описан по-горе.
