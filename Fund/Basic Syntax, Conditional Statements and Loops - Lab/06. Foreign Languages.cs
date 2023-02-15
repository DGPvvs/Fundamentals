using System;

namespace _6._Foreign_Languages
{
	class Program
	{
		static void Main(string[] args)
		{
			string country = Console.ReadLine();

			switch (country)
			{
				case "England":
				case "USA":
					Console.WriteLine("English");
					break;
				case "Spain":
				case "Argentina":
				case "Mexico":
					Console.WriteLine("Spanish");
					break;
				default:
					Console.WriteLine("unknown");
					break;
			}

			
		}
	}
}
//Напишете програма, която отпечатва езика, на който дадена държава говори.
//Можете да получите само следните комбинации: Английски се говори в Англия и САЩ; Испанският се говори в Испания, Аржентина и Мексико; за останалите трябва да отпечатаме „неизвестно“.
//Вход
//Ще получите едно име на държава на един ред.
//Изход
//Отпечатайте езика, на който говори държавата, или ако е непознат за вашата програма, отпечатайте „неизвестен“.
//English is spoken in England and USA; Spanish is spoken in Spain, Argentina and Mexico; for the others, we should print "unknown"