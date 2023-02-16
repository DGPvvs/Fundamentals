using System;
using System.Linq;

namespace Shoot_for_the_Win
{
	class ShootfortheWin
	{
		static bool IsvalisIndex(int[] arr, int index)
		{
			bool result = false;
			if ((index >= 0) && (index < arr.Length) && (arr[index] != -1))
			{
				result = true;
			}
			return result;
		}// bool IsvalisIndex(int[], arr, int index)

		static void Main(string[] args)
		{
			int[] targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			bool isExitLoop = false;
			int countShots = 0;

			while (!isExitLoop)
			{
				string input = Console.ReadLine();
				if (input.ToLower().Equals("end"))
				{
					isExitLoop = true;
				}
				else
				{
					int targetIndex = int.Parse(input);
					if (IsvalisIndex(targets, targetIndex))
					{
						for (int i = 0; i < targets.Length; i++)
						{
							if ((targets[i] > targets[targetIndex]) && (i != targetIndex) && (targets[i] != -1))
							{
								targets[i] -= targets[targetIndex];

							}
							else if ((targets[i] <= targets[targetIndex]) && (i != targetIndex) && (targets[i] != -1))
							{
								targets[i] += targets[targetIndex];
							}
						}
						targets[targetIndex] = -1;
						countShots++;
					}
				}
			}

			Console.WriteLine($"Shot targets: {countShots} -> {string.Join(" ", targets)}");
		}
	}
}
//Write a program that helps you keep track of your shot targets. You will receive a sequence with integers, separated by single space, representing targets and their value. Afterwards, you will be receiving indices until the "End" command is given and you need to print the targets and the count of shot targets.
//Every time you receive an index, you need to shoot the target on that index, if it is possiblie. 
//Everytime you shoot a target, its value becomes -1 and it is considered shot. Along with that you also need to:
//•	Reduce all the other targets, which have greater values than your current target, with its value. 
//•	All the targets, which have less than or equal value to the shot target, you need to increase with its value.
//Keep in mind that you can't shoot a target, which is already shot. You also can't increase or reduce a target, which is considered shot.
//When you receive the "End" command, print the targets in their current state and the count of shot targets in the following format:
//"Shot targets: {count} -> {target1} {target2}… {targetn}"
//Input / Constraints
//•	On the first line of input you will receive a sequence of integers, separated by a single space – the targets sequence.
//•	On the next lines, until the "End" command you be receiving integers each on a single line – the index of the target to be shot.
//Output
//•	The format of the output is described above in the problem description.
//Напишете програма, която ви помага да следите вашите цели за изстрел. Ще получите поредица с цели числа, разделени с едно място, представляващи цели и тяхната стойност.
//След това ще получавате индекси до командата "Край" и трябва да отпечатате целите и броя на изстрелите цели.
//Всеки път, когато получите индекс, трябва да стреляте по целта на този индекс, ако е posiblie.
//Всеки път, когато стреляте цел, стойността му става -1 и тя се счита за изстрел . Заедно с това трябва да:
//•         Намалете всички други цели, които имат по-големи стойности от текущата ви цел, със стойността й.
//•         Всички цели, които имат по-малка или равна стойност на целта, трябва да увеличите с нейната стойност.
//Имайте предвид, че не можете да стреляте цел, която вече е заснет. Също така не можете да увеличите или намалите цел, която се счита за изстрел.
//Когато получите командата "Край", отпечатайте цели в текущото си състояние и броя на изстрел цели в следния формат:
//"Цели на изстрела: {count} -> {цел1} {цел2}... {целn}"
//Вход / Ограничения
//•         На първия ред на въвеждане ще получите последователност от цели бройки, разделени с едно пространство – целевата последователност.
//•         На следващите редове– до командата "Край" получавате цели бройки всеки на един ред – индексът на целта, която трябва да бъде заснета.
//Изход
//•         Форматът на изхода е описан по-горе в описанието на проблема.
