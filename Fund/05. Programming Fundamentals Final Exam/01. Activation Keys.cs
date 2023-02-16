using System;
using System.Text;

namespace Activation_Keys
{
	class ActivationKeys
	{
		static void Main(string[] args)
		{
			StringBuilder key = new StringBuilder(Console.ReadLine());
			StringBuilder sb = new StringBuilder();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("generate"))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = sb.ToString().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
					string command = input[0];

					switch (command.ToLower())
					{
						case "contains":
							string sub = input[1];
							if (key.ToString().Contains(sub))
							{
								Console.WriteLine($"{key.ToString()} contains {sub}");
							}
							else
							{
								Console.WriteLine("Substring not found!");
							}
							break;
						case "flip":
							string caseType = input[1];

							int startIndex = int.Parse(input[2]);
							int endIndex = int.Parse(input[3]);
							for (int i = startIndex; i < endIndex; i++)
							{
								if (caseType.ToLower().Equals("upper"))
								{
									char[] sh = key[i].ToString().ToUpper().ToCharArray();
									key[i] = sh[0];
								}
								else
								{
									char[] sh = key[i].ToString().ToLower().ToCharArray();
									key[i] = sh[0];
								}
							}

							Console.WriteLine(key.ToString());
							break;
						case "slice":
							startIndex = int.Parse(input[1]);
							endIndex = int.Parse(input[2]);
							key.Remove(startIndex, endIndex - startIndex);
							Console.WriteLine(key.ToString());
							break;
						default:
							break;
					}
				}
			}//while (!isExitLoop)

			Console.WriteLine($"Your activation key is: {key.ToString()}");
		}
	}
}
//You are about to make some good money, but first you need to think of a way to verify who paid for your product and who didn`t. You have decided to let people use the software for a free trial period and then require an activation key in order to continue to use the product. The last step before you could cash out is to design a program that creates unique activation keys for each user. So, waste no more time and start typing!
//The first line of the input will be your raw activation key. It will consist of letters and numbers only. 
//After that, until the "Generate" command is given, you will be receiving strings with instructions for different operations that need to be performed upon the raw activation key.
//There are several types of instructions, split by ">>>":
//•	Contains >>>{ substring} – checks if the raw activation key contains the given substring.
//o	If it does prints: "{raw activation key} contains {substring}".
//o If not, prints: "Substring not found!"
//•	Flip >>> Upper / Lower >>>{ startIndex}>>>{ endIndex}
//o Changes the substring between the given indices (the end index is exclusive) to upper or lower case. 
//o	All given indexes will be valid.
//o	Prints the activation key.
//•	Slice>>>{startIndex}>>>{ endIndex}
//o Deletes the characters between the start and end indices (end index is exclusive).
//o Both indices will be valid.
//o	Prints the activation key.
//Input
//•	The first line of the input will be string and it will consist of letters and numbers only. 
//•	After the first line, until the "Generate" command is given, you will be receiving strings.
//Output
//•	After the "Generate" command is received, print:
//o "Your activation key is: {activation key}"
//Вие сте на път да се направи някои добри пари, но първо трябва да се мисли за начин да се провери кой е платил за вашия продукт и кой не.
//Решихте да позволите на хората да използват софтуера за безплатен пробен период и след това да се изисква ключ за активиране, за да продължи да използвате продукта.
//Последната стъпка, преди да можете да печеля, е да проектирате програма, която създава уникални ключове за активиране за всеки потребител.
//Така че, не губете повече време и започнете да пишете!
//Първият ред на входа ще бъде вашият ключ за активиране на сурово. Тя ще се състои само от букви и цифри.
//След това, докато командата "Генериране" се даде, ще получавате низове с инструкции за различни операции, които трябва да се извърши на ключа за активиране на raw.
//Има няколко вида инструкции, разделени по ">>>":
//•         Съдържа >>>{ substring} – проверява дали ключът за необработеното активиране съдържа даденото подниз.
//o Ако се отпечатва: "{ключ за необработено активиране} съдържа {substring}".
//o Ако не, отпечатъци: "Поднизът не е намерен!"
//•         Обръщане >>> upper / Lower >>>{ startIndex}>>>{ endIndex}
//o Променя подниза между дадените индекси (крайният индекс е изключителен) на малки или малки букви.
//o Всички дадени индекси ще бъдат валидни.
//o Отпечатва ключа за активиране.
//•         Сегмент>>>{startIndex}>>>{ endIndex}
//o Изтрива знаците между началните и крайните индекси(крайният индекс е изключителен).
//o И двата индекса ще бъдат валидни.
//o Отпечатва ключа за активиране.
//Въвеждане
//•         Първият ред на входа ще бъде низ и ще се състои само от букви и цифри.
//•         След първия ред, докато "Генериране" командата е дадена, ще получавате низове.
//Изход
//•         След като "Генерира" командата, печат:
//o "Вашият ключ за активиране е: {ключ за активация}"
