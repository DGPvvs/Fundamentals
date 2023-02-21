using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Star_Enigma
{
	class StarEnigma
	{
		static void Main(string[] args)
		{			
			string keyPattern = @"([SsTtAaRr])";
			string encodingPattern = @"\@(?<planetName>([A-z]+))[^\:!\->]*:(?<population>(\d+))[^\:!\->]*!(?<attacktype>([A|D]))![^\:!\->]*->(?<soldiercount>(\d+))";
			StringBuilder sb = new StringBuilder();
			StringBuilder codingSb = new StringBuilder();
			List<string> attackedPlanets = new List<string>();
			List<string> destroyedPlanets = new List<string>();


			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				sb.Clear();
				sb.Append(Console.ReadLine());
				MatchCollection regex = Regex.Matches(sb.ToString(), keyPattern);

				int keyOffset = regex.Count;
				codingSb.Clear();

				for (int j = 0; j < sb.Length; j++)
				{
					codingSb.Append(char.ToString((char)((int)sb[j] - keyOffset)));
				}

				regex = Regex.Matches(codingSb.ToString(), encodingPattern);

				foreach (Match item in regex)
				{
					if (item.Groups["attacktype"].Value == char.ToString('A'))
					{
						attackedPlanets.Add(item.Groups["planetName"].Value);
					}
					else
					{
						destroyedPlanets.Add(item.Groups["planetName"].Value);
					}
				}
			}

			attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
			destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

			sb.Clear();
			sb.AppendLine($"Attacked planets: {attackedPlanets.Count}");
			foreach (string s in attackedPlanets)
			{
				sb.AppendLine($"-> {s}");
			}

			sb.AppendLine($"Destroyed planets: {destroyedPlanets.Count}");
			foreach (string s in destroyedPlanets)
			{
				sb.AppendLine($"-> {s}");
			}

			Console.WriteLine(sb.ToString());
		}	
	}
}