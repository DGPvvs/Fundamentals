using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    internal static class Messages
    {
        public const string END = "end";
        public const string SPLIT_SYMBOL = " ";
        public const string CAR = "car";
        public const string CLOSE = "close the catalogue";
        
        public const string CAR_TYPE = "Car";
        public const string TRUCK_TYPE = "Truck";
    }
    
    public class Vehicle
    {
        private string model; 
        private string color;
        private int horsePower;
        
        public Vehicle(string modelOfVehicle, string colorOfVehicle, int horsepowerOfVehicle)
        {            
            this.Model = modelOfVehicle;
            this.Color = colorOfVehicle;
            this.HorsePower = horsepowerOfVehicle;
        }
        
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }
        
        public string Color
        {
            get => this.color;
            set => this.color = value;
        }
        
        public int HorsePower
        {
            get => this.horsePower;
            set => this.horsePower = value;
        }
        
        public override string ToString() => $"Model: {this.Model}{Environment.NewLine}Color: {this.Color}{Environment.NewLine}Horsepower: {this.HorsePower}";
    }// class Vehicle

    public class VehicleCatalogue
    {
        public static void Main()
        {
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();
            
            bool isLoopExit = false;

            while (!isLoopExit)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == Messages.END)
                {
                    isLoopExit = true;
                }
                else
                {
                    List<string> command = input.Split(Messages.SPLIT_SYMBOL, StringSplitOptions.RemoveEmptyEntries).ToList();

                    string typeOfVehicle = command[0];
                    string modelOfVehicle = command[1];
                    string colorOfVehicle = command[2];
                    int horsepowerOfVehicle = int.Parse(command[3]);

					if (typeOfVehicle.ToLower() == Messages.CAR)
					{
                        cars.Add(new Vehicle(modelOfVehicle, colorOfVehicle, horsepowerOfVehicle));
                    }
                    else
                    {
                        trucks.Add(new Vehicle(modelOfVehicle, colorOfVehicle, horsepowerOfVehicle));
                    }                    
                }
            }
            
            double avrHorsepowerCar = 0;
            
            if (cars.Count > 0)
			{
                avrHorsepowerCar = 1.0 * cars.Average(x => x.HorsePower);
            }
			
            double avrHorsepowerTruck = 0;
            
            if (trucks.Count > 0)
            {
                avrHorsepowerTruck =  1.0 * trucks.Average(x => x.HorsePower);
            }
            
            StringBuilder sb = new StringBuilder();

            isLoopExit = false;
            
            while (!isLoopExit)
            {
                string model = Console.ReadLine();
                if (model.ToLower() == Messages.CLOSE)
                {
                    isLoopExit = true;
                }
                else
                {
                    Vehicle vehicle = cars.FirstOrDefault(v => v.Model == model);
                    string type = Messages.CAR_TYPE;
                    
					if (vehicle == null)
					{
					    vehicle = trucks.FirstOrDefault(v => v.Model == model);
					    type = Messages.TRUCK_TYPE;
                    }
                    
                    SetOutput(vehicle, type, ref sb);
                }
            }
            
            sb
                .AppendLine($"Cars have average horsepower of: {(avrHorsepowerCar):F2}.")
                .AppendLine($"Trucks have average horsepower of: {(avrHorsepowerTruck):F2}.");
            
            Console.WriteLine(sb.ToString().TrimEnd());
        }
        
        public static void SetOutput(Vehicle vehicle, string type, ref StringBuilder sb)
        {
            if(vehicle != null)
            {
                sb
                    .AppendLine($"Type: {type}")
                    .AppendLine(vehicle.ToString());
            }
        }
    }
}
//You have to create a vehicle catalogue. You will store only two types of vehicles – a car and a truck. Until you receive the “End” command you will be receiving lines of input in the following format:
//{ typeOfVehicle}
//{ model}
//{ color}
//{ horsepower}
//After the “End” command, you will start receiving models of vehicles. Print the data for every received vehicle in the following format:
//Type: { typeOfVehicle}
//Model: { modelOfVehicle}
//Color: { colorOfVehicle}
//Horsepower: { horsepowerOfVehicle}

//When you receive the command “Close the Catalogue”, print the average horsepower for the cars and for the trucks in the following format:
//{ typeOfVehicles}
//have average horsepower of {averageHorsepower}.
//The average horsepower is calculated by dividing the sum of the horsepower of all vehicles from the certain type by the total count of vehicles from the same type. Round the answer to the 2nd digit after the decimal separator.
//Constraints
//•	The type of vehicle will always be either a car or a truck.
//•	You will not receive the same model twice.
//•	The received horsepower will be an integer in the range [1…1000]
//•	You will receive at most 50 vehicles.
//•	The separator will always be a single whitespace.
//	Трябва да създадете каталог на автомобили. Ще съхранявате само два вида превозни средства – автомобил и камион. Докато получите командата "Край" ще получавате редове за въвеждане в следния формат:
//{
//	тип офозиден { модел}
//	{ цвят}
//	1000000000000
//След командата "Край" ще започнете да получавате модели автомобили. Отпечатайте данните за всяко получено превозно средство в следния формат:
//Тип: { типОтhicle}
//	Модел: { Модел на}
//	Цвят: { цвят На 1000}
//	Конски сили: { конски сили на Вехикъл}

//	Когато получите командата "Затвори каталога",отпечатайте средната конска мощност за автомобилите и за камионите в следния формат:
//{ typeOfVehicles}
//	имат средна мощност от {
//		среднаколеснакозност....Средната конска сила се изчислява, като сумата на конската сила на всички превозни средства от определен тип се раздели на общия брой превозни средства от същия тип.Закръгляване на отговора до втората цифра след десетичния разделител.
//							   Ограничения
//•         Типът превозно средство винаги ще бъде или автомобил или автомобил.
//•         Няма да получите един и същ модел два пъти.
//•         Получената конска сила ще бъде цяло число в диапазона[1... 1000)
//•         Ще получите най - много 50 превозни средства.
//•         Разделителят винаги ще бъде единичен интервал.