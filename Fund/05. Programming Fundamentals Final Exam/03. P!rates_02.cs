using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P_rates
{
	public class Town
	{
	    private string townName;
	    private int townPopulation;
	    private int townGold;
	    
		public Town(string newTownName)
		{
		    this.TownName = newTownName;
		    this.TownPopulation = 0;
			this.TownGold = 0;
		}
		
		public Town(string newTownName, int newTownPopulation, int newTownGold) : this(newTownName)
		{
			this.AddPopulation(newTownPopulation);
			this.AddGold(newTownGold);
		}

		public string TownName
		{
		    get => this.townName;
		    set => this.townName = value;
		}
		
		public int TownPopulation
		{
		    get => this.townPopulation;
		    set => this.townPopulation = value;
		}
		
		public int TownGold
		{
		    get => this.townGold;
		    set => this.townGold = value;
		}
		
		public void AddPopulation(int population)
		{
		    this.TownPopulation += population;
		}
		
		public void AddGold(int golg)
		{
		    this.TownGold += golg;
		}
		
		public override string ToString() => $"{this.TownName} -> Population: {this.TownPopulation} citizens, Gold: {this.TownGold} kg";
	}

	class PIrates
	{
		static void Main(string[] args)
		{
		    const string SAIL = "sail";
            const string END = "end";
        
            const string TOWN_SEPARATOR = "||";
            const string ACTION_SEPARATOR = "=>";
        
            const string TOWN_PLUNDERED = "{0} plundered! {1} gold stolen, {2} citizens killed.";
            const string TOWN_WIPED = "{0} has been wiped off the map!";
            const string ADD_GOLD = "{0} gold added to the city treasury. {1} now has {2} gold.";
            const string WRONG_GOLD = "Gold added cannot be a negative number!";
            const string MISSION_GOAL = "Ahoy, Captain! All targets have been plundered and destroyed!";
            const string MISSION_NOT_SUCSESSFULL = "Ahoy, Captain! There are {0} wealthy settlements to go to:";
            
			Dictionary<string, Town> towns = new Dictionary<string, Town>();

			bool isExitLoop = false;

			while (!isExitLoop)
			{
			    string inputString = Console.ReadLine();
			    
			    if (inputString.ToLower().Equals(SAIL))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = inputString.Split(TOWN_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
					
					string name = input[0];
					int population = int.Parse(input[1]);
					int gold = int.Parse(input[2]); 
					
					if(!towns.ContainsKey(name))
					{
					   towns.Add(name, new Town(name, population, gold));
					}
					else
					{
					    towns[name].AddPopulation(population);
					    towns[name].AddGold(gold);
					}
				}
			}			
			
			StringBuilder sb = new StringBuilder();

			isExitLoop = false;

			while (!isExitLoop)
			{
				string inputString = Console.ReadLine();
				
				if (inputString.ToLower().Equals(END))
				{
					isExitLoop = true;
				}
				else
				{
					string[] input = inputString.Split(ACTION_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

					string command = input[0];
					string townName = input[1];

					Town town = towns[townName];

					switch (command.ToLower())
					{
						case "plunder":							
							int people = int.Parse(input[2]);
							int gold = int.Parse(input[3]);
							
							town.AddPopulation(-people);
							town.AddGold(-gold);
							
							sb.AppendLine(string.Format(TOWN_PLUNDERED, townName, gold, people));

							if ((town.TownPopulation <= 0) || (town.TownGold <= 0))
							{
								towns.Remove(townName);
								sb.AppendLine(string.Format(TOWN_WIPED, townName));
							}
							break;
						case "prosper":
							gold = int.Parse(input[2]);

							if (gold >= 0)
							{
								town.AddGold(gold);
								sb.AppendLine(string.Format(ADD_GOLD, gold, townName, town.TownGold));
							}
							else
							{
							    sb.AppendLine(WRONG_GOLD);
							}
							break;
						default:
							break;
					}
				}
			}
			
			if (towns.Count <= 0)
			{
				sb.AppendLine(MISSION_GOAL);				
			}
			else
			{
				sb
				    .AppendLine(string.Format(MISSION_NOT_SUCSESSFULL, towns.Count))
				    .AppendLine(string.Join(Environment.NewLine, towns.Values));
			}

			Console.WriteLine(sb.ToString().TrimEnd());
		}
	}
}

//Anno 1681. The Caribbean. The golden age of piracy. You are a well-known pirate captain by the name of Jack Daniels.
//Together with your comrades Jim (Beam) and Johnny (Walker), you have been roaming the seas, looking for gold and treasure… and the occasional killing, of course.
//Go ahead, target some wealthy settlements and show them the pirate's way!
//Until the "Sail" command is given, you will be receiving:
//•	You and your crew have targeted cities, with their population and gold, separated by "||".
//•	If you receive a city that has already been received, you have to increase the population and gold with the given values.
//After the "Sail" command, you will start receiving lines of text representing events until the "End" command is given. 
//Events will be in the following format:
//•	"Plunder=>{town}=>{people}=>{gold}"
//o	You have successfully attacked and plundered the town, killing the given number of people and stealing the respective amount of gold. 
//o	For every town you attack print this message: "{town} plundered! {gold} gold stolen, {people} citizens killed."
//o	If any of those two values (population or gold) reaches zero, the town is disbanded.
//	You need to remove it from your collection of targeted cities and print the following message: "{town} has been wiped off the map!"
//o	There will be no case of receiving more people or gold than there is in the city.
//•	"Prosper=>{town}=>{gold}"
//o	There has been dramatic economic growth in the given city, increasing its treasury by the given amount of gold.
//o	The gold amount can be a negative number, so be careful. If a negative amount of gold is given, print: "Gold added cannot be a negative number!" and ignore the command.
//o	If the given gold is a valid amount, increase the town's gold reserves by the respective amount and print the following message: 
//"{gold added} gold added to the city treasury. {town} now has {total gold} gold."
//Input
//•	On the first lines, until the "Sail" command, you will be receiving strings representing the cities with their gold and population, separated by "||"
//•	On the following lines, until the "End" command, you will be receiving strings representing the actions described above, separated by "=>"
//Output
//•	After receiving the "End" command, if there are any existing settlements on your list of targets, you need to print all of them, in the following format:
//"Ahoy, Captain! There are {count} wealthy settlements to go to:
//{town1} -> Population: {people} citizens, Gold: {gold} kg
//{town2} -> Population: {people} citizens, Gold: {gold} kg
   //…
//{town…n} -> Population: {people} citizens, Gold: {gold} kg"
//•	If there are no settlements left to plunder, print:
//"Ahoy, Captain! All targets have been plundered and destroyed!"
//Constraints
//•	The initial population and gold of the settlements will be valid 32-bit integers, never negative, or exceed the respective limits.
//•	The town names in the events will always be valid towns that should be on your list.