using System;
using System.Collections.Generic;
using System.Linq;

namespace Oldest_Family_Member2
{
	class Person
	{
	    private string name;
	    private int age; 
	    
		public Person(string newName, int newAge)
		{
			Name = newName;
			Age = newAge;
		}

		public string Name { get; set; }

		public int Age { get; set; }

		public override string ToString() => $"{this.Name} {this.Age}";

	}// class Person

	class Family
	{
	    private string olderName;
		private int olderAge;
		private bool flag;
		
		public Family()
		{
			this.flag = false;
		}

		public void AddMember(Person member)
		{
			if (!this.flag)
			{
				this.olderName = member.Name;
				this.olderAge = member.Age;
				this.flag = true;

			}
			else if (member.Age > this.olderAge)
			{
				this.olderName = member.Name;
				this.olderAge = member.Age;
			}
		}

		public Person GetOldestMember() => new Person(this.olderName, this.olderAge);

	}// class Family
	
	
	class OldestFamilyMember2
	{
		static void Main(string[] args)
		{
			Family family = new Family();
			
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] cmd = Console.ReadLine().Split().ToArray();
				
				family.AddMember(new Person(cmd[0], int.Parse(cmd[1])));
			}

			Console.WriteLine(family.GetOldestMember().ToString());
		}
	}
}
