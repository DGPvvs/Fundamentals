using System;
using System.Collections.Generic;
using System.Text;

namespace Take_Skip_Rope
{
	class Take_SkipRope
	{
		static void Main(string[] args)
		{
			StringBuilder text = new StringBuilder(Console.ReadLine());
			StringBuilder digits = new StringBuilder();
			StringBuilder letters = new StringBuilder();

			List<int> takeList = new List<int>();
			List<int> skipList = new List<int>();

			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsDigit(text[i]))
				{
					digits.Append(text[i]);
				}
				else
				{
					letters.Append(text[i]);
				}
			}
						
			for (int i = 0; i < digits.Length; i++)
			{
				if ((i % 2) == 0)
				{
					takeList.Add(int.Parse(digits[i].ToString()));
				}
				else
				{
					skipList.Add(int.Parse(digits[i].ToString()));
				}				
			}

			int takeIndex = 0;
			int skipIndex = 0;
			int curreantIndex = 0;
			//bool isLoopExit = false;

			digits.Clear();

			for (int i = 0; i < skipList.Count; i++)
			{
				skipIndex = skipList[i];
				takeIndex = takeList[i];
				curreantIndex = takeIndex;

				if (curreantIndex > letters.ToString().Length)
				{
					curreantIndex = letters.ToString().Length;
				}

				digits.Append(letters.ToString().Substring(0, curreantIndex));
				skipIndex += takeIndex;

				curreantIndex = skipIndex;

				if (curreantIndex > letters.ToString().Length)
				{
					curreantIndex = letters.ToString().Length;
				}

				text.Clear();
				text.Append(letters.ToString().Substring(curreantIndex));
				letters.Clear();
				letters.Append(text);
			}
									
			Console.WriteLine(digits);
		}
	}
}
//Write a program, which reads a string and skips through it, extracting a hidden message. The algorithm you have to implement is as follows:
//Let’s take the string “skipTest_String044170” as an example.
//Take every digit from the string and store it somewhere. After that, remove all the digits from the string. After this operation, you should have two lists of items: the numbers list and the non-numbers list:
//•	Numbers list: [0, 4, 4, 1, 7, 0]
//•	Non - numbers: [s, k, i, p, T, e, s, t, _, S, t, r, i, n, g]
//After that, take every digit in the numbers list and split it up into a take list and a skip list, depending on whether the digit is in an even or an odd index:
//•	Numbers list: [0, 4, 4, 1, 7, 0]
//•	Take list: [0, 4, 7]
//•	Skip list: [4, 1, 0]
//Afterwards, iterate over both of the lists and skip {skipCount} characters from the non-numbers list, then take {takeCount} characters and store it in a result string. Note that the skipped characters are summed up as they go. The process would look like this on the aforementioned non-numbers list:
//1.Take 0 characters  Taken: "", skip 4 characters(total 0)  Skipped: "skipTest_String" Result: ""
//2.Take 4 characters Taken: "Test", skip 1 characters(total 4)  Skipped: "skip"  Result: "Test"
//3.Take 7 characters Taken: "String", skip 0 characters(total 9) Skipped: ""  Result: "TestString"
//After that, just print the result string on the console.
//Input
//•	First line: The encrypted message as a string
//Output
//•	First line: The decrypted message as a string
//Constraints
//•	The count of digits in the input string will always be even.
//•	The encrypted message will contain any printable ASCII character.
//Напишете програма, която чете низ и прескочи през него, извличайки скрито съобщение. Алгоритъмът, който трябва да приложите, е както следва:
//Нека да вземем низ "skipTest_String044170" катопример.
//Вземете всяка цифра от низа и я съхранявайте някъде. След това премахнете всички цифри от низа. След тази операция трябва да имате два списъка с елементи: списъка с номера и списъка с не-номера:
//•         Списък с числа: [0, 4, 4, 1, 7, 0]
//•         Не - номера: [s, k, i, p, T, e, s, t, _, S, t, r, i, n, g]
//След това вземете всяка цифра в списъка с числа и я разделете на списък с течащи и пропускащ списък, в зависимост от това дали цифрата е в четен или нечетен индекс:
//•         Списък с номера: [0, 4, 4, 1, 7, 0]
//•         Списък с те ще вземат: [0, 4, 7]
//•         Пропускане на списък: [4, 1, 0]
//След това прескачайте и двата списъка и пропуснете {skipCount} от списъка, който не е номер, след което вземете {takeCount} знака и ги съхранявайте в низза резултати . Имайте предвид, че пропуснатите знаци се обобщават, докато те се изпълняват. Процесът ще изглежда така в гореспоменатия списък, който не е с номера:
//1.Вземете 0 è Взети è: "", пропуснете 4 знака(общо 0)  Прескачане: "skipTest_String" Резултат: ""
//2.Вземете 4 символа Taken: " Test", прескачане на 1 знака (общо 4)  Прескочи: "Прескачане"  резултат: "Тест"
//3.Вземете 7 è Taken: "String", пропуснете 0 знака(общо 9) Прескочи: ""  Резултат: "TestString"
//След това просто отпечатайте низ за резултата на конзолата.
//въвеждане
//•         Първи ред: Шифрованото съобщение като низ
//изход
//•         Първи ред: Дешифрираното съобщение като низ
//Ограничения
//•         Броят на цифрите в входния низ винаги ще бъде равен.
//•         Шифрованото съобщение ще съдържа всеки знак ASCII за печат.
