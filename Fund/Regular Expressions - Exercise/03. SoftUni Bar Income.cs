using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
	class SoftUniBarIncome
	{
		static void Main(string[] args)
		{
			string pattern = @"\%(?<name>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<digit>\d+([.]\d+)?)\$";
			StringBuilder sb = new StringBuilder();
			StringBuilder resultSb = new StringBuilder();

			bool isExitLoop = false;
			decimal sum = 0;

			while (!isExitLoop)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower() == "end of shift")
				{
					isExitLoop = true;
				}
				else
				{
					MatchCollection regex = Regex.Matches(sb.ToString(), pattern);

					foreach (Match item in regex)
					{
						resultSb.Append($"{item.Groups["name"].Value}: ");
						resultSb.Append($"{item.Groups["product"].Value} - ");
						decimal price = int.Parse(item.Groups["count"].Value) * decimal.Parse(item.Groups["digit"].Value);
						sum += price;
						resultSb.AppendLine($"{price:F2}");
					}
				}
			}

			resultSb.AppendLine($"Total income: {sum:F2}");
			Console.WriteLine(resultSb.ToString());
		}
	}
}