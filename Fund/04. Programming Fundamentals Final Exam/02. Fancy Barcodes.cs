using System;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{
		const string pattern = @"(@#+)(?<bar>[A-Z][A-Za-z0-9]{4,}[A-Z])(@#+)";
		StringBuilder sb = new StringBuilder();
		
		int n = int.Parse(Console.ReadLine());
		
		for (int i = 0; i < n; i++)
		{
			Match regexCode = Regex.Match(Console.ReadLine(), pattern);
			sb.Clear();
			if(regexCode.Success)
			{
				for(int j = 0; j < regexCode.Groups["bar"].Value.Length; j++)
				{
					if(Char.IsDigit(regexCode.Groups["bar"].Value[j]))
					{
						sb.Append(regexCode.Groups["bar"].Value[j]);
					}						
				}
				if(sb.ToString() == String.Empty)
			{
				Console.WriteLine($"Product group: 00");	
			}
			else
			{				
				Console.WriteLine($"Product group: {sb.ToString()}");
			}
			}
			else
			{
				Console.WriteLine($"Invalid barcode");
			}
			
			
		}
		
	}
}