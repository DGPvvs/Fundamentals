using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
	class Race
	{
		static void Main(string[] args)
		{
			string[] place = { "1st", "2nd", "3rd" };

			Dictionary<string, int> competitors = new Dictionary<string, int>();
			string namePattern = @"(?<name>([A-Z])|([a-z])+)";
			string digitPattern = @"(?<digit>([\d]))";

			string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

			foreach (string item in input)
			{
				if (!competitors.ContainsKey(item))
				{
					competitors.Add(item, 0);
				}
			}

			StringBuilder sb = new StringBuilder();

			bool isExitLoop = false;			

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower() == "end of race")
				{
					isExitLoop = true;
				}
				else
				{
					MatchCollection nameRegexCollection = Regex.Matches(sb.ToString(), namePattern);
					MatchCollection digitRegexCollection = Regex.Matches(sb.ToString(), digitPattern);

					StringBuilder nameSb = new StringBuilder();
					int sum = 0;

					nameSb.Append(string.Join(string.Empty, nameRegexCollection));
					
					foreach (Match item in digitRegexCollection)
					{
						sum += int.Parse(item.Value);
					}

					if (competitors.ContainsKey(nameSb.ToString()))
					{
						competitors[nameSb.ToString()] += sum;
					}
				}
			}

			competitors = competitors.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

			int i = 0;

			sb.Clear();
			foreach (var item in competitors)
			{
				if (i < 3)
				{
					sb.AppendLine($"{place[i]} place: {item.Key}");
				}
				i++;
			}

			Console.WriteLine(sb.ToString());
		}
	}
}