using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes_of_Code_and_Logic_VII
{
	public class Hero
	{
		public Hero()
		{

		}// Hero()

		public Hero(string newHeroName, int newHeroHitPoint, int newHeroManaPoint)
		{
			this.HeroName = newHeroName;
			this.HeroHitPoint = newHeroHitPoint;
			this.HeroManaPoint = newHeroManaPoint;
		}// Hero(string newHeroName, int newHeroHitPoint, int newHeroManaPoint)

		private int heroHitPoint;
		private int heroManaPoint;

		public string HeroName { get; set; }

		public int HitPointDiff { get; set; }
		public int ManaPointDiff { get; set; }

		public int HeroHitPoint
		{
			get
			{
				return heroHitPoint;
			}

			set
			{
				int hp = 100 - value;
				if (hp < 0)
				{
					HitPointDiff = 100 - heroHitPoint;
					heroHitPoint = 100;
				}
				else
				{
					HitPointDiff = value - heroHitPoint;
					heroHitPoint = value;
				}				
			}
		}
			
		public int HeroManaPoint
		{
			get
			{
				return heroManaPoint;
			}

			set
			{
				int mp = 200 - value;
				if (mp < 0)
				{
					ManaPointDiff = 200 - heroManaPoint;
					heroManaPoint = 200;
				}
				else
				{
					ManaPointDiff = value - heroManaPoint;
					heroManaPoint = value;
				}
			}
		}
	}// class Hero

	class HeroesofCodeandLogicVII
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<Hero> heroes = new List<Hero>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string name = input[0];
				int HP = int.Parse(input[1]);
				int MP = int.Parse(input[2]);

				Hero hero = heroes.FirstOrDefault(heroName => heroName.HeroName.Equals(name));

				if (hero == null)
				{
					heroes.Add(new Hero(name, HP, MP));
				}
				else
				{
					hero.HeroHitPoint += HP;
					hero.HeroManaPoint += MP;
				}
			}

			bool isLoopExit = false;

			while (!isLoopExit)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("end"))
				{
					isLoopExit = true;
				}
				else
				{
					string[] input = sb.ToString().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
					string command = input[0];
					string heroName = input[1];

					Hero hero = heroes.FirstOrDefault(name => name.HeroName.Equals(heroName));
					if (hero != null)
					{
						switch (command.ToLower())
						{
							case "castspell":
								int mpNeed = int.Parse(input[2]);
								string spellName = input[3];
								if (mpNeed <= hero.HeroManaPoint)
								{
									hero.HeroManaPoint -= mpNeed;
									Console.WriteLine($"{hero.HeroName} has successfully cast {spellName} and now has {hero.HeroManaPoint} MP!");
								}
								else
								{
									Console.WriteLine($"{hero.HeroName} does not have enough MP to cast {spellName}!");
								}
								break;
							case "takedamage":
								int damage = int.Parse(input[2]);
								string attacker = input[3];
								if (hero.HeroHitPoint > damage)
								{
									hero.HeroHitPoint -= damage;
									Console.WriteLine($"{hero.HeroName} was hit for {damage} HP by {attacker} and now has {hero.HeroHitPoint} HP left!");
								}
								else
								{
									Console.WriteLine($"{hero.HeroName} has been killed by {attacker}!");
									heroes.Remove(hero);
								}
								break;
							case "recharge":
								int amount = int.Parse(input[2]);
								hero.HeroManaPoint += amount;
								Console.WriteLine($"{hero.HeroName} recharged for {hero.ManaPointDiff} MP!");
								break;
							case "heal":
								amount = int.Parse(input[2]);
								hero.HeroHitPoint += amount;
								Console.WriteLine($"{hero.HeroName} healed for {hero.HitPointDiff} HP!");
								break;
							default:
								break;
						}
					}
				}
			}

			sb.Clear();
			foreach (Hero hero in heroes)
			{
				sb
				    .AppendLine(hero.HeroName)
				    .AppendLine($"  HP: {hero.HeroHitPoint}")
				    .AppendLine($"  MP: {hero.HeroManaPoint}");
			}

			Console.WriteLine(sb.ToString().TrimEnd());
		}
	}
}
//You got your hands on the most recent update on the best MMORPG of all time – Heroes of Code and Logic. You want to play it all day long! So cancel all other arrangements and create your party!
//On the first line of the standard input you will receive an integer n – the number of heroes that you can choose for your party. On the next n lines, the heroes themselves will follow with their hit points and mana points separated by empty space in the following format: 
//{ hero name}
//{ HP}
//{ MP}
//-where HP stands for hit points and MP for mana points
//-	a hero can have a maximum of 100 HP and 200 MP
//After you have successfully picked your heroes, you can start playing the game.  You will be receiving different commands, each on a new line, separated by " – ", until the "End" command is given. 
//There are several actions that can be performed by the heroes:
//CastSpell – { hero name} – { MP needed} – { spell name} 
//•	If the hero has the required MP, he casts the spell, thus reducing his MP. Print this message: 
//o "{hero name} has successfully cast {spell name} and now has {mana points left} MP!"
//•	If the hero is unable to cast the spell print:
//o "{hero name} does not have enough MP to cast {spell name}!"
//TakeDamage – { hero name} – { damage} – { attacker}
//•	Reduce the hero HP by the given damage amount. If the hero is still alive (his HP is greater than 0) print:
//o   "{hero name} was hit for {damage} HP by {attacker} and now has {current HP} HP left!"
//•	If the hero has died, remove him from your party and print:
//o "{hero name} has been killed by {attacker}!"
//Recharge – { hero name} – { amount}
//•	The hero increases his MP. If a command is given that would bring the MP of the hero above the maximum value (200), MP is increased to 200. (the MP can’t go over the maximum value).
//•	 Print the following message:
//o "{hero name} recharged for {amount recovered} MP!"
//Heal – { hero name} – { amount}
//•	The hero increases his HP. If a command is given that would bring the HP of the hero above the maximum value (100), HP is increased to 100(the HP can’t go over the maximum value).
//•	 Print the following message:
//o "{hero name} healed for {amount recovered} HP!"
//Input
//•	On the first line of the standard input you will receive an integer n
//•	On the next n lines, the heroes themselves will follow with their hit points and mana points separated by empty space in the following format
//•	You will be receiving different commands, each on a new line, separated by " – ", until the "End" command is given
//Output
//•	Print all members of your party who are still alive, sorted by their HP in descending order, then by their name in ascending order, in the following format (their HP/MP need to be indented 2 spaces):
//"{hero name}
// 	 HP: { current HP}
//MP: { current MP}
//..."
//Constraints
//•	The starting HP/MP of the heroes will be valid, 32-bit integers, will never be negative or exceed the respective limits.
//•	The HP/MP amounts in the commands will never be negative.
//•	The hero names in the commands will always be valid members of your party. No need to check that explicitly
//Имате ръцете си върху най-новата актуализация на най-добрата MMORPG на всички времена - Heroes of Code and Logic. Искаш да го играеш по цял ден!
//Така че анулирайте всички други споразумения и създайте своя страна!
//На първия ред от стандартния вход ще получите цяло число n – броя на героите, които можете да изберете за вашата партия.
//На следващите n линии, самите герои ще следват с техните точки на хит и точки на мана, разделени с празно пространство в следния формат:
//{ име на героя}
//{ HP}
//{ MP}
//-където HP е с точки на удар и MP за точки от мана
//-          герой може да има максимум 100 к.с. и 200 МР
//След като успешно сте избрали вашите герои, можете да започнете да играете играта. Ще получавате различни команди, всеки на нов ред, разделени с " - ", un, докато бъде даден "End" command.
//Има няколко действия, които могат да бъдат изпълнени от героите:
//CastSpell – { име на герой} – { MP needed} – { име на правописа}
//•         Ако героят има необходимия депутат, той прави магията, като по този начин намалява mp. Печат на това съобщение:
//o "{име на герой} успешно хвърли {име на правописа} и сега има {точки на мана} MP!"
//•         Ако героят не може да направи заклинанието печат:
//o "{име на герой} няма достатъчно MP, за да се измести {име на правописа}! "
//TakeDamage – { герой име} – { щети} – { attacker}
//•         Намалете героя HP с определената сума на щетите. Ако героят е все още жив (неговият HP е по-голям от 0) печат:
//o "{име герой} е ударен за {damage} HP от {нападател} и сега {текущата HP} наляво на HP!"
//•         Ако героят е умрял, махнете го от партито си и разпечатайте:
//o "{име на герой} е убит от {нападателя}!"
//Презареждане – { име на героя} – { сума}
//•         Героят увеличава mp-то си. Ако бъде дадена команда , която би довела депутата от героя над максималната стойност (200 ), MP се увеличава на 200. (MP не може да премине през максималната стойност).
//•         Отпечатайте следното съобщение:
//o "{име герой} презареждане за {възстановена сума} MP!
//Heal – { име на герой} – { сума}
//•         Героят увеличава своя HP. Ако се даде команда, която ще доведе до hp на героя над максималната стойност (100),HP се увеличава до 100 (HP не може да премине над максималната стойност).
//•         Отпечатайте следното съобщение:
//o "{име на герой} излекувано за {сума възстановена} HP!
//Въвеждане
//•         На първия ред от стандартния вход ще получите цяло число n
//•         На следващите n линии, самите герои ще следват с техните точки на хит и точки на мана, разделени с празно пространство в следния формат
//•         Ще получавате различни команди, всеки на нов ред, разделени с " - ", un, докато "End" command се даде
//Изход
//•         Отпечатайте всички членове на вашата партия, които са все още живи, подредени по техния HP в низходящ ред, след това по името си във възходящ ред, в следния формат (техните HP / MP трябва да бъдат вдлъбнати 2 пространства):
//"{име на героя}
//HP: { текущ HP}
//MP: { текущ МП}
//..."
//Ограничения
//•         32 - битовите цели числа никога няма да бъдат отрицателни или да надхвърлят съответните граници.
//•         Количествата HP/MP в командите никога няма да бъдат отрицателни.
//•         Имената на героя в командите винаги ще бъдат валидни членове на вашата партия. Не е необходимо да проверявате изрично дали
