using System;

namespace Multiplication_Table
{
	class Program
	{
		static void Main(string[] args)
		{
			int inputN = int.Parse(Console.ReadLine());

			for (int i = 1; i <= 10; i++)
			{
				Console.WriteLine($"{inputN} X {i} = {inputN * i}");
			}
		}
	}
}
//Ще получите цяло число като вход от конзолата. Отпечатайте таблицата 10 пъти за това цяло число. Вижте примерите по-долу за повече информация.
//Изход
//Отпечатайте всеки ред от таблицата в следния формат:
//{ theInteger}
//X
//{ пъти} = { продукт}
//Ограничения
//• Цялото число ще бъде в интервала [1 ... 100] 