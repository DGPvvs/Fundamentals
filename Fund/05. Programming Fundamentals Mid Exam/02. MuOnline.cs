using System;

public class Program
{
	public static void Main()
	{
		char[] separatorRooms = {'|'};
		char[] separatorCommands = {' '};
		string[] rooms = Console.ReadLine().Split(separatorRooms, StringSplitOptions.RemoveEmptyEntries);
		
		bool isDead = false;
		int i = 0;
		int currentHealth = 100;
		int currentBitcoins = 0;
		
		while ((i < rooms.Length) && (!isDead))
		{
			string[] command = rooms[i].Split(separatorCommands, StringSplitOptions.RemoveEmptyEntries);
			
			switch (command[0].ToLower())
			{
				case "potion":
					int addedHealth = int.Parse(command[1]);
					if(currentHealth + addedHealth > 100)
					{
						addedHealth = 100 - currentHealth; 
						currentHealth = 100;	
					}
					else
					{
						currentHealth += addedHealth;
					}
					Console.WriteLine($"You healed for {addedHealth} hp.");
					Console.WriteLine($"Current health: {currentHealth} hp.");
					break;
				case "chest":
					currentBitcoins += int.Parse(command[1]);
					Console.WriteLine($"You found {command[1]} bitcoins.");
					break;
				default:
					int monsterAttack = int.Parse(command[1]);
					if (currentHealth - monsterAttack <= 0)
					{
						Console.WriteLine($"You died! Killed by {command[0]}.");
						Console.WriteLine($"Best room: {i + 1}");
						isDead = true;
					}
					else
					{
						currentHealth -= monsterAttack;
						Console.WriteLine($"You slayed {command[0]}.");
					}
					break;
			}			
			i++;
		}
		
		if (!isDead)
		{
			Console.WriteLine("You've made it!");
			Console.WriteLine($"Bitcoins: {currentBitcoins}");
			Console.WriteLine($"Health: {currentHealth}");			
		}				
	}
}


