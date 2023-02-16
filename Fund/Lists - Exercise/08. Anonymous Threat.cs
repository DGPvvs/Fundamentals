using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anonymous_Threat
{
	class AnonymousThreat
	{
		static bool ValidateRange(List<string> list, ref int startIndex, ref int endIndex)
		{
			bool result = false;

			if ((startIndex <= endIndex) && (endIndex >= 0) && (startIndex < list.Count))
			{
				if (startIndex < 0)
				{
					startIndex = 0;
				}

				if (endIndex > list.Count - 1)
				{
					endIndex = list.Count - 1;				 
				}

				result = true;
			}

			return result;
		}//bool ValidateRange(List<int> list, ref int startIndex, ref int endIndex)

		static StringBuilder MergeList(List<string> list, int startIndex, int endIndex)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = startIndex; i <= endIndex; i++)
			{
				sb.Append(list[startIndex]);
				list.RemoveAt(startIndex);
			}		

			return sb;
		}//StringBuilder MergeList(List<string> command, int startIndex, int endIndex)

		static void Main(string[] args)
		{
			List<string> list = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			StringBuilder sb = new StringBuilder();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine().ToLower()).ToString() == "3:1")
				{
					isExitLoop = true;
				}
				else
				{
					List<string> command = sb.ToString().Split(' ', '{', '}').ToList();

					if (command[0] == "merge")
					{
						sb.Clear();
						int startIndex = int.Parse(command[1]);
						int endIndex = int.Parse(command[2]);
						if (ValidateRange(list, ref startIndex, ref endIndex))
						{
							sb = MergeList(list, startIndex, endIndex);
							list.Insert(startIndex, sb.ToString());
						}						
					}
					else if (command[0] == "divide")
					{
						sb.Clear();
						int index = int.Parse(command[1]);
						int partitions = int.Parse(command[2]);

						command.Clear();

						if ((index > -1) && (index < list.Count))
						{
							sb.Append(list[index]);
							list.RemoveAt(index);

							int basis = sb.Length / partitions;
							int residue = sb.Length % partitions;

							if (basis > 0)
							{
								list.Insert(index, sb.ToString((partitions - 1) * basis, basis + residue));
							}

							for (int i = partitions - 2; i >= 0; i--)
							{
								list.Insert(index, sb.ToString(i * basis, basis));
							}
														
						}

					}

				}

			}
					Console.WriteLine(string.Join(' ', list));
		}
	}
}


//using System;

//using System.Text;

                                                                             

//public class Program

//{

//	public static void Main()

//	{

//		StringBuilder sbresult = new StringBuilder();

//		StringBuilder sb = new StringBuilder("qrstuvwxyz4e3wsdfvcbgtyhnmjuik,.lop[';]\\\"21qazsedrWQA");



//		int parts = 57;

//		int basis = sb.Length / parts;

//		int residue = sb.Length % parts;



//		Console.WriteLine("parts = {0}\nbasis = {1}\nresidue = {2}", parts, basis, residue);

//		if (sb.Length / parts > 0)

//		{

//			sbresult.Insert(0, sb.ToString((parts - 1) * basis, basis + residue));

//			sbresult.Insert(0, ' ');

//		}



//		for (int i = parts - 2; i >= 0; i--)

//		{

//			sbresult.Insert(0, sb.ToString(i * basis, basis));

//			sbresult.Insert(0, ' ');

//		}

//		sb.Clear();

//		sb.Append(sbresult.ToString().TrimStart());

//		Console.WriteLine(sb);



//	}

//}
//The Anonymous have created a cyber hypervirus, which steals data from the CIA. You, as the lead security developer in CIA, have been tasked to analyze the software of the virus and observe its actions on the data. The virus is known for his innovative and unbeleivably clever technique of merging and dividing data into partitions. 
//You will receive a single input line, containing strings, separated by spaces. The strings may contain any ASCII character except whitespace.Then you will begin receiving commands in one of the following formats:
//•	merge
//{ startIndex}
//{ endIndex}
//•	divide
//{ index}
//{ partitions}
//Every time you receive the merge command, you must merge all elements from the startIndex, till the endIndex. In other words, you should concatenate them. 
//Example: { abc, def, ghi} -> merge 0 1-> { abcdef, ghi}
//If any of the given indexes is out of the array, you must take only the range that is inside the array and merge it.
//Every time you receive the divide command, you must divide the element at the given index, into several small substrings with equal length. The count of the substrings should be equal to the given partitions. 
//Example: { abcdef, ghi, jkl} -> divide 0 3-> { ab, cd, ef, ghi, jkl}
//If the string cannot be exactly divided into the given partitions, make all partitions except the last with equal lengths, and make the last one – the longest. 
//Example: { abcd, efgh, ijkl} -> divide 0 3-> { a, b, cd, efgh, ijkl}
//The input ends when you receive the command “3:1”. At that point you must print the resulting elements, joined by a space.
//Input
//•	The first input line will contain the array of data.
//•	On the next several input lines you will receive commands in the format specified above.
//•	The input ends when you receive the command "3:1".
//Output
//•	As output you must print a single line containing the elements of the array, joined by a space.
//Constrains
//•	The strings in the array may contain any ASCII character except whitespace.
//•	The startIndex and the endIndex will be in range [-1000, 1000].
//•	The endIndex will always be greater than the startIndex.
//•	The index in the divide command will always be inside the array.
//•	The partitions will be in range [0, 100].
//•	Allowed working time/memory: 100ms / 16MB.
//Анонимните са създали кибер-вирус, който краде данни от ЦРУ.
//Вие, като водещ разработчик на сигурността в ЦРУ, сте били натоварени да анализирате софтуера на вируса и да наблюдавате неговите действия по отношение на данните.
//Вирусът е известен с иновативната си и неблоядна интелигентна техника за сливане и разделяне на данни на дялове.
//Ще получите един входен ред, съдържащ низове, разделени с интервали.
//Низовете може да съдържат произволен ASCII знак, освен в празно пространство. След това ще започнете да получавате команди в един от следните формати:
//•         обединяване
//{ началоIndex}
//{ крайиндекс}
//•         раздели
//{ index}
//{ дялове}
//Всеки път, когато получите командата за сливане, трябва да обедините всички елементи от стартовата команда , докато свършите. С други думи, трябва да ги свържем.
//Пример: { abc, def, ghi} -> обединяване 0 1-> { abcdef, ghi}
//Ако някой от дадените индекси е извън масива, трябва да вземете само диапазона, който е в масива и да го обедините.
//Всеки път , когато получите командатаза разделение, трябва да разделите елемента от дадения индексна няколко малки подни, с еднаква дължина.
//Броят на подниз трябва да бъде равен на дадените дялове.
//Пример: { abcdef, ghi, jkl} -> разделят 0 3-> { ab, cd, ef, ghi, jkl}
//Ако низът не може да бъде разделен точно на дадените дялове, направете всички дялове с еднаква дължинаи направете последната – най-дългата.
//Пример: { abcd, efgh, ijkl} -> разделят 0,3-> { a, b, cd, efgh, ijkl}
//Входът завършва, когато получите командата "3:1". В този момент трябва да отпечатате получените елементи, съединени от интервал.
//въвеждане
//•         Първият ред за въвеждане ще съдържа масив от данни.
//•         В следващите няколко входни линии ще получите команди във формата, посочен по-горе.
//•         Входът приключва, когато получите командата "3:1 ".
//изход
//•         Като изход трябва да отпечатате един ред, съдържащ елементите на масива, съединени от интервал.
//Ограничения
//•         Низовете в масива може да съдържат произволен ASCII знак, освен в празно пространство.
//•         The startIndex и краятindex ще бъдат в диапазона [-1000, 1000].
//•         Крайнатаindex винаги ще бъде по-голяма от .
//•         Индексът в командата за разделяне винаги ще бъде в масива.
//•         Дяловете ще бъдат в обхват [0, 100].
//•         Позволено работно време/памет: 100ms / 16MB.
