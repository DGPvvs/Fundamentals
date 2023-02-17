using System;
using System.Text;

namespace Advertisement_Message
{
	class AdvertisementMessage
	{
		static void Main(string[] args)
		{
			string[] phrases = {"Excellent product."
					, "Such a great product."
					, "I always use that product."
					, "Best product of its category."
					, "Exceptional product."
					, "I can’t live without this product."};
			string[] events = {"Now I feel good."
					, "I have succeeded with this product."
					, "Makes miracles. I am happy of the results!"
					, "I cannot believe but now I feel awesome."
					, "Try it yourself, I am very satisfied."
					, "I feel great!"};
			string[] authors = {"Diana"
					, "Petya"
					, "Stella"
					, "Elena"
					, "Katya"
					, "Iva"
					, "Annie"
					, "Eva"};
			string[] cities = {"Burgas"
					, "Sofia"
					, "Plovdiv"
					, "Varna"
					, "Ruse"};

			Random rnd = new Random();

			StringBuilder sb = new StringBuilder();
			int index = int.Parse(Console.ReadLine());

			for (int i = 1; i <= index; i++)
			{
				sb.Clear();
				sb.Append(phrases[rnd.Next(0, phrases.Length)]);
				sb.Append(' ');
				sb.Append(events[rnd.Next(0, events.Length)]);
				sb.Append(' ');
				sb.Append(authors[rnd.Next(0, authors.Length)]);
				sb.Append(" - ");
				sb.Append(cities[rnd.Next(0, cities.Length)]);
				Console.WriteLine(sb);
			}			
		}
	}
}
//Write a program that generates random fake advertisement message to advertise a product. The messages must consist of 4 parts: phrase + event + author + city. Use the following predefined parts:
//•	Phrases – { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."}
//•	Events – { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"}
//•	Authors – { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"}
//•	Cities – { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"}
//The format of the output message is the following: { phrase} {event} { author} – { city}.
//You will receive the number of messages to be generated. Print each random message at a separate line.
//Напишете програма, която генерира случайно фалшиво съобщение за реклама, за да рекламирате даден продукт. Съобщенията трябва да се състоят от 4 части: фраза + събитие + автор + град. Използвайте следните предварително дефинирани части:
//•         Фрази – { "Отличен продукт.", "Такъв страхотен продукт.", "Винаги използвам този продукт.", "Най-добър продукт от своята категория.", "Изключителен продукт.", "Не мога да живея без този продукт."}
//•         Събития – { "Сега се чувствам добре.", "Успях с този продукт.", "Прави чудеса. Щастлив съм от резултатите!", "Чувствам се страхотно," "Опитайте самите", "Чувствам се чудесно!"}
//•         Автори – { "Диана", "Петя", "Стела", "Елена", "Катя", "Ива", "Ани", "Ева"}
//•         Градове – { "Бургас", "София", "Пловдив", "Варна", "Русе" }
//Форматът на изходното съобщение е следният: { фразата фраза} { събитие} { автор} – { град} .
//Ще получите броя на съобщенията, които ще бъдат генерирани. Отпечатайте всяко случайно съобщение на отделен ред.
