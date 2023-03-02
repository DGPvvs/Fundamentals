using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    public static class Constants
    {
        public const string END = "end";
        public const string SEPARATOR = " ";
        public const string DRIVE = "drive";
        
        public const bool INSERT_FLAG = false;
        public const bool DRIVE_FLAG = true;
    }
    
    public static class Commands
    {
        public static string Model;
        public static double Fuel;
        public static double FuelPLiter;
        public static int Kilometers;
        
        public static void SetCommands(string[] inpit, bool flag)
        {
            if(flag == Constants.DRIVE_FLAG)
            {
                Model = inpit[1];
                Kilometers = int.Parse(inpit[2]);
            }
            else
            {
                Model = inpit[0];
                Fuel = double.Parse(inpit[1]);
                FuelPLiter = double.Parse(inpit[2]);
            }
        }
    }
    
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelPerKilometer;
        private int distance;
        
        public Car(string newModel, double newFuelAmount, double newFuelPerKilometer)
        {
            this.Model = newModel;
            this.FuelAmount = newFuelAmount;
            this.FuelPerKilometer = newFuelPerKilometer;
            this.Distance = 0;
        }
        
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }
        
        public double FuelAmount
        {
            get => this.fuelAmount;
            set => this.fuelAmount = value;
        }
        
        public double FuelPerKilometer
        {
            get => this.fuelPerKilometer;
            set => this.fuelPerKilometer = value;
        }
        
        public int Distance
        {
            get => this.distance;
            set => this.distance = value;
        }
        
        public bool Drive()
        {
            bool isCanMoveDistance = (this.FuelPerKilometer * Commands.Kilometers <= this.FuelAmount);
            
            if (isCanMoveDistance)
            {
                this.FuelAmount -= this.FuelPerKilometer * Commands.Kilometers;
                this.Distance += Commands.Kilometers;
            }
            
            return isCanMoveDistance;
        }
        
        public override string ToString() => $"{this.Model} {this.FuelAmount:F2} {this.Distance}";
    }// class Car

    class SpeedRacing
	{
		static void Main(string[] args)
		{
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            StringBuilder sb = new StringBuilder();

            string numCars = Console.ReadLine();

            bool isLoopExit = false;

            while (!isLoopExit)
            {
                string input = Console.ReadLine();
                
                if (input.ToLower() == Constants.END)
                {
                    isLoopExit = true;
                }
                else
                {
                    string[] command = input.Split(Constants.SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                    
                    if(command[0].ToLower() == Constants.DRIVE)
                    {
                        Commands.SetCommands(command, Constants.DRIVE_FLAG);
                        if(cars.ContainsKey(Commands.Model) && !cars[Commands.Model].Drive())
                        {
                            sb.AppendLine("Insufficient fuel for the drive");
                        }
                    }
                    else
                    {
                        Commands.SetCommands(command, Constants.INSERT_FLAG);
                        
                        if(!cars.ContainsKey(Commands.Model))
                        {
                            cars.Add(Commands.Model, new Car(Commands.Model, Commands.Fuel, Commands.FuelPLiter));
                        }
                    }
                }
            }
            
            sb.AppendLine(string.Join(Environment.NewLine, cars.Values));
            
            Console.WriteLine(sb.ToString().TrimEnd());
        }
	}
}