using System;
using System.Text;

namespace Caesar_Cipher
{
	class CaesarCipher
	{
		static void Main(string[] args)
		{
			StringBuilder start = new StringBuilder(Console.ReadLine());
			StringBuilder result = new StringBuilder();

			foreach (char i in start.ToString())
			{
				result.Append((char)((int)i + 3));
			}

			Console.WriteLine(result.ToString());
		}
	}
}