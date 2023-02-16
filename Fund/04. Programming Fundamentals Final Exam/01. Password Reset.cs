using System;
using System.Text;

namespace Password_Reset
{
	class PasswordReset
	{
		static void Main(string[] args)
		{
			StringBuilder password = new StringBuilder(Console.ReadLine());
			StringBuilder input = new StringBuilder();

			bool isLoopExit = false;

			while (!isLoopExit)
			{
				input.Clear();
				if (input.Append(Console.ReadLine()).ToString().ToLower().Equals("done"))
				{
					isLoopExit = true;
				}
				else
				{
					string[] command = input.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

					switch (command[0].ToLower())
					{
						case "takeodd":
							for (int i = password.Length - 1; i >= 0; i--)
							{
								if (i % 2 == 0)
								{
									password.Remove(i, 1);									
								}
							}
							Console.WriteLine(password.ToString());
							break;
						case "cut":
							int index = int.Parse(command[1]);
							int length = int.Parse(command[2]);
							input.Clear();
							input.Append(password.ToString().Substring(0, index));
							input.Append(password.ToString().Substring(index + length, password.Length - (index + length)));
							password.Clear();
							password.Append(input);
							Console.WriteLine(password.ToString());
							break;
						case "substitute":
							string substring = command[1];
							string substitute = command[2];
							input.Clear();
							input.Append(password.ToString().Replace(substring, substitute));
							if (input.ToString().Equals(password.ToString()))
							{
								Console.WriteLine("Nothing to replace!");
							}
							else
							{
								password.Clear();
								password.Append(input);
								Console.WriteLine(password.ToString());
							}							
							break;
						default:
							break;
					}
				}
			}
			Console.WriteLine($"Your password is: {password.ToString()}");
		}
	}
}
//Yet again you have forgotten your password... Naturally it`s not the first time this has happened. Actually you got so tired of it that you decided to help yourself with a smart solution.
//Write a password reset program that performs a series of commands upon a predefined string. First, you will receive a string and afterwards, until the command "Done" is given, you will be receiving strings with commands split by a single space. The commands will be the following:
//•	TakeOdd
//o	 Takes only the characters at odd indices and concatenates them together to
//obtain the new raw password and then prints it.
//•	Cut {index} { length}
//o Gets the substring with the given length starting from the given index from the password and removes its first occurrence of it, then prints the password on the console.
//o	The given index and length will always be valid.
//•	Substitute {substring} { substitute}
//o If the raw password contains the given substring, replaces all of its 
//occurrences with the substitute text given and prints the result.
//o	If it doesn’t, prints "Nothing to replace!"
//Input
//•	You will be receiving strings until the "Done" command is given.
//Output
//•	After the "Done" command is received, print:
//o "Your password is: {password}"
//Constraints
//•	The indexes from the "Cut {index} {length}" command will always be valid.
//И все пак отново сте забравили паролата си... Естествено, не за първи път се случва. Всъщност ти се умори толкова, че реши да си помогнеш с умно решение.
//Напишете програма за нулиране на паролата, която изпълнява серия от команди в предварително зададен низ.
//Първо, ще получите низ и след това, докато командата"Готово"е дадена, ще получавате низове с команди, разделени от едно място. Командите ще бъдат следните:
//•         Танеод
//О   Взема само знаците на нечетни индекси и ги свързва, за да
//да получите новата сурова парола и след това я отпечатва.
//•         Нарязани {index} { дължина}
//o Получава подниз с дадена дължина, започвайки от дадения индекс от паролата и премахва първото му появяване, след което отпечатва паролата на конзолата.
//o Даденият индекс и дължина винаги ще бъдат валидни.
//•         Заместване {substring} { заместване}
//О Ако необработената парола съдържа дадената подниз,
//с дадения заместващ текст и отпечатва резултата.
//o Ако не, отпечатва "Нищо за замяна"
//Въвеждане
//•         Ще получавате низове, докато не бъде дадена командата "Готово".
//Изход
//•         След като командата "Готово" е получена, отпечатайте:
//o "Вашата парола е: {парола}"
//Ограничения
//•         Индексите от командата "Cut {index} {дължина}винаги ще бъдат валидни.
