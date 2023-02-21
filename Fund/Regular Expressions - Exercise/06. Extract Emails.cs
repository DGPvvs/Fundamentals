using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Extract_Emails
{
	class ExtractEmails
	{
		static void Main(string[] args)
		{
			string pattern = @"\s+([^\-\.\*\$\t\s_\@\n])+([A-Za-z\d\.\-_]+)@([a-zA-Z\d\-]+)([^\-\.,])(\.)([a-z]+)?(\.)?([a-z]+)?([^\-\.,\s])";
			
			StringBuilder sb = new StringBuilder();

			MatchCollection regex = Regex.Matches(Console.ReadLine(), pattern);

			foreach (Match item in regex)
			{
				sb.AppendLine(item.Groups[0].Value.TrimStart());
			}

			Console.WriteLine(sb.ToString());
		}
	}
}