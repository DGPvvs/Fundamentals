using System;

namespace _1._Student_Information
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputStudentName;
			int inputAge;
			double inputAverageGrade;

			inputStudentName = Console.ReadLine();
			inputAge = int.Parse(Console.ReadLine());
			inputAverageGrade = double.Parse(Console.ReadLine());

			Console.WriteLine($"Name: {inputStudentName}, Age: {inputAge}, Grade: {inputAverageGrade:F2}");
		}
	}
}
//Ще ви бъдат дадени 3 реда за въвеждане - име на студент, възраст и средна оценка.
//Вашата задача е да отпечатате цялата информация за ученика в следния формат: „Име: { име на студент}, Възраст: { възраст на ученика}, Клас: { оценка на студент}“.