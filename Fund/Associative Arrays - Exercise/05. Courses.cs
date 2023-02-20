using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses
{
	class Courses
	{
		static void Main(string[] args)
		{
		    const string END = "end";
		    const string SEPARATOR_SYMBOL = " : ";
		    const string FORMATING_COURSES = "{0}: {1}";
		    const string FORMATED_STUDENT = "-- {0}";
			
			Dictionary<string, List<string>> curses = new Dictionary<string, List<string>>();
			List<string> command = new List<string>();

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
					command = input.Split(SEPARATOR_SYMBOL, StringSplitOptions.RemoveEmptyEntries).ToList();

					string cours = command[0];
					string student = command[1];

					if (!curses.ContainsKey(cours))
					{
						curses.Add(cours, new List<string>());												
					}
					
					curses[cours].Add(student);
				}				
			}
			
			StringBuilder sb = new StringBuilder();
			
			foreach (KeyValuePair<string, List<string>> item in curses)
			{
				sb.AppendLine(string.Format(FORMATING_COURSES, item.Key, item.Value.Count));
				foreach (string stud in item.Value)
				{
					sb.AppendLine(string.Format(FORMATED_STUDENT, stud));
				}
			}


			Console.WriteLine(sb.ToString());
		}
	}
}