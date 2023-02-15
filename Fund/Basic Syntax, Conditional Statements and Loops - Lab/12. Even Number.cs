using System;

namespace Even_Number
{
	class Program
	{
		static void Main(string[] args)
		{
			bool isExitLoop = false;

			while (!isExitLoop)
			{
				int inputN = int.Parse(Console.ReadLine());
				inputN = Math.Abs(inputN);

				if ((inputN % 2) == 0)
				{
					Console.WriteLine($"The number is: {inputN}");
					isExitLoop = true;
				}
				else
				{
					Console.WriteLine("Please write an even number.");
				}
			}
		}
	}
}
//Вземете като вход четно число и отпечатайте абсолютната му стойност. Ако числото е нечетно, отпечатайте „Моля, напишете четно число“. и продължете да четете числа. 