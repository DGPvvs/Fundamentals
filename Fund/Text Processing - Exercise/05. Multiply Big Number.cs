using System;
using System.Text;

namespace Multiply_Big_Number
{
	class MultiplyBigNumber
	{
		static void Main(string[] args)
		{
			StringBuilder multiplicable = new StringBuilder(Console.ReadLine());
			StringBuilder result = new StringBuilder();

			int multiplier = int.Parse(Console.ReadLine());
			int residue = 0;

			int i = multiplicable.Length - 1;
			do
			{
				int a = int.Parse(char.ToString(multiplicable[i])) * multiplier;
				int n = a % 10;
				n += residue;
				int k = n % 10;
				result.Insert(0, k);
				n = n / 10;
				residue = n + a / 10;
				i--;
			} while (i >= 0);

			if (residue > 0)
			{
				result.Insert(0, residue);
			}

			bool isAllZero = true;
			i = result.Length - 1;
			
			while(i > 0 && isAllZero)
			{
			    if (result[i] != '0')
				{
					isAllZero = false;
				}
				i--;
			}

			if (isAllZero)
			{
				result.Clear();
				result.Append("0");
			}

			Console.WriteLine(result.ToString());
		}
	}
}