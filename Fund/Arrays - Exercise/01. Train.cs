using System;

namespace Train
{
	class Train
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int[] arr = new int[n];
			int sum = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = int.Parse(Console.ReadLine());
				sum += arr[i];
			}

			Console.WriteLine($"{string.Join(" ", arr)}\n{sum}");
		}
	}
}
//You will be given a count of wagons in a train n.
//On the next n lines you will receive how many people are going to get on each wagon. At the end print the whole train and after that, on the next line, the sum of the people in the train. 
//Ще ви бъде дадена броене на вагони във влак n.
//На следващите n линии ще получите колко хора ще получите на всеки вагон.
//В края на печат целия влак и след това, на следващия ред, сумата на хората във влака.