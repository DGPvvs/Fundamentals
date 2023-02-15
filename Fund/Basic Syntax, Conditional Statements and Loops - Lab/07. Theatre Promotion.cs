using System;

namespace Theatre_Promotion
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] array =
			{
				{12, 18, 12},
				{15, 20, 15},
				{5, 12, 10},
			};
			
			int i = 0;
			int j = 0;

			string inputDay = Console.ReadLine();
			int inputAge = int.Parse(Console.ReadLine());

			if ((inputAge < 0) || (inputAge > 122))
			{
				Console.WriteLine("Error!");
			}
			else
			{
				switch (inputDay)
				{
					case "Weekday":
						i = 0;
						break;
					case "Weekend":
						i = 1;
						break;
					case "Holiday":
						i = 2;
						break;
					default:
						break;
				}
				if ((inputAge >= 0) && (inputAge <= 18))
				{
					j = 0;
				}
				else if ((inputAge > 18) && (inputAge <= 64))
				{
					j = 1;
				}
				else
				{
					j = 2;
				}
				Console.WriteLine($"{array[i, j]}$");
			}

			
		}
	}
}
//Театърът продава билети, но се нуждае от програма за изчисляване на цената на единичен билет.
//Ако дадената възраст не отговаря на една от категориите, трябва да отпечатате „Грешка!“. Можете да видите цените в таблицата по-долу:
//Ден / възраст				0 <= възраст <= 18	18 < възраст <= 64 64 < възраст <= 122
//Делничен ден						12 $				18 $				12 $
//Уикенд							15 $				20 $				15 $
//Почивка							5 $					12 $				10 $
//Вход
//Входът се предлага в два реда. На първия ред ще получите вида на деня. На втория - възрастта на човека.
//Изход
//Отпечатайте цената на билета според таблицата или "Грешка!" ако възрастта не е в таблицата.
//Ограничения
//• Възрастта ще бъде в интервала [-1000 ... 1000].
//• Типът ден винаги ще бъде валиден. 