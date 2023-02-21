using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Furniture
{
	class Furniture
	{
		static void Main(string[] args)
		{
			string pattern = @">>(?<furniture>(([A-Z]+)|([A-Z]+)+)([a-z]+)?)<<(?<price>(\d+)((\.)(\d+)|(\d+)))!(?<quantity>(\d)+)";
			
			StringBuilder sb = new StringBuilder();
			StringBuilder furnitureSB = new StringBuilder();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower() == "purchase")
				{
					isExitLoop = true;
				}
				else
				{
					furnitureSB.AppendLine(sb.ToString());
				}
			}

			var regex = Regex.Matches(furnitureSB.ToString(), pattern);

			sb.Clear();
			sb.AppendLine("Bought furniture:");
			decimal sum = 0.0M;

			foreach (Match item in regex)
			{
				string furniture = item.Groups["furniture"].Value;
				sum += decimal.Parse(item.Groups["price"].Value) * int.Parse(item.Groups["quantity"].Value);
				sb.AppendLine($"{furniture}");
			}

			sb.AppendLine($"Total money spend: {sum:F2}");
			Console.WriteLine(sb.ToString());
		}
	}
}