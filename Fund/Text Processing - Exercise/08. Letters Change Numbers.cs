using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Letters_Change_Numbers
{
	class LettersChangeNumbers
	{
		static void Main(string[] args)
		{
            List<string> words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            
            double sum = 0;            

            foreach (string s in words)
            {
                double result = 0;
                
                char firstChar = s[0];
                char lastChar = s[s.Length - 1];
                double firstOperand = double.Parse(s.Substring(1, s.Length - 2));
                
                char[] sh = firstChar.ToString().ToLower().ToCharArray();
                double secondOperand = (double)((int)(sh[0]) - 96);

                sh = lastChar.ToString().ToLower().ToCharArray();
                double thirdOperand = (double)((int)(sh[0]) - 96);

                if (char.IsUpper(firstChar))
                {
                    result = firstOperand / secondOperand;                    
                }
                else
                {
                    result = firstOperand * secondOperand;
                }

                if (char.IsUpper(lastChar))
                {
                    result = result - thirdOperand;
                }
                else
                {
                    result = result + thirdOperand;
                }
                
                sum += result;
            }

            Console.WriteLine($"{sum:F2}");
        }
	}
}