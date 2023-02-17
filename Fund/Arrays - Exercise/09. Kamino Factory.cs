using System;
using System.Linq;
using System.Text;

namespace Kamino_Factory
{
	class KaminoFactory
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			StringBuilder bestsb = new StringBuilder();
			StringBuilder swapsb = new StringBuilder();

			int num = int.Parse(Console.ReadLine());

			bool isLoopExit = false;
			int bestCounter = 0;
			int counter = 0;
			int bestIndex = num + 1;
			int bestSum = 0;
			int bestCount = 0;

			while (!isLoopExit)
			{
				sb.Clear();

				int indexDNA = 0;
				int countDNA = 0;
				int currentSum = 0;

				if (sb.Append(Console.ReadLine()).ToString().ToLower() == "clone them!")
				{
					isLoopExit = true;
				}
				else
				{					
					int[] arr = sb.ToString().Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
					
					counter++;

					for (int i = 0; i < num; i++)
					{
						currentSum += arr[i];
					}					
					
					int p = arr[0];
					int currentCounterDNA = 1;
					int currentIndexDNA = 0;

					for (int j = 1; j < num; j++)
					{
						if (arr[j] == p)
						{
							currentCounterDNA++;
						}
						else if (currentCounterDNA > countDNA)
						{
							indexDNA = currentIndexDNA;
							countDNA = currentCounterDNA;
							p = arr[j];
							currentCounterDNA = 1;
							currentIndexDNA = j;
						}
						else
						{
							currentCounterDNA = 1;
							p = arr[j];
							currentIndexDNA = j;
						}
					}

					if (currentCounterDNA > countDNA)
					{
						indexDNA = currentIndexDNA;
						countDNA = currentCounterDNA;
					}
										
					swapsb.Clear();
					swapsb.Append($"{string.Join(" ", arr)}");
					
				}

				if (!isLoopExit)
				{
					if (bestIndex > indexDNA)
					{
						bestIndex = indexDNA;
						bestSum = currentSum;
						bestCounter = countDNA;
						bestCount = counter;
						bestsb.Clear();
						bestsb.Append(swapsb.ToString());
					}
					else if (bestIndex == indexDNA)
					{
						if (bestCounter < countDNA)
						{
							bestIndex = indexDNA;
							bestSum = currentSum;
							bestCounter = countDNA;
							bestCount = counter;
							bestsb.Clear();
							bestsb.Append(swapsb.ToString());
						}
						else if (bestCounter == countDNA)
						{
							if (bestSum < currentSum)
							{
								bestIndex = indexDNA;
								bestSum = currentSum;
								bestCounter = countDNA;
								bestCount = counter;
								bestsb.Clear();
								bestsb.Append(swapsb.ToString());
							}
						}
					}
				}
				
			}//while (!isLoopExit)

			if (num != 0)
			{
				Console.WriteLine($"Best DNA sample {bestCount} with sum: {bestSum}.\n{bestsb.ToString()}");
			}
		}
	}
}
//The clone factory in Kamino got another order to clone troops. But this time you are tasked to find the best DNA sequence to use in the production. 
//You will receive the DNA length and until you receive the command "Clone them!" you will be receiving a DNA sequences of ones and zeroes, split by "!" (one or several).
//You should select the sequence with the longest subsequence of ones. If there are several sequences with same length of subsequence of ones, print the one with the leftmost starting index,
//if there are several sequences with same length and starting index, select the sequence with the greater sum of its elements.
//After you receive the last command "Clone them!" you should print the collected information in the following format:
//"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
//"{DNA sequence, joined by space}"
//Input / Constraints
//•	The first line holds the length of the sequences – integer in range [1…100];
//•	On the next lines until you receive "Clone them!" you will be receiving sequences (at least one) of ones and zeroes, split by "!" (one or several).
// Output
//The output should be printed on the console and consists of two lines in the following format:
//"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
//"{DNA sequence, joined by space}"
//	Клонинг фабриката в Камино има друга заповед да клонира войски. Но този път сте натоварени да намерите най-добрата ДНК последователност, която да използвате в производството.
//Ще получите ДНК дължина и докато получите командата "Клониране ги!" ще получите ДНК последователности от тези и нули, разделени на "!" (един или няколко).
//Трябва да изберете последователността с най-дългата подсектовност на тези. Ако има няколко последователности с еднаква дължина на подсектора , отпечатайте тази с най-левия старт ,
//ако има няколко последователности с еднаква дължина и начален индекс, изберете последователността с по-голямата сума от нейните елементи.
//След като получите последната команда "Клонирай ги!" трябва да отпечатате събраната информация в следния формат:
//"Най-добра ДНК проба {bestSequenceIndex} с сума: {най-добърсекленютюм}."
//"{ДНК последователност, съединена от интервал}"
//Вход / Ограничения
//•       Първият ред държи дължината на поредиците – цяло число в диапазона [1... 100]
//•         На следващите редове, докато не получите "Клониране на тях!" ще получавате последователности (поне една) от тях и нули, разделени на "!" (един или няколко).
// изход
//Изходът трябва да бъде отпечатан на конзолата и се състои от два реда в следния формат:
//"Най-добра ДНК проба {bestSequenceIndex} с сума: {най-добърсекленютюм}."
//"{ДНК последователност, съединена от интервал}"
