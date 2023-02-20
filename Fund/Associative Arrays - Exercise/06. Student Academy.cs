using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_Academy
{
	public class AverageGrade
	{
	    private List<double> grd;
	    
		public AverageGrade()
		{
			Grd = new List<double>();
		}
		
		public double Avr => this.Grd.Average();
		
		public List<double> Grd
		{
		    get => this.grd;
		    set => this.grd = value;
		}
	}

	class StudentAcademy
	{
		static void Main(string[] args)
		{
		    const string FORMATING_OUTPUT = "{0} -> {1:F2}";
		    
			Dictionary<string, AverageGrade> grades = new Dictionary<string, AverageGrade>();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string name = Console.ReadLine();
				double grade = double.Parse(Console.ReadLine());

				if (!grades.ContainsKey(name))
				{
					grades.Add(name, new AverageGrade());
				}
				
				grades[name].Grd.Add(grade);
			}
			
			grades = grades.Where(s => s.Value.Avr >= 4.5).ToDictionary(x => x.Key, x => x.Value);

			StringBuilder sb = new StringBuilder();

			foreach (KeyValuePair<string, AverageGrade> item in grades)
			{
				sb.AppendLine(string.Format(FORMATING_OUTPUT, item.Key, item.Value.Avr));
			}

			Console.WriteLine(sb.ToString());
		}
	}
}