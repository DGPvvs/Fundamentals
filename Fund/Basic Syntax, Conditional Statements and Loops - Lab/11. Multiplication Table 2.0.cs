using System;

namespace Multiplication_Table_2._0
{
	class Program
	{
		static void Main(string[] args)
		{
			int inputTheInteger = int.Parse(Console.ReadLine());
			int inputTimes = int.Parse(Console.ReadLine());
			
			do
			{
				Console.WriteLine($"{inputTheInteger} X {inputTimes} = {inputTheInteger * inputTimes}");
				inputTimes++;
			} while (inputTimes <= 10);
		}
	}
}
//Пренапишете вашата програма, за да може да получи множителя от конзолата.
//Отпечатайте таблицата от дадения множител на 10.
//Ако дадения множител е повече от 10 - отпечатайте само един ред с цялото число, дадения множител и продукта.
//Вижте примерите по-долу за повече информация.
//Изход
//Отпечатайте всеки ред от таблицата в следния формат:
//{ theInteger}
//X
//{ пъти} = { продукт}
//Ограничения
//• Цялото число ще бъде в интервала [1 ... 100] 