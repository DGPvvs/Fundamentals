using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P_rates
{
	public class Town
	{
		public Town()
		{

		}// Town()

		public Town(string newTownName, int newTownPopulation, int newTownGold)
		{
			this.TownName = newTownName;
			this.TownPopulation = newTownPopulation;
			this.TownGold = newTownGold;
		}// Town(string newTownname, int newTownPopulation, int newTawnGold)

		public string TownName { get; set; }
		public int TownPopulation { get; set; }
		public int TownGold { get; set; }
	}// class Town

	class PIrates
	{
		static void Main(string[] args)
		{
			List<Town> towns = new List<Town>();
			StringBuilder sb = new StringBuilder();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("sail"))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = sb.ToString().Split("||", StringSplitOptions.RemoveEmptyEntries);

					Town town = towns.FirstOrDefault(town => town.TownName == input[0]);

					if (town == null)
					{
						towns.Add(new Town(input[0], int.Parse(input[1]), int.Parse(input[2])));
					}
					else
					{
						town.TownPopulation += int.Parse(input[1]);
						town.TownGold += int.Parse(input[2]);
					}
					
				}
			}

			isExitLoop = false;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("end"))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = sb.ToString().Split("=>", StringSplitOptions.RemoveEmptyEntries);

					string command = input[0];
					string townName = input[1];

					Town town = towns.FirstOrDefault(t => t.TownName == townName);

					switch (command.ToLower())
					{
						case "plunder":							
							int people = int.Parse(input[2]);
							int gold = int.Parse(input[3]);
							
							town.TownPopulation -= people;
							town.TownGold -= gold;

							Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

							if ((town.TownPopulation <= 0) || (town.TownGold <= 0))
							{
								towns.Remove(town);
								Console.WriteLine($"{townName} has been wiped off the map!");
							}
							break;
						case "prosper":
							gold = int.Parse(input[2]);

							if (gold >= 0)
							{
								town.TownGold += gold;

								Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {town.TownGold} gold.");
							}
							else
							{
								Console.WriteLine("Gold added cannot be a negative number!");
							}
							break;
						default:
							break;
					}
				}
			}

			sb.Clear();
			if (towns.Count <= 0)
			{
				sb.Append("Ahoy, Captain! All targets have been plundered and destroyed!");				
			}
			else
			{
				//towns = towns.OrderByDescending(gold => gold.TownGold).ThenBy(name => name.TownName).ToList();

				sb.AppendLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

				foreach (Town item in towns)
				{
					sb.AppendLine($"{item.TownName} -> Population: {item.TownPopulation} citizens, Gold: {item.TownGold} kg");
				}
			}

			Console.WriteLine(sb.ToString());
		}
	}
}
//Anno 1681.The Caribbean.The golden age of piracy. You are a well-known pirate captain by the name of Jack… Daniels. Together with your comrades Jim (Beam) and Johnny(Walker) you have been roaming the seas, looking for gold and treasure… and the occasional killing, of course. Go ahead, target some wealthy settlements and show them the pirate`s way!
//Description
//Until the "Sail" command is given you will be receiving:
//•	Cities that you and your crew have targeted, with their population and gold, separated by "||".
//•	If you receive a city which has been already received, you have to increase the population and gold with the given values.
//After the "Sail" command, you will start receiving lines of text representing events until the "End" command is given. 
//Events will be in the following format:
//•	"Plunder=>{town}=>{people}=>{gold}"
//o You have successfully attacked and plundered the town, killing the given number of people and stealing the respective amount of gold. 
//o	For every town you attack print this message: "{town} plundered! {gold} gold stolen, {people} citizens killed."
//o If any of those two values (population or gold) reaches zero, the town is disbanded.
//	You need to remove it from your collection of targeted cities and print the following message: "{town} has been wiped off the map!"
//o There will be no case of receiving more people or gold than there is in the city.
//•	"Prosper=>{town}=>{gold}"
//o	There has been a dramatic economic growth in the given city, increasing its treasury by the given amount of gold.
//o	The gold amount can be a negative number, so be careful. If a negative amount of gold is given print: "Gold added cannot be a negative number!" and ignore the command.
//o	If the given gold is a valid amount, increase the town's gold reserves by the respective amount and print the following message: "{gold added} gold added to the city treasury. {town} now has {total gold} gold."
//Input
//•	On the first lines, until the "Sail" command, you will be receiving strings representing the cities with their gold and population, separated by "||"
//•	On the next lines, until the "End" command, you will be receiving strings representing the actions described above, separated by "=>"
//Output
//•	After receiving the "End" command if there are any existing settlements on your list of targets, you need to print all of them, sorted by their gold in descending order, then by their name in ascending order, in the following format:
//Ahoy, Captain! There are { count }
//wealthy settlements to go to:
//{ town1} -> Population: { people}
//citizens, Gold: { gold}
//kg
//   …
//{ town…n} -> Population: { people}
//citizens, Gold: { gold}
//kg
//•	If there are no settlements left to plunder, print:
//"Ahoy, Captain! All targets have been plundered and destroyed!"
//Constraints
//•	The initial population and gold of the settlements will be valid, 32-bit integers,
//will never be negative or exceed the respective limits.
//•	The town names in the events will always be valid towns that should be on your list.
//1681. Карибите. Златният век на пиратството. Ти си добре известен пиратски капитан на име Джак... Маринова. Заедно с вашите другари Джим (Бийм) и Джони(Уокър) вие сте били скитат морета, търсейки злато и съкровище ... и случайните убийства, разбира се. Давай, насочете се към някои богати селища и да им покаже пътя на пирата!
//Описание
//Докато не бъде дадена команда "Sail" ще получите:
//•         Градовете, към които вие и вашият екипаж сте насочили, с тяхното население и злато, разделени "||".
//•         Ако получите град, който вече е бил приет, трябва да увеличите населението и златото с дадените стойности.
//След командата "Sail" ще започнете да получавате редове текст, представляващи събития, докато командата "Край" не бъде дадена.
//Събитията ще бъдат в следния формат:
//•         "Грабеж=>{град}=>{населени места}=>{gold}"
//o Вие успешно нападат и ограбили града, убивайки дадения брой хора и крадат съответното количество злато.
//o За всеки град, който атакуват печат това съобщение: "{град} ограбен! {злато} злато откраднато, {people} граждани убити."
//o Ако някоя от тези две стойности (население или злато) достигне нула, градът се разпуска.
//  Трябва да го премахнете от колекцията си от целеви градове и да отпечатате следното съобщение: "{town} е бил изтрит от картата!"
//o Няма да има случай на получаване на повече хора или злато, отколкото в града.
//•         "Проспер=>{град}=>{gold}"
//o Налице е драматичен икономически растеж в даденияград, увеличавайки своята хазна с определена сума злато.
//o Златото може да бъде отрицателно число, така че бъдете внимателни. Ако е отпечатано отрицателно количество злато: "Добавеното злато не може да е отрицателно число!" и игнорира командата.
//o Ако даденото злато е валидна сума, увеличете златните резерви на града със съответната сума и отпечатайте следното съобщение: "добавеното към градските хазна злато е добавено към златото. {град} сега има {злато} злато."
//Въвеждане
//•         На първите редове, до командата "Sail" ще получавате струни, представляващи градовете с тяхното злато и население, разделени от"||"
//•         На следващите редове, до командата "Край" ще получавате низове, представляващи действията, описани по-горе, разделени от"=>"
//Изход
//•         След получаване на командата "Край", ако има съществуващи населени места във вашия списък с цели, трябва да ги отпечатате всички, подредени по тяхното злато в низходящ ред, след това по името им във възходящ ред, в следния формат:
//-Капитане, какво е това? Има {брой} богати селища, за да отидете на:
//{ town1} -> Население: { хора}
//граждани, Злато: { gold}
//кг...
//-Не, не, n} -> Население: граждани на { хора}, Злато: { gold}
//kg
//•         Ако няма останали населени места, за да плячкосвате, принт:
//"Ахо, капитане! Всички цели са били ограбени и унищожени!"
//Ограничения
//•         Първоначалната популация и златото на населените места ще бъдат валидни, 32-битови цели числа,
//никога няма да бъде отрицателно или да надвишава съответните граници.
//•         Имената на градовете в събитията винаги ще бъдат валидни градове, които трябва да бъдат в списъка ви.
