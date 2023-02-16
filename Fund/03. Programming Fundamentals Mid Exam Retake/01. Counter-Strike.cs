using System;

namespace Counter_Strike
{
	class CounterStrike
	{
		static void Main(string[] args)
		{
			int energy = int.Parse(Console.ReadLine());

			bool isExitLoop = false;
			bool isDead = false;
			int countWin = 0;			

			while ((!isExitLoop) && (!isDead))
			{
				string input = Console.ReadLine();
				if (input.ToLower().Equals("end of battle"))
				{
					isExitLoop = true;
				}
				else
				{
					int hitPoint = int.Parse(input);
					if ((energy - hitPoint) >= 0)
					{
						countWin++;
						energy -= hitPoint;
						if (countWin % 3 == 0)
						{
							energy += countWin;
						}
					}
					else
					{
						Console.WriteLine($"Not enough energy! Game ends with {countWin} won battles and {energy} energy");
						isDead = true;
					}
				}
			}

			if (!isDead)
			{
				Console.WriteLine($"Won battles: {countWin}. Energy left: {energy}");
			}

			
		}
	}
}
//Write a program that keeps track of every won battle against an enemy. You will receive initial energy. Afterwards you will start receiving the distance you need to go to reach an enemy until the "End of battle" command is given, or until you run out of energy.
//The energy you need for reaching an enemy is equal to the distance you receive. Each time you reach an enemy, your energy is reduced. This is considered a successful battle (win). If you don't have enough energy to reach an the enemy, print:
//"Not enough energy! Game ends with {count} won battles and {energy} energy"
//and end the program.
//Every third won battle increases your energy with the value of your current count of won battles. 
//Upon receiving the "End of battle" command, print the count of won battles in the following format:
//"Won battles: {count}. Energy left: {energy}"
//Input / Constraints
//•	On the first line you will receive initial energy – an integer [1-10000].
//•	On the next lines, you will be receiving distance of the enemy – an integer [1-10000]
//Output
//•	The description contains the proper output messages for each case and the format in which they 
//should be print.
//Напишете програма , която следи всяка спечелена битка срещу враг. Ще получите първоначална енергия.
//След това ще започнете да получавате разстоянието, което трябва да отидете, за да достигнете до врага, докато не се даде командата "Край на битката" или докато ви свърши енергията.
//Енергията , която ти е нужна за достигане до враг , е равно на разстоянието , което получаваш.
//Всеки път, когато достигнеш враг, енергията ти се намалява. Това се счита за успешна битка (победа). Ако нямате достатъчно енергия, за да достигнете до врага, отпечатайте:
//"Няма достатъчно енергия! Играта завършва с {count} спечелени битки и енергия {енергия}
//и край на програмата.
//Всяка трета спечелена битка увеличава енергията ви с текущата ви брой на спечелените битки.
//При получаване на командата "Край на битката" отпечатайте броя на спечелените битки в следния формат:,
//"Спечелени битки: {count}. Енергия ляво: {енергия}"
//Вход / Ограничения
//•         На първия ред ще получите началното си енергийно потребление – цяло число [1-10000].
//•         На следващите редове ще получите разстояние от врага – цяло число [1-10000]
//Изход
//•         Описанието съдържа подходящите изходящи съобщения за всеки случай и формата, в който
//трябва да бъде отпечатан.
