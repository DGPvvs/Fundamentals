using System;
using System.Text;


namespace Extract_File
{
	class ExtractFile
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder(Console.ReadLine());
			StringBuilder expandFile = new StringBuilder();
			StringBuilder nameFile = new StringBuilder();
			bool flagExpand = true;
			bool flagFileName = true;
			int i = sb.Length - 1;
			while (i >= 0 && flagExpand)
			{
				if (sb[i] != '.' && flagExpand)
				{
					expandFile.Insert(0, sb[i]);
				}
				else
				{
					flagExpand = false;
				}
				i--;
			}

			while (i >= 0 && flagFileName)
			{
				if (sb[i] != '\\' && !flagExpand)
				{
					nameFile.Insert(0, sb[i]);
				}
				else
				{
					flagFileName = false;
				}
				i--;
			}

			sb.Clear();
			sb.AppendLine($"File name: {nameFile.ToString()}");
			sb.AppendLine($"File extension: {expandFile}");
			Console.WriteLine(sb.ToString());
		}
	}
}