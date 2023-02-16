using System;
using System.Linq;
using System.Text;

namespace Heart_Delivery
{
	class HeartDelivery
	{
		static void Main(string[] args)
		{
			int[] neighborhood = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

			int curentIndex = 0;
			int currentGoal = 0;

			bool isExitLoop = false;
			StringBuilder sb = new StringBuilder();

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("love!"))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = sb.ToString().Split();
					int step = int.Parse(input[1]);
					string command = input[0];

					if (command.ToLower().Equals("jump"))
					{
						curentIndex += step;
						if (curentIndex >= neighborhood.Length)
						{
							curentIndex = 0;
						}
												
						if (neighborhood[curentIndex] > 0)
						{
							neighborhood[curentIndex] -= 2;
							if (neighborhood[curentIndex] == 0)
							{
								Console.WriteLine($"Place {curentIndex} has Valentine's day.");
								currentGoal++;
							}
						}
						else
						{
							Console.WriteLine($"Place {curentIndex} already had Valentine's day.");
						}
					}
				}
			}// while (!isExitLoop)

			Console.WriteLine($"Cupid's last position was {curentIndex}.");
			if (currentGoal == neighborhood.Length)
			{
				Console.WriteLine("Mission was successful.");
			}
			else
			{
				Console.WriteLine($"Cupid has failed {neighborhood.Length - currentGoal} places.");
			}
		}
	}
}
//Valentine’s Day is coming, and Cupid has very limited time to spread some love across the neighborhood. Help him with his mission!
//You will receive a string with even integers, separated by a "@". This is our neighborhood. After that a series of Jump commands will follow, until you receive "Love!" Every house in the neighborhood needs a certain number of hearts delivered by Cupid, in order to be able to celebrate Valentine’s Day. Those needed hearts are indicated by the integers in the neighborhood.
//Cupid starts at the position of the first house (index 0) and must jump by a given length. The jump commands will be in this format: "Jump {length}".
//Every time he jumps from one house to another, the needed hearts for the visited house are decreased by 2. If the needed hearts for a certain house become equal to 0 , print on the console "Place {houseIndex} has Valentine's day." If Cupid jumps to a house where the needed hearts are already 0, print on the console "Place {houseIndex} already had Valentine's day.".
//Keep in mind that Cupid can have a bigger jump length than the size of the neighborhood and if he does jump outside of it, he should start from the first house again. 
//For example, we are given this neighborhood: 6@6@6.Cupid is at the start and jumps with a length of 2. He will end up at index 2 and decrease the needed hearts there by 2: [6, 6, 4]. Next he jumps again with a length of 2 and goes outside the neighborhood, so he goes back to the first house (index 0) and again decreases the needed hearts there: [4, 6, 4].
//Input
//•	On the first line you will receive a string with even integers separated by "@" – the neighborhood and the number of hearts for each house.
//•	On the next lines, until "Love!" is received, you will be getting jump commands in this format: "Jump {length}".
//Output
//At the end print Cupid's last position and whether his mission was successful or not:
//•	"Cupid's last position was {lastPositionIndex}."
//•	If each house has had a Valentine's day, print: 
//o	"Mission was successful."
//•	If not, print the count of all houses that didn`t celebrate a Valentine's Day:
//o	"Cupid has failed {houseCount} places."
//Constraints
//•	The neighborhood`s size will be in the range [1…20]
//•	Each house will need an even number of hearts in the range [2 … 10]
//•	Each jump length will be an integer in the range [1 … 20]
//Валентин 'S ден идва, и Купидон има много ограничен период от време, за да се разпространи някаква любов в квартала. Помогнете му с мисията си!
//Ще получите низ с дори цели числа,, разделени с "@". Това е нашият квартал.
//След това ще последва поредица от jump команди, докато не получите "Любов!"
//Всяка къща в квартала се нуждае от определен брой сърца, доставени от Купидон, за да може да празнува Деня на влюбените.
//Тези, които са необходими сърца са посочени от цели числа в квартала.
//Купидонът започва от позицията на първата къща (индекс 0) и трябва да скочи по определена дължина.
//Командите за прескачане ще бъдат в следния формат: "Прескачане {дължина}".
//Всеки път, когато той скочи от една къща в друга, необходимите сърца за посетената къща се понижават с 2.
//Ако необходимите сърца за определена къща станат равни на 0 , печат на конзолата "Place {houseIndex} има Свети Валентин."
//Ако Купидон скочи в къща, където необходимите сърца вече са 0, принт върху конзолата "Място{houseIndex} вече имаше Свети Валентин. ".
//Имайте предвид, че Купидон може да има по-голяма дължина на скока от размера на квартала и ако той наистина скочи извън него, той трябва да започне отново от първата къща.
//Например, ние имаме този квартал: 6@6@6.Купидон е в началото и скача с дължина 2.
//Той ще се окаже на индекс 2 и ще намали нужните сърца там с 2: [6, 6, 4].
//След това той отново скача с дължина 2 и излиза извън квартала, така че той се връща към първата къща (индекс 0) и отново намалява необходимите сърца там: [4, 6, 4].
//Въвеждане
//•         На първия ред ще получите низ с дори цели числа, разделени с "@" – кварталът и броят на сърцата за всяка къща.
//•         На следващите редове, докато не се получи "Любовта!"ще получите команди за скок в този формат: "Прескачане {дължина} ".
//Изход
//На последната позиция на Купидон и дали мисията му е била успешна или не:
//•         "Последната позиция на Cupid е {последнопозиция}."
//•         Ако всяка къща е имала Свети Валентин, принт:
//Мисията е успешна.
//•         Ако не, отпечатайте броя на всички къщи, които не празнуват Свети Валентин:
//o "Купидон е неуспешно {houseCount} места."
//Ограничения
//•         Размерът на квартала ще бъде в диапазона [1... 20% от
//•         Всяка къща ще се нуждае от четен брой сърца в диапазона [2 ... 10]
//•         Дължината на всеки скок ще бъде цяло число в диапазона [1 ... 20]
