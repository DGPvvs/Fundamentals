using System;

namespace _2._Passed
{
	class Program
	{
		static void Main(string[] args)
		{
			double inputEvaluation;

			inputEvaluation = double.Parse(Console.ReadLine());

			if (inputEvaluation >= 3.0)
			{
				Console.WriteLine("Passed!");
			}			
		}
	}
}
//Напишете програма, която приема като вход оценка и отпечатва "Приет!" ако оценката е равна или по-голяма от 3,00.
//Вход
//Входът идва като единично число с плаваща запетая.
//Изход
//Изходът е или "Приет!" ако оценката е равна или по-голяма от 3,00, в противен случай не трябва да отпечатвате нищо.