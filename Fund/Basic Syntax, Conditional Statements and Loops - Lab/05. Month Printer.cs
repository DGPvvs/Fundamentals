using System;

namespace _5._Month_Printer
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] mounths =
			    {
			        "Error!",
			        "January",
			        "February",
			        "March",
			        "April",
			        "May",
			        "June",
			        "July",
			        "August",
			        "September",
			        "October",
			        "November",
			        "December"
			     };

			int inputMount = int.Parse(Console.ReadLine());
			
			if(inputMount > 0 && inputMount < 13)
			{
			    Console.WriteLine(mounths[inputMount]);
			}
			else
			{
			    Console.WriteLine(mounths[0]);
			}			
		}
	}
}
//Напишете програма, която взема цяло число от конзолата и отпечатва съответния месец. Ако числото е повече от 12 или по-малко от 1, отпечатайте „Грешка!“.
//Вход
//Ще получите едно цяло число на един ред.
//Изход
//Ако номерът е в границите, отпечатайте съответния месец, в противен случай отпечатайте „Грешка!“.