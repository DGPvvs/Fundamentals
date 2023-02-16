using System;
using System.Linq;

namespace Array_Modifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isExitLoop = false;

            while (!isExitLoop)
            {
                string input = Console.ReadLine();
                if (input.ToLower().Equals("end"))
                {
                    isExitLoop = true;
                }
                else
                {
                    string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = commands[0];

                    switch (command.ToLower())
                    {
                        case "swap":
                            int index1 = int.Parse(commands[1]);
                            int index2 = int.Parse(commands[2]);
                            int swapInt = arr[index1];
                            arr[index1] = arr[index2];
                            arr[index2] = swapInt;
                    break;
                        case "multiply":
                            index1 = int.Parse(commands[1]);
                            index2 = int.Parse(commands[2]);
                            arr[index1] *= arr[index2];
                            break;
                        case "decrease":
                            for (int i = 0; i < arr.Length; i++)
                            {
                                arr[i]--;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
//You are given an array with integers.
//Write a program to modify the elements after receive the commands “swap”, “multiply” or “decrease”.
//•	“swap {index1} { index2}” take two elements and swap their places.
//•	“multiply {index1} { index2}” take element at the 1st index and multiply it with element at 2nd index. Save the product at the 1st index.
//•	“decrease” decreases all elements in the array with 1.
//Input
//On the first input line you will be given the initial array values separated by a single space.
//On the next lines you will receive commands until you receive the command “end”. The commands are as follow: 
//•	“swap
//{ index1}
//{ index2}”
//•	“multiply
//{ index1}
//{ index2}”
//•	“decrease”
//Output
//The output should be printed on the console and consist element of the modified array – separated by “, “(comma and single space).
//Constraints
//•	Commands will be: “swap”, “multiply”, “decrease” and “end”
//•	Elements of the array will be integer numbers in the range [-231...231]
//•	Count of the array elements will be in the range [2...100]
//•	Indexes will be always in the range of the array

//    Даден ви е масив с цяло число.
//    Напишете програма за модифициране на елементите,
//    след като получите командите "суап", "умножете" или "намалете".
//•         "суап {index1} {index2}" вземете два елемента и разменете местата им.
//•         "умножете {index1} {index2}" вземете елемент при 1-ви индекс
//и го умножете с елемент при 2-ри индекс. Запишете продукта на индекса 1st.
//•         "намалява" намалява всички елементи в масива с 1.
//1.	Въвеждане
//На първия входен ред ще ви бъдат дадени стойностите на първоначалния масив,
//разделени с едно пространство.
//На следващите редове ще получавате команди, докато не получите командата "край".
//Командите са следните:
//•         "разменете {index1} {index2}"
//•         "умножете {index1} {index2}"
//•         "намаляване"
//2.Изход
//Изходът трябва да бъде отпечатан на конзолата и да се състои елемент от модифицирания масив – разделен с ", "( запетая и единичнопространство).
//3.Ограничения
//•         Командите ще бъдат: "суап", "умножете", "намалете" и "край"
//•         Елементи на масива ще бъдат цели числа в диапазона [-2 31... 231]
//•         Брой на елементите на масива ще бъде в диапазона [2...100]
//•         Индексите ще бъдат винаги в диапазона на масива
