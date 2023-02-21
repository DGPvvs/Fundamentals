using System;
using System.Text;

namespace String_Explosion
{
	class StringExplosion
	{
		static void Main(string[] args)
		{
            StringBuilder startString = new StringBuilder(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int power = 0;
            bool nextPower = false;

            for (int i = 0; i < startString.Length; i++)
			{
                bool isAppend = ((power == 0) && (startString[i] != '>') && (!nextPower)); 
				if (isAppend)
				{
                    result.Append(startString[i]);
				}
				else if (nextPower)
				{
                    power += int.Parse(char.ToString(startString[i]));
                    nextPower = false;
                    power--;
                }
                else if (startString[i] == '>')
				{
                    result.Append(startString[i]);
                    nextPower = true;
				}
				else if (power > 0)
				{
                    power--;
				}
			}
            
            Console.WriteLine(result.ToString());
        }
	}
}