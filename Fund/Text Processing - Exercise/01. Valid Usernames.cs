using System;
using System.Text;

namespace Valid_Usernames
{
	class ValidUsernames
	{
		static bool IsSpace(char sh)
		{
			bool isCorrect = false;
			if (sh == ' ')
			{
				isCorrect = true;
			}			
			return isCorrect;
		}

		static bool IsUnderScore(char sh)
		{
			bool isCorrect = false;
			if (sh == '_')
			{
				isCorrect = true;
			}			
			return isCorrect;
		}

		static bool IsDash(char sh)
		{
			bool isCorrect = false;
			if (sh == '-')
			{
				isCorrect = true;
			}			
			return isCorrect;
		}

		static bool IsCorrectSymbols(string word)
		{
			bool isCorrect = true;
			foreach (char sh in word)
			{
				isCorrect = (isCorrect && !(!char.IsLetterOrDigit(sh) && sh != '_' && sh != '-'));
			}
			return isCorrect;
		}

		static void Main(string[] args)
		{
			string[] words = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
			
			foreach (string word in words)
			{
				bool isCorrect = ((word.Length >= 3) && (word.Length <= 16));			
				isCorrect = (isCorrect && IsCorrectSymbols(word));				
				if (isCorrect)
				{
					Console.WriteLine(word);
				}
			}
		}
	}
}