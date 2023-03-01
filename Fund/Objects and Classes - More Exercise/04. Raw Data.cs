using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raw_Data
{
	class Engine
	{
		public Engine(int newEngineSpeed, int newEnginePower)
		{
			EngineSpeed = newEngineSpeed;
			EnginePower = newEnginePower;
		}

		public int EngineSpeed { get; set; }
		public int EnginePower { get; set; }

	}// class Engine

	class Cargo
	{
		public Cargo(int newCargoWeight, string newCargoType)
		{
			CargoWeight = newCargoWeight;
			CargoType = newCargoType;
		}

		public int CargoWeight { get; set; }
		public string CargoType { get; set; }

	}// class Cargo

	class Car
	{
		public Car(string newModel, int newEngineSpeed, int newEnginePower, int newCargoWeight, string newCargoType)
		{
			Model = newModel;
			CarEngine = new Engine(newEngineSpeed, newEnginePower);
			CarCargo = new Cargo(newCargoWeight, newCargoType);
		}

		public string Model { get; set; }
		public Engine CarEngine { get; set; }
		public Cargo CarCargo { get; set; }

		public override string ToString() => $"{Model}";
	}// class Car

	class RawData
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<Car> cars = new List<Car>();			

			for (int i = 0; i < n; i++)
			{				
				List<string> str = Console.ReadLine().Split(' ').ToList();
				string model = str[0];
				int engineSpeed = int.Parse(str[1]);
				int enginePower = int.Parse(str[2]);
				int cargoWeight = int.Parse(str[3]);
				string cargoType = str[4];
				cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType));
			}

			string cmd = Console.ReadLine();
			IEnumerable<Car> filtrateList = null;

			switch (cmd)
			{
				case "fragile":
					filtrateList = cars.FindAll(c => c.CarCargo.CargoType == cmd && c.CarCargo.CargoWeight < 1000);					
					break;
				case "flamable":
					filtrateList = cars.FindAll(c => c.CarCargo.CargoType == cmd && c.CarEngine.EnginePower > 250);					
					break;
				default:
					break;
			}
			
			Console.WriteLine(string.Join(Environment.NewLine, filtrateList));
		}
	}
}