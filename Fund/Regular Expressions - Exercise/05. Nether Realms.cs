using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


namespace Nether_Realms
{
	public class Demon
	{
		public Demon(int newHealthPoints, double newDamagePoints)
		{
			this.HealthPoints = newHealthPoints;
			this.DamagePoints = newDamagePoints;
		}

		public int HealthPoints { get; set; }
		public double DamagePoints { get; set; }
	}// class Demon

	public class NetherRealms
	{
		static void Main(string[] args)
		{
			string[] patternArr = { @"(?<health>([^0-9+\-*\/\.]))",
				@"(?<damage>(((\-)?(\d+))((\.)?(\d+)))|(((\-)?(\d+))))",
				@"(?<multi>(\*))",
				@"(?<devide>(\/))",
				@"(?<nameDemon>[^\,\t\ \n]+)" };

			const int healthPattern = 0;// @"(?<health>[A-Z]|[a-z])"
			const int damagePattern = 1;// @"(?<damage>(((\-)?(\d+))((\.)?(\d+)))|(((\-)?(\d+))))"
			const int multiplayPattern = 2;// @"(?<multi>(\*))"
			const int devidePattern = 3;// @"(?<devide>(\/))"
			const int namePattern = 4;//(?<nameDemon>[^\,\t\ \n]+)

			string[] input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

			StringBuilder sb = new StringBuilder();
			SortedList<string, Demon> demons = new SortedList<string, Demon>();

			string filter = "0123456789+-/*.";

			foreach (string item in input)
			{
				MatchCollection regex = Regex.Matches(item, patternArr[damagePattern]);

				double newDamage = 0.0;
				foreach (Match sh in regex)
				{
					newDamage += double.Parse(sh.Groups["damage"].Value);
				}

				regex = Regex.Matches(item, patternArr[multiplayPattern]);
				
				foreach (Match sh in regex)
				{
					newDamage *= 2.0;
				}

				regex = Regex.Matches(item, patternArr[devidePattern]);

				foreach (Match sh in regex)
				{
					newDamage /= 2.0;
				}

				regex = Regex.Matches(item, patternArr[namePattern]);

				sb.Clear();
				foreach (Match sh in regex)
				{
					sb.Append(sh.Groups["nameDemon"].Value);
				}

				demons.Add(sb.ToString(), new Demon(newHealth, newDamage));
			}

			sb.Clear();
			foreach (KeyValuePair<string, Demon> item in demons)
			{
				sb.AppendLine($"{item.Key} - {item.Value.HealthPoints} health, {item.Value.DamagePoints:F2} damage");
			}

			Console.WriteLine(sb.ToString());
		}
	}
}