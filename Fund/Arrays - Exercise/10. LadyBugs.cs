using System;
using System.Linq;
using System.Text;

namespace LadyBugs
{
	class LadyBugs
	{
		static void MoveLadyBugs(ref int[] arr, int index, int offset)
		{
			int newIndex = index + offset;
			bool isNotFlownAway = ((newIndex >= 0) && (newIndex < arr.Length));
			
			if (isNotFlownAway)
			{
				if (arr[newIndex] != 0)
				{
					MoveLadyBugs(ref arr, newIndex, offset);
				}
				else
				{
					arr[newIndex] = 1;
				}
			}
		}

		static void Main(string[] args)
		{
			int[] fieldSize = new int[int.Parse(Console.ReadLine())];
			
			int[] arrIndex = Console.ReadLine()
			    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
			    .Select(int.Parse).ToArray();

			foreach (int item in arrIndex)
			{
				if ((item >= 0) && (item < fieldSize.Length))
				{
					fieldSize[item] = 1;
				}
			}		
			
			bool isExitLoop = false;
			int index = 0;
			int offset = 0;

			while (!isExitLoop)
			{
				string command = Console.ReadLine();
				
				if (command.ToLower().Equals("end"))
				{
					isExitLoop = true;
				}
				else
				{
                  	string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					index = int.Parse(input[0]);
					offset = int.Parse(input[2]);
					string direction = input[1];
					
					if (direction.ToLower().Equals("left"))
					{
						offset *= (-1);
					}

					bool isLadyBugsExist = ((index >= 0) && (index <= fieldSize.Length - 1) && (fieldSize[index].Equals(1)));

					if (isLadyBugsExist)
					{
						fieldSize[index] = 0;
						MoveLadyBugs(ref fieldSize, index, offset);
					}					
				}
			}
			Console.WriteLine(String.Join(" ", fieldSize));
		}
	}
}
//You are given a field size and the indexes of ladybugs inside the field.
//After that on every new line until the "end" command is given, a ladybug changes its position either to its left or to its right by a given fly length. 
//A command to a ladybug looks like this: "0 right 1".This means that the little insect placed on index 0 should fly one index to its right. If the ladybug lands on a fellow ladybug, it continues to fly in the same direction by the same fly length. If the ladybug flies out of the field, it is gone.
//For example, imagine you are given a field with size 3 and ladybugs on indexes 0 and 1. If the ladybug on index 0 needs to fly to its right by the length of 1 (0 right 1) it will attempt to land on index 1 but as there is another ladybug there it will continue further to the right by additional length of 1, landing on index 2. After that, if the same ladybug needs to fly to its right by the length of 1 (2 right 1), it will land somewhere outside of the field, so it flies away:
//If you are given ladybug index that does not have ladybug there, nothing happens. If you are given ladybug index that is outside the field, nothing happens. 
//Your job is to create the program, simulating the ladybugs flying around doing nothing. At the end, print all cells in the field separated by blank spaces. For each cell that has a ladybug on it print '1' and for each empty cells print '0'. For the example above, the output should be '0 1 0'. 
//Input
//•	On the first line you will receive an integer - the size of the field
//•	On the second line you will receive the initial indexes of all ladybugs separated by a blank space. The given indexes may or may not be inside the field range
//•	On the next lines, until you get the "end" command you will receive commands in the format: "{ladybug index} {direction} {fly length}"
//Output
//•	Print the all cells within the field in format: "{cell} {cell} … {cell}"
//o If a cell has ladybug in it, print '1'
//o	If a cell is empty, print '0' 
//Constrains
//•	The size of the field will be in the range [0 … 1000]
//•	The ladybug indexes will be in the range [-2,147,483,647 … 2,147,483,647]
//•	The number of commands will be in the range [0 … 100] 
//•	The fly length will be in the range [-2,147,483,647 … 2,147,483,647]
//В полето ви се дава размер на полето и индексите на калинките.
//След това на всеки нов ред до командата "край" се променя позицията си наляво или надясно с определена дължина на мухата.
//Командата към калинка изглежда така: "0 надясно 1".Това означава, че малкото насекомо, поставено на индекс 0, трябва да лети един индекс вдясно.
//Ако калинката се приземи на друга калинка, тя продължава да лети в същата посока със същата дължина на мухата. Ако калинката излети от полето, тя е изчезнала.
//Например, представете си, че ви се дава поле с размер 3 и калинки на индекси 0 и 1.
//Ако калинката на индекс 0 трябва да лети надясно до 1 (0 десен 1), ще се опита да се приземи на индекс 1,
//но тъй като там има още една калинка, тя ще продължи още повече надясно с допълнителна дължина 1, кацане на индекс 2.
//След това, ако същата калинка трябва да лети до дясната си с дължина 1 (2 десен 1), тя ще се приземи някъде извън полето, така че ще отлети:
 
//Ако ви се даде индекс на калинка, който не разполага с калинка там, нищо не се случва. Ако ви е даден индекс на калинка, който е извън полето, нищо не се случва.
//Вашата работа е да създадете програмата, симулирайки калинки летящи наоколо не правят нищо. Накрая отпечатайте всички клетки в полето, разделени с празни интервали. За всяка клетка, която има калинка, отпечатва "1" и за всяка празна клетка се отпечатва '0'. За примера по-горе, изходът трябва да бъде "0 1 0".
//въвеждане
//•         На първия ред ще получите цяло число - размерът на полето
//•         На втория ред ще получите началните индекси на всички калинки, разделени от празно пространство. Дадените индекси може да са или не в диапазона на полетата
//•         На следващите редове, докато не получите командата "край" ще получавате команди във формат: "{индекс на калинка} {посока} {дължина на муха} {дължина на муха}"
//изход
//•         Отпечатайте всички клетки в полето във формат: "{клетка} {клетка} ... {клетка}"
//o Ако в клетката има калинка, отпечатайте
//o Ако клетката е празна, отпечатайте "0"
//Ограничения
//•         Размерът на полето ще бъде в диапазона [0 ... 1000]
//•         Калинката ще бъде в диапазона [-2,147,483,647 ... 2,147,483,647]
//•         Броят на командите ще бъде в диапазона [0 ... 100]
//•         Дължината на мухата ще бъде в диапазона [-2,147,483,647 ... 2,147,483,647]
