using System;

namespace Black_Flag
{
	class BlackFlag
	{
		static void Main(string[] args)
		{
			const double WarshipLose = .7;

			int daysOfThePlunder = int.Parse(Console.ReadLine());
			byte dailyPlunder = byte.Parse(Console.ReadLine());
			double expectedPlunder = double.Parse(Console.ReadLine());

			double thirdDayBonus = .5 * dailyPlunder;

			int thirdDayBonusCounter = 0;
			int WarshipLoseCounter = 0;
			double plunderSum = 0;

			for (int i = 1; i <= daysOfThePlunder; i++)
			{
				plunderSum += dailyPlunder;
				thirdDayBonusCounter++;
				WarshipLoseCounter++;

				if ((thirdDayBonusCounter % 3) == 0 )
				{
					plunderSum += thirdDayBonus;
					thirdDayBonusCounter = 0;
				}

				if ((WarshipLoseCounter % 5) == 0)
				{
					plunderSum *= WarshipLose;
					WarshipLoseCounter = 0;
				}
			}

			if ((plunderSum - expectedPlunder) >= 0)
			{
				Console.WriteLine($"Ahoy! {plunderSum:F2} plunder gained.");
			}
			else
			{
				double result = (1.0 * plunderSum * 100) / expectedPlunder;
				Console.WriteLine($"Collected only {result:F2}% of the plunder.");
			}			
		}
	}
}
//Pirates are invading the sea and you're tasked to help them plunder
//Create a program that checks if a target plunder is reached. First you will receive how many days the pirating lasts. Then you will receive how much the pirates plunder for a day. Last you will receive the expected plunder at the end.
//Calculate how much plunder the pirates manage to gather. Each day they gather plunder. Keep in mind that every third day they attack more ships and they add additional plunder to their total gain which is 50% of the daily plunder. Every fifth day the pirates encounter a warship and after the battle they lose 30% of their total plunder.
//If the gained plunder is more or equal to the target print the following:
//"Ahoy! {totalPlunder} plunder gained."
//If the gained plunder is less than the target. Calculate the percentage left and print the following:
//"Collected only {percentage}% of the plunder."
//Both numbers should be formatted to the 2nd decimal place.
//Input
//•	On the 1st line you will receive the days of the plunder – an integer number in the range [0…100000]
//•	On the 2nd line you will receive the daily plunder – an integer number in the range [0…50]
//•	On the 3rd line you will receive the expected plunder – a real number in the range [0.0…10000.0]
//Output
//•	 In the end print whether the plunder was successful or not following the format described above.
//Пиратите нахлуват в морето и сте натоварени да им помогнете да ограбят
//Създаване на програма, която проверява дали е достигната целева ограбване . Първо ще получите колко дни трае пиратската пиратка.
//След това ще получите колко пиратите ограбват за един ден. Последно ще получите очакваната ограбка в края.
//Изчислете колко ограбват пиратите успяват да се съберат. Всеки ден те събират ограбване.
//Имайте предвид, че всеки трети ден те атакуват повече кораби и те добавят допълнително ограбване към общата си печалба, която е 50% от дневната ограбване.
//Всеки пети ден пиратите се сблъскват с боен кораб и след битката губят 30% от общия си плямпач.
//Ако придобитата плячкосване е повече или равна на целевия печат следното:
//"Ахой! {totalPlunder} грабител придобит."
//Ако придобитото ограбване е по-малко от целта. Изчислете процента наляво и отпечатайте следното:
//"Събрани само {процент}% от ограбващия."
//И двете числа трябва да бъдат форматирани до 2-ри знак след десетичната запетая.
//Въвеждане
//•         На 1-вата линия ще получите дните на разграбването – цяло число в диапазона [0... 100000]
//•         На 2 - ра линия ще получите дневната разграбка –числоn цяло число в диапазона [0... 50]
//•         На 3 - та линия ще получите очакваната ограбка – реално число в диапазона [0.0... 10000.0]
//Изход
//•         В крайна сметка отпечатайте дали разграбвачът е бил успешен или не следва формата, описан по-горе.
