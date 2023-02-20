using System;
using System.Collections.Generic;
using System.Text;

namespace Count_Chars_in_a_String
{
	class CountCharsinaString
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();

			Dictionary<char, int> count = new Dictionary<char, int>();

			foreach (char item in input)
			{
				if (!char.IsWhiteSpace(item))
				{
					if (count.ContainsKey(item))
					{
						count[item]++;
					}
					else
					{
						count.Add(item, 1);
					}
				}
			}
			
			StringBuilder sb = new StringBuilder();

			foreach (KeyValuePair<char, int> item in count)
			{
				sb.AppendLine($"{item.Key} -> {item.Value}");
			}

			Console.WriteLine(sb);
		}
	}
}