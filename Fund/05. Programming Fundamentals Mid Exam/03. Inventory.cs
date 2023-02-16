using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
	public static void Main()
	{
		char[] separatorColection = {',', ' '};
		char[] separatorCommands = {'-', ' ', ':'};
		List<string> inventory = Console.ReadLine()
			.Split(separatorColection, StringSplitOptions.RemoveEmptyEntries)
			.ToList();
		
		StringBuilder sb = new StringBuilder();
		bool isLoopExit = false;
						
		while (!isLoopExit)
		{
			sb.Clear();
			if (sb.Append(Console.ReadLine()).ToString().ToLower().Equals("craft!"))
			{
				isLoopExit = true;
			}
			else
			{
				string[] input = sb.ToString().Split(separatorCommands, StringSplitOptions.RemoveEmptyEntries);
				string command = input[0];
				string item = input[1];
				
				switch (command.ToLower())
				{
					case "collect":
						
						if (!inventory.Contains(item))
						{
							inventory.Add(item);
						}
						break;
					case "drop":						
						inventory.Remove(item);
						break;
					case "combine":
						string oldItem = input[2];
						string newItem = input[3];
						int index = inventory.FindIndex(x => x == oldItem);
						if (index > -1)
						{
							inventory.Insert(index + 1, newItem);
						}
						break;
					case "renew":
						if (inventory.Remove(item))
						{
							inventory.Add(item);
						}
						break;
					default:
						break;
				}
				
								
			}			
		}
		
		Console.WriteLine(string.Join(", ", inventory));
	}
}


