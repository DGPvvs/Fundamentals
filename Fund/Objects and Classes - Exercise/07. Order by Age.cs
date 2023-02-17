using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_by_Age
{
	class People : IComparable<People>
	{
		public People(string newName, string newId, int newAge)
		{
			Name = newName;
			Ident = newId;
			Age = newAge;
		}
				
		public string Name { get; set; }

		public string Ident {get; set;}

		public int Age {get; set; }
		
		public int CompareTo(People p) => this.Age.CompareTo(p.Age);
		
		public override string ToString() => $"{this.Name} with ID: {this.Ident} is {this.Age} years old."; 
	}//class People

	class OrderbyAge
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			List<People> peoples = new List<People>();

			bool isLoopExit = false;

			while (!isLoopExit)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower() == "end")
				{
					isLoopExit = true;
				}
				else
				{					
					string[] com = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
					string name = com[0];
					string id = com[1];
					int age = int.Parse(com[2]);

					peoples.Add(new People(name, id, age));
				}
			}
			
			peoples = peoples.OrderBy(n => n).ToList();
			
			Console.WriteLine(string.Join(Environment.NewLine, peoples));
		}
	}
}