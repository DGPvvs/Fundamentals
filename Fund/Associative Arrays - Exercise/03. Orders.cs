using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
	public class ProductParam
	{
		public ProductParam(int newQuantity, decimal newPrice)
		{
			Quantity = newQuantity;
			Price = newPrice;
		}

		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}// class ProductParam

	class Orders
	{
		static void Main(string[] args)
		{
			Dictionary<string, ProductParam> products = new Dictionary<string, ProductParam>();

			bool isLoopExit = false;

			while (!isLoopExit)
			{
				List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
				if (input[0] == "buy")
				{
					isLoopExit = true;
				}
				else
				{
					string nameKey = input[0];
					decimal price = decimal.Parse(input[1]);
					int qnt = int.Parse(input[2]);
					if (products.ContainsKey(nameKey))
					{
						products[nameKey].Price = price;
						products[nameKey].Quantity += qnt;
					}
					else
					{
						products.Add(nameKey, new ProductParam(qnt, price));
					}
				}
			}

			foreach (KeyValuePair<string, ProductParam> item in products)
			{
				Console.WriteLine($"{item.Key} -> {(item.Value.Price * item.Value.Quantity):F2}");
			}

			
		}
	}
}