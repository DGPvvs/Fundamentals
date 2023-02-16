using System;

public class Program
{
	public static void Main()
	{
		int studentsCount = int.Parse(Console.ReadLine());
		int lecturesCount = int.Parse(Console.ReadLine());
		int initialBonus = int.Parse(Console.ReadLine()) + 5;
		
		double MaxBonus = 0.0;
		int MaxAttendances = 0;
		
		for (int i = 0; i < studentsCount; i++)
		{
			int studentAttendances = int.Parse(Console.ReadLine());
			double currentBonus = 1.0 * initialBonus * studentAttendances / lecturesCount;
			
			if (MaxBonus < currentBonus)
			{
				MaxBonus = currentBonus; 
				MaxAttendances = studentAttendances; 
			}
		}
		
		Console.WriteLine($"Max Bonus: {Math.Ceiling(MaxBonus)}.");
		Console.WriteLine($"The student has attended {MaxAttendances} lectures.");
	}
}