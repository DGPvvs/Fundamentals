using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company_Users
{
	class CompanyUsers
	{
		static void Main(string[] args)
		{
		    const string END = "end";
		    const string SEPARATE_SYMBOL = " -> ";
		    const string FORMATING_OUTPUT = "-- {0}"; 
		    
			Dictionary<string, HashSet<string>> emploiers = new Dictionary<string, HashSet<string>>();
			
			List<string> command;

			bool isLoopExit = false;

			while (!isLoopExit)
			{
			    string input = Console.ReadLine();
			    
				if (input.ToLower() == END)
				{
					isLoopExit = true;
				}
				else
				{
					command = input.Split(SEPARATE_SYMBOL, StringSplitOptions.RemoveEmptyEntries).ToList();
					string company =  command[0];
					string employeeId = command[1];
					
					if (!emploiers.ContainsKey(company))
					{
						emploiers.Add(company, new HashSet<string>());
					}
					
					emploiers[company].Add(employeeId);
				}
			}
			
			StringBuilder sb = new StringBuilder();

			foreach (KeyValuePair<string, HashSet<string>> item in emploiers)
			{
				sb.AppendLine(item.Key);
				foreach (string idNum in item.Value)
				{
					sb.AppendLine(string.Format(FORMATING_OUTPUT, idNum));
				}
			}

			Console.WriteLine(sb.ToString());
		}
	}
}