using System;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Collections.Generic;

namespace Emoji_Detector
{
	class EmojiDetector
	{
		static void Main(string[] args)
		{
			const string patternName = @"(::|\*\*)(?<name>[A-Z][a-z]{2,})\1";
			const string patternDigit = @"(?<digit>\d)";
			string text = Console.ReadLine();			

			MatchCollection digitList = Regex.Matches(text, patternDigit);
			MatchCollection namesList = Regex.Matches(text, patternName);

			BigInteger coolThreshold = 1;

			foreach (Match item in digitList)
			{
				coolThreshold *= BigInteger.Parse(item.Groups["digit"].Value);
			}

			Dictionary<string, int> emojiList = new Dictionary<string, int>();

			foreach (Match item in namesList)
			{
				int coolness = 0;
				for (int i = 0; i < item.Groups["name"].Length; i++)
				{
					coolness += (int)item.Groups["name"].Value[i];
				}

				string name = item.Groups[1].Value + item.Groups["name"].Value + item.Groups[1].Value;
				emojiList.Add(name, coolness);
			}

			Console.WriteLine($"Cool threshold: {coolThreshold}");
			Console.WriteLine($"{emojiList.Count} emojis found in the text. The cool ones are:");

			foreach (KeyValuePair<string, int> item in emojiList)
			{
				if (item.Value > coolThreshold)
				{
					Console.WriteLine(item.Key);
				}
			}
		}
	}
}
//Your task is to write program which extracts emojis from a text and find the threshold based on the input.
//You have to get your cool threshold. It is obtained by multiplying all the digits found in the input.  The cool threshold could be a very big number, so be mindful.
//An emoji is valid when:
//•	Is surrounded by either :: or ** (exactly 2)
//•	Is at least 3 characters long (without the surrounding symbols)
//•	Starts with a capital letter
//•	Continues with lowercase letters only
//Examples of valid emojis: ::Joy::, **Banana**, ::Wink::
//Examples of invalid emojis: ::Joy**, ::fox:es:, **Monk3ys**, :Snak::Es::
//You need to count all valid emojis in the text and calculate their coolness. The coolness of the emoji is determined by summing all the ASCII values of all letters in the emoji. 
//Examples: ::Joy:: - 306, **Banana** - 577, ::Wink:: - 409
//You need to print the result of cool threshold and after that to take all emojis out of the text, count them and print the only the cool ones on the console. 
//Input
//•	On the single input you will receive a piece of string. 
//Output
//•	On the first line of the output print the obtained Cool threshold in format:
//•	Cool threshold: {coolThresholdSum}
//On the next line print the count of all emojis found in the text in format:
//•	{countOfAllEmojis} emojis found in the text. The cool ones are:
//•	{cool emoji 1}
//•	{cool emoji 2}
//•	{…}
//If there are no cool ones, just don't print anything in the end.
//Constraints
//There will always be at least one digit in the text!
//Your task is to write program which extracts emojis from a text and find the threshold based on the input.
//You have to get your cool threshold. It is obtained by multiplying all the digits found in the input.  The cool threshold could be a very big number, so be mindful.
//An emoji is valid when:
//•	Is surrounded by either :: or ** (exactly 2)
//•	Is at least 3 characters long (without the surrounding symbols)
//•	Starts with a capital letter
//•	Continues with lowercase letters only
//Examples of valid emojis: ::Joy::, **Banana**, ::Wink::
//Examples of invalid emojis: ::Joy**, ::fox:es:, **Monk3ys**, :Snak::Es::
//You need to count all valid emojis in the text and calculate their coolness. The coolness of the emoji is determined by summing all the ASCII values of all letters in the emoji. 
//Examples: ::Joy:: - 306, **Banana** - 577, ::Wink:: - 409
//You need to print the result of cool threshold and after that to take all emojis out of the text, count them and print the only the cool ones on the console. 
//Input
//•	On the single input you will receive a piece of string. 
//Output
//•	On the first line of the output print the obtained Cool threshold in format:
//•	Cool threshold: {coolThresholdSum}
//On the next line print the count of all emojis found in the text in format:
//•	{countOfAllEmojis} emojis found in the text. The cool ones are:
//•	{cool emoji 1}
//•	{cool emoji 2}
//•	{…}
//If there are no cool ones, just don't print anything in the end.
//Constraints
//There will always be at least one digit in the text!
//Вашата задача е да напишете програма, която извлича emojis от текст и да намерите прага въз основа на входа.
//Трябва да си вземеш хладен праг. Тя се получава, като се умножат всички цифри, които се намират във входа. Прохладният праг може да бъде много голям брой,така че внимавайте.
//Емотикони е валидна, когато:
//•         Е заобиколен от :: или ** (точно 2)
//•         Е дълъг е поне 3 символа (без околните символи)
//•         Започва с главна буква
//•         Продължава само с малки букви
//Примери за валидни емоджи: ::Joy:: **Банан**, ::Wink::
//Примери за невалидни емоджи: ::Joy**, ::fox:es:**
//Трябва да преброите всички валидни emojis в текста и да изчислите тяхната прохлада. Прохладата на емоджитата се определя чрез сумиране на всички ASCII стойности на всички букви в емоджита.
//Примери: ::Joy:: - 306, **Банан** - 577, ::Намисъл:: - 409
//Трябва да отпечатате резултата от хладния праг и след това да извадите всички емоджи от текста, да ги броите и да отпечатате само готините на конзолата.
//Въвеждане
//•         На единичен вход ще получите парче низ.
//Изход
//•         На първия ред на изхода отпечатате получения праг хладно във формат:
//•         Хладен праг: {coolsresholdSum}
//На следващия ред отпечатайте броя на всички емоджи, намерени в текста във формат:
//•         {countOfAllEmojis} емотикони намерени в текста. Готините са:
//•         {готини емотикони}
//•         {готини емотикони 2}
//•         {...}
//Ако няма готини, просто не отпечатвай нищо накрая.
//Ограничения
//Винаги ще има поне една цифра в текста!
//Вашата задача е да напишете програма, която извлича emojis от текст и да намерите прага въз основа на входа.
//Трябва да си вземеш хладен праг. Тя се получава, като се умножат всички цифри, които се намират във входа. Прохладният праг може да бъде много голям брой,така че внимавайте.
//Емотикони е валидна, когато:
//•         Е заобиколен от :: или ** (точно 2)
//•         Е дълъг е поне 3 символа (без околните символи)
//•         Започва с главна буква
//•         Продължава само с малки букви
//Примери за валидни емоджи: ::Joy:: **Банан**, ::Wink::
//Примери за невалидни емоджи: ::Joy**, ::fox:es:**
//Трябва да преброите всички валидни emojis в текста и да изчислите тяхната прохлада. Прохладата на емоджитата се определя чрез сумиране на всички ASCII стойности на всички букви в емоджита.
//Примери: ::Joy:: - 306, **Банан** - 577, ::Намисъл:: - 409
//Трябва да отпечатате резултата от хладния праг и след това да извадите всички емоджи от текста, да ги броите и да отпечатате само готините на конзолата.
//Въвеждане
//•         На единичен вход ще получите парче низ.
//Изход
//•         На първия ред на изхода отпечатате получения праг хладно във формат:
//•         Хладен праг: {coolsresholdSum}
//На следващия ред отпечатайте броя на всички емоджи, намерени в текста във формат:
//•         {countOfAllEmojis} емотикони намерени в текста. Готините са:
//•         {готини емотикони}
//•         {готини емотикони 2}
//•         {...}
//Ако няма готини, просто не отпечатвай нищо накрая.
//Ограничения
//Винаги ще има поне една цифра в текста!
