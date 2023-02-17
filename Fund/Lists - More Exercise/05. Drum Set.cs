using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drum_Set
{
	class DrumSet
	{
		static void Main(string[] args)
		{

			decimal savings = decimal.Parse(Console.ReadLine());

			List<int> drumList = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();

			List<int> copyDrumList = new List<int> (drumList);

			StringBuilder hitPower = new StringBuilder();

			bool isloopExit = false;

			while (!isloopExit)
			{
				hitPower.Clear();
				if (hitPower.Append(Console.ReadLine()).ToString() == "Hit it again, Gabsy!")
				{
					isloopExit = true;
				}
				else
				{
					int currentPower = int.Parse(hitPower.ToString());					

					for (int i = 0; i < drumList.Count; i++)
					{
						drumList[i] -= currentPower;
						if (drumList[i] <= 0)
						{
							if (savings >= copyDrumList[i] * 3)
							{
								drumList[i] = (int)copyDrumList[i];
								savings -= copyDrumList[i] * 3M;
							}
							else
							{
								copyDrumList[i] = 0;
							}
						}
					}

					for (int i = copyDrumList.Count - 1; i >= 0; i--)
					{
						if (copyDrumList[i] == 0)
						{
							drumList.RemoveAt(i);
							copyDrumList.RemoveAt(i);
						}
					}
				}
			}

			Console.WriteLine($"{string.Join(' ', drumList)}\nGabsy has {savings:F2}lv.");
		}
	}
}
//Gabsy is Orgolt's Final Revenge charming drummer. She has a drum set but the different drums have different origins – some she bought, some are gifts, so they are all with different quality. Every day she practices on each of them, so she does damage and reduces the drum`s quality. Sometimes a drum brakes, so she needs to buy new one. Help her keep her drum set organized.
//You will receive Gabsy's savings, the money she can spend on new drums. Next you will receive a sequence of integers, which represents the initial quality of each drum in Gabsy's drum set.
//Until you receive the command "Hit it again, Gabsy!", you will be receiving an integer: the hit power Gabsy applies on each drum, while practicing. When the power is applied, you should decrease the value of the drum's quality with the current power.
//When a certain drum reaches 0 quality, it breaks. Then Gabsy should buy a replacement. She needs to buy the exact same model. Therefore, its quality will be the same as the initial quality of the broken drum. The price is calculated by the formula: { initialQuality}*3.
//Gabsy will always replace her broken drums until the moment she can no longer afford it. If she doesn't have enough money for a replacement, the broken drum is removed from the drum set.
//When you receive the command "Hit it again, Gabsy!", the program ends and you should print the current state of the drum set. On the second line you should print the remaining money in Gabsy's savings account.
//Input
//•	On the first line you will receive the savings – a floating-point number.
//•	On the second line you will recieve the drum set: a sequence of integers, separated by spaces.
//•	Until you receive the command "Hit it again, Gabsy!", you will be receiving integers – the hit power Gabsy applies on each drum.
//Output
//•	On the first line you should print each drum in the drum set, separated by space.
//•	Then you must print the money that are left on the second line in the format "Gabsy has {money left}lv.", formatted with two digits after the decimal point.
//Constraints
//•	The savings – a floating-point number in the range [0.00, 10000.00]
//•	The quality of each drum in the drum set – an integer in the range [1, 1000].
//•	The hit power will be in the range [0, 1000]
//•	Allowed working time / memory: 100ms / 16MB.
//	Габи е чаровен барабанист на Орголд. Тя има барабан, но различните барабани имат различен произход – някои, които е купила, някои са подаръци, така че всички те са с различно качество. Всеки ден практикува на всеки от тях, така че нанася щети и намалява качеството на барабана. Понякога барабанни спирачки, така че тя трябва да си купи нова. Помогнете й да я запази барабана си определени организирани.
//Ще получите спестяваниятана Габи, парите, които тя може да похарчи за нови барабани. След това ще получите последователност от цели числа, която представлява първоначалното качество на всеки барабан в барабана на Габи.
//Докато не получите командата "Удари отново, Габи!" , ще получавате цяло число: хит мощността, която Габи прилага за всеки барабан, докато се упражнява. Когато се прилага захранването, трябва да намалите стойността на качеството на барабана с текущата мощност.
//Когато определен барабан достигне 0 качество, той се разпада. Тогава Габи трябва да си купи заместник. Тя трябва да купи същия модел. Следователно, качеството му ще бъде същото като първоначалното качество на счупения барабан. Цената се изчислява по формулата: { initialQuality}*3.
//Габи винаги ще сменя счупените си барабани до момента, в който вече не може да си го позволи. Ако тя няма достатъчно пари за подмяна, счупеният барабан се отстранява от барабана.
//Когато получите командата "Удари отново, Габи!" , , програмата завършва и трябва да отпечатате текущото състояние на барабана. На втория ред трябва да отпечатате останалите пари в спестовната сметка на Габи.
//въвеждане
//•         На първия ред ще получите спестяванията – число с плаваща запетая.
//•         На втория ред ще получите комплекта барабани: поредица от цели числа, разделени с интервали.
//•         Докато не получите командата "Удари отново, Габи!"!" , ще получавате цели числа - хит мощност Габи се прилага за всеки барабан.
//изход
//•         На първия ред трябва да отпечатате всеки барабан в комплекта барабани, разделени с интервал.
//•         След това трябва да отпечатате парите, които са оставени на втория ред във формат "Габи има {пари оставени}lv." , форматиран с две цифри след десетичната точка.
//Ограничения
//•         Спестяванията – число с плаваща запетая в диапазона [0.00, 10000.00]
//•         Качеството на всеки барабан в барабана – цяло число в диапазона [1, 1000].
//•         То ще бъде в диапазона [0, 1000]
//•         Позволено работно време / памет: 100ms / 16MB.
