using System;

namespace SoftUni_Reception
{
	class SoftUniReception
	{
		static void Main(string[] args)
		{
			int firstEfficiency = int.Parse(Console.ReadLine());
			int secondEfficiency = int.Parse(Console.ReadLine());
			int thirdEfficiency = int.Parse(Console.ReadLine());

			int numPeople = int.Parse(Console.ReadLine());

			int peoplePerHour = firstEfficiency + secondEfficiency + thirdEfficiency;
			int hour = 0;
			int pause = 0;

			while (numPeople > 0)
			{
				numPeople -= peoplePerHour;
				hour++;
				pause++;
				if ((pause == 3) && (numPeople > 0))
				{
					hour++;
					pause = 0;
				}
			}


			Console.WriteLine($"Time needed: {hour}h.");
		}
	}
}
//Every day thousands of students pass by the reception at SoftUni with different questions to ask and the employees have to help everyone by providing all the information and to answer all of the questions.
//There are 3 employees working on the reception all day. Each of them can handle different number of students per hour. Your task is to calculate how much time it will take to answer all the questions of given number of students.
//First you will receive 3 lines with integers, representing count of students that each of the employee can help per hour. On the next line you will receive students count as a single integer. 
//Every forth hour all of the employees have a break, so they don’t work for a hour. This is the only break for the employees, because they don`t need rest, nor have a personal life. Calculate the time needed to answer all the student's questions and print it in the following format: "Time needed: {time}h."
//Input / Constraints
//•	On first three lines -  each employee efficiency -  integer in range [1 - 100]
//•	On the fourth line - students count – integer in range [0 – 10000]
//•	Input will always be valid and in the range specified
//Output
//•	Print a single line: "Time needed: {time}h."
//•	Allowed working time / memory: 100ms / 16MB
//    Всеки ден хиляди студенти минават покрай рецепцията в SoftUni с различни въпроси, които да задават и служителите трябва да помагат на всички, като предоставят цялата информация и да отговорят на всички въпроси.
//По цял ден на рецепцията работят 3 служители. Всеки от тях може да се справи с различен брой ученици на час. Вашата задача е да изчислите колко време ще отнеме да отговорите на всички въпроси на даден брой ученици.
//Първо ще получите 3 линии с цяло число, представляващи брой студенти, които всеки от служителя може да помогне на час. На следващия ред ще получите студенти брой като едно цяло число.
//На всеки четвърти час всички служители имат почивка, така че не работят цял час. Това е единствената почивка за служителите, защото нямат нужда от почивка, нито имат личен живот. Изчислете времето, необходимо за отговор на всички въпроси на ученика и го отпечатайте в следния формат: "Необходимо време: {time}h."
//1.Вход / Ограничения
//•         На първите три реда - всяка ефективност на служителите - цяло число в обхват [1 - 100]
//•         На четвърта линия - учениците броят – цяло число в обхват [0 – 10000]
//•         Входът винаги ще бъде валиден и в зададения диапазон
//2.	Изход
//•         Печат на един ред: "Необходимо време: {time}h."
//•         Разрешено работно време / памет: 100ms / 16MB