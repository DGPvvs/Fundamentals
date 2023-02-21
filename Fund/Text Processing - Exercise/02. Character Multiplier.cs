using System;
using System.Text;
using System.Linq;

namespace Character_Multiplier
{
	class CharacterMultiplier
	{
		public static int CalcSum(StringBuilder firstStr, StringBuilder secondStr)
		{
			int result = 0;

			for (int i = secondStr.Length; i < firstStr.Length; i++)
			{
				result += (int)firstStr[i];
			}

			for (int i = 0; i < secondStr.Length; i++)
			{
				result += ((int)firstStr[i] * (int)secondStr[i]);
			}

			return result;
		}// int CalcSum(StringBuilder firstStr, StringBuilder secondStr)

		static void Main(string[] args)
		{
			string[] str = Console.ReadLine().Split(' ').ToArray();

			StringBuilder str1 = new StringBuilder(str[0]);
			StringBuilder str2 = new StringBuilder(str[1]);

			if (str1.Length >= str2.Length)
			{
				Console.WriteLine($"{CalcSum(str1, str2)}");
			}
			else
			{
				Console.WriteLine($"{CalcSum(str2, str1)}");
			}
		}
	}
}