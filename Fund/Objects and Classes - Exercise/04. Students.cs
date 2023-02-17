using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students
{
	public class Student
	{
		public Student(string newFirstName, string newLastName, double newGrade)
		{
			FirstName = newFirstName;
			LastName = newLastName;
			Grade = newGrade;
		}

		private string firstName;
		public string FirstName
		{
			get
			{
				return firstName;
			}

			set
			{
				firstName = value;
			}
		}

		private string lastName;
		public string LastName
		{
			get
			{
				return lastName;
			}

			set
			{
				lastName = value;
			}
		}

		private double grade;
		public double Grade
		{
			get
			{
				return grade;
			}

			set
			{
				grade = value;
			}
		}

	}// public class Student 

	class Students
	{		
		static void Main(string[] args)
		{
			int numStudents = int.Parse(Console.ReadLine());
			List<Student> students = new List<Student>();

			for (int i = 0; i < numStudents; i++)
			{
				StringBuilder input = new StringBuilder(Console.ReadLine());
				List<string> stu = input.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
				Student student = new Student(stu[0], stu[1], double.Parse(stu[2]));
				students.Add(student);
			}
			students = students.OrderByDescending(x => x.Grade).ToList();

			foreach (Student item in students)
			{
				Console.WriteLine($"{item.FirstName} {item.LastName}: {item.Grade:F2}");
			}
			
		}
	}
}
//Write a program that receives a count of students - n and orders them by grade in descending order. Each student should have a First name (string), a Last name (string) and a grade (a floating-point number). 
//Input
//•	On the first line, you are going to receive n - the count of students
//•	On the next n lines, you will be receiving the info about the students in the following format: 
//"{first name} {second name} {grade}"
//Output
//•	Print each student in the following format: "{first name} {second name}: {grade}"
//Напишете програма, която получава броя ученици - n , и ги нарежда по степен в низходящ ред. Всеки ученик трябва да има име (низ), фамилия(низ) и клас(число с плаваща запетая).
//въвеждане
//•         На първия ред, вие ще получите n - броя на учениците
//•         На следващите n линии ще получавате информация за учениците в следния формат:
//{ второ име}
//{ клас}
//"
//изход
//•         Отпечатайте всеки ученик в следния формат: "{първо име} {второ име}: {grade}"
