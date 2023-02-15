using System;

namespace _3._Passed_or_Failed
{
	class Program
	{
		static void Main(string[] args)
		{
			double input;

			input = double.Parse(Console.ReadLine());

			if (input >= 3.0)
			{
				Console.WriteLine("Passed!");
			}
			else
			{
				Console.WriteLine("Failed!");
			}			
		}
	}
}
//Променете горната програма, така че тя ще отпечата „Неуспешно!“ ако оценката е по-ниска от 3,00.
//Вход
//Входът е еднократно двойно число.
//Изход
//Изходът е или "Приет!" ако оценката е повече от 2,99, в противен случай трябва да отпечатате „Неуспешно!“.
//The way out is either "Accepted!" if the rating is more than 2.99, otherwise you must print "Failed!".