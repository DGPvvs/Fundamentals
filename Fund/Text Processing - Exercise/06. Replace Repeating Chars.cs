using System;
using System.Text;

namespace Replace_Repeating_Chars
{
	class ReplaceRepeatingChars
	{
		static void Main(string[] args)
		{
			StringBuilder startString = new StringBuilder(Console.ReadLine());
			StringBuilder result = new StringBuilder(char.ToString(startString[startString.Length - 1]));

			int i = startString.Length - 2;
			do
			{
				if (startString[i] != result[0])
				{
					result.Insert(0, startString[i]);
				}
				i--;
			} while (i >= 0);


			Console.WriteLine(result.ToString());
		}
	}
}