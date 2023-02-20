using System;
using System.Collections.Generic;
using System.Text;

namespace A_Miner_Task_02
{
	class A_Miner_Task02
	{
		static void Main(string[] args)
		{
			bool isLoopExit = false;
			StringBuilder sb = new StringBuilder();
			Dictionary<string, int> preciousMetal = new Dictionary<string, int>();

			while (!isLoopExit)
			{
				sb.Clear();
				if (sb.Append(Console.ReadLine()).ToString().ToLower() == "stop")
				{
					isLoopExit = true;
				}
				else
				{
					if (preciousMetal.ContainsKey(sb.ToString()))
					{
						preciousMetal[sb.ToString()] += int.Parse(Console.ReadLine());
					}
					else
					{
						preciousMetal.Add(sb.ToString(), int.Parse(Console.ReadLine()));
					}
				}
			}
			StringBuilder resultSb = new StringBuilder();

			foreach (KeyValuePair<string, int> item in preciousMetal)
			{				
				resultSb.AppendLine($"{item.Key} -> {item.Value}");
			}
			Console.WriteLine(resultSb);
		}
	}
}