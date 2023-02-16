using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            List<int> topFiveNum = new List<int>();

            double avverage = numbers.Average();

            foreach (int item in numbers)
            {
                if (item > avverage)
                {
                    topFiveNum.Add(item);
                }
            }

            topFiveNum = topFiveNum.OrderByDescending(top => top).ToList();
            StringBuilder sb = new StringBuilder();

            if (topFiveNum.Count > 0)
            {
                int k = topFiveNum.Count;
                if (topFiveNum.Count > 5)
                {
                    k = 5;
                }
                for (int i = 0; i < k; i++)
                {
                    sb.Append($"{topFiveNum[i]} ");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
//Write a program to read a sequence of integers and find and print the top 5 numbers that are greater than the average value in the sequence, sorted in descending order.
//Input
//Read from the console a single line holding space separated number.
//Output
//Print the above described numbers on a single line, space separated. If less than 5 numbers hold the above mentioned property, print less than 5 numbers. Print “No” if no numbers hold the above property.
//Constraints
//All input numbers are integers in range [-1 000 000 … 1 000 000]. The count of numbers is in range [1…10 000].

//Напишете програма, за да прочетете последователност от цяло число и да намерите
//и отпечатате първите 5 числа, които са по-големи от средната стойност в последователността,
//сортирани в низходящ ред.
//1.	Въвеждане
//Прочетете от конзолата един ред холдинг пространство отделен номер.
//2.	Изход
//Отпечатайте описаните по-горе числа на един ред, интервалът е разделен. Ако по-малко от 5 номера държат горепосоченото свойство, отпечатайте по-малко от 5 номера. Печат на "Не", ако никакви номера не държат горепосоченото свойство.
//3.	Ограничения
//Всички входни номера са цяло число в обхват [-1 000 000 ... 1 000 000]. Броят на числата е в обхват [1... 10 000].
