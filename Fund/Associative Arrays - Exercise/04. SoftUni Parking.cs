using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Program
{	
	public const byte Fall = 0;
	public const byte Registration = 1;
	public const byte UnRegistration = 2;
	public const byte RepeatNumber = 3;
	public const byte OK = 4;
	
	static byte ValidateRegister(Dictionary<string, string> newUsers, byte flag,
								 string newName, string newPlate)
	{
		byte result = Fall;
		
		switch (flag) 
		{
			case Registration:
				if (!newUsers.ContainsKey(newName))
				{
					result = OK;
				}
				else if (newUsers.ContainsKey(newName) && newUsers[newName] == newPlate)
					result = RepeatNumber; 
				break;
			case UnRegistration:
				if (newUsers.ContainsKey(newName))
				{
					result = OK;
				}				
				break;
			default:
				break;
		}
		
		return result;
	}	
	
	public static void Main()
	{
		Dictionary<string, string> users = new Dictionary<string, string>();
		
		List<string> input = new List<string>();
					
		int n = int.Parse(Console.ReadLine());
				
		for (int i = 0; i < n; i++)
		{
			input.Clear();
			input = Console.ReadLine().Split(' ').ToList();
			
			string command = input[0].ToString().ToLower();			
			byte flag = Fall;
			
			switch(command)
			{
				case "register":
					flag = ValidateRegister(users, Registration, input[1], input[2]);
					if ( flag == OK)
					{
						users.Add(input[1], input[2]);
						Console.WriteLine("{0} registered {1} successfully", input[1], input[2]);	
					}
					else if (flag == Fall || flag == RepeatNumber)
					{
						Console.WriteLine("ERROR: already registered with plate number {0}",
										  input[2]);	
					}
					break;
				case "unregister":
					flag = ValidateRegister(users, UnRegistration, input[1], string.Empty);
					if ( flag == OK)
					{
						users.Remove(input[1]);
						Console.WriteLine("{0} unregistered successfully", input[1]);	
					}
					else if (flag == Fall)
					{
						Console.WriteLine("ERROR: user {0} not found", input[1]);	
					}
					break;
			}
		}
				
		foreach (KeyValuePair<string, string> item in users)
		{			
			Console.WriteLine("{0} => {1}", item.Key, item.Value);			
		}
		
	}
}