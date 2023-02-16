using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
	class SoftUniCoursePlanning
	{
        public static void Main()

        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            StringBuilder sb = new StringBuilder();

            bool isExitLoop = false;

            while (!isExitLoop)
            {
                sb.Clear();

                if (sb.Append(Console.ReadLine()).ToString().ToLower() == "course start")
                {
                    isExitLoop = true;
                }
                else
                {
                    List<string> command = sb.ToString().Split(':', '{', '}').ToList();
                    if (command[0] == "Add")
                    {
                        list.Add(command[1]);
                    }
                    else if (command[0] == "Insert")
                    {
                        if (!list.Contains(command[1]))
                        {
                            list.Insert(int.Parse(command[2]), command[1]);
                        }
                    }
                    else if (command[0] == "Remove")
                    {
                        if (list.Contains(command[1]))
                        {
                            list.Remove(command[1]);
                            list.Remove($"{command[1]}-Exercise");                            
                        }
                    }
                    else if (command[0] == "Swap")
                    {

                        if ((list.Contains(command[1])) && (list.Contains(command[2])))
                        {
                            bool isFirstExercise = (list.Remove($"{command[1]}-Exercise"));
                            bool isSecondExercise = (list.Remove($"{command[2]}-Exercise"));
							
							int firstIndex = list.IndexOf(command[1]);
                            int secondIndex = list.IndexOf(command[2]);

                            sb.Clear();
                            sb.Append(list[firstIndex]);
                            list[firstIndex] = list[secondIndex];
                            list[secondIndex] = sb.ToString();             
                                                        
                            if (isSecondExercise)
                            {
                                list.Insert(firstIndex + 1, $"{list[firstIndex]}-Exercise");
                            }

                            if (isFirstExercise)
                            {
                                list.Insert(secondIndex + 1, $"{list[secondIndex]}-Exercise");
                            }
                        }
                    }
					else if (command[0] == "Exercise")
					{
                        if (list.Contains(command[1]))
                        {
							if (!list.Contains($"{command[1]}-Exercise"))
							{
                                int index = list.IndexOf(command[1]);
                                list.Insert(index + 1, $"{command[1]}-Exercise");
                            }                            
                        }
                        else
						{
                            list.Add(command[1]);
                            list.Add($"{command[1]}-Exercise");
						}
                    }
                }
            }

			for (int i = 0; i < list.Count; i++)
			{
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
            
        }
    }
}
//You are tasked to help with the planning of the next Technology Fundamentals course by keeping track of the lessons, that are going to be included in the course, as well as all the exercises for the lessons. 
//On the first line you will receive the initial schedule of the lessons and the exercises that are going to be a part of the next course, separated by comma and space ", ". But before the course starts, some changes should be made. Until you receive "course start" you will be given some commands to modify the course schedule. The possible commands are: 
//Add: { lessonTitle} – add the lesson to the end of the schedule, if it does not exist.
//Insert:{ lessonTitle}:{ index} – insert the lesson to the given index, if it does not exist.
//Remove:{ lessonTitle} – remove the lesson, if it exists.
//Swap:{ lessonTitle}:{ lessonTitle} – change the place of the two lessons, if they exist.
//Exercise:{ lessonTitle} – add Exercise in the schedule right after the lesson index, if the lesson exists and there is no exercise already, in the following format "{lessonTitle}-Exercise". If the lesson doesn`t exist, add the lesson in the end of the course schedule, followed by the Exercise.
//Each time you Swap or Remove a lesson, you should do the same with the Exercises, if there are any, which follow the lessons.
//Input / Constraints
//•	first line – the initial schedule lessons – strings, separated by comma and space ", "
//•	until "course start" you will receive commands in the format described above
//Output
//•	Print the whole course schedule, each lesson on a new line with its number(index) in the schedule: 
//"{lesson index}.{lessonTitle}"
//•	Allowed working time / memory: 100ms / 16MB.
//Вие сте натоварен с планирането на следващия курс за основите на технологиите, като следите уроците, които ще бъдат включени в курса, както и всички упражнения за уроците.
//На първия ред ще получите първоначалния график на уроците и упражненията, които ще бъдат част от следващия курс, разделени със запетая и интервал ", ".
//Но преди началото на курса трябва да се направят някои промени.
//Докато получите "старт на курса" ще ви бъдат дадени някои команди за промяна на графика на курса.
//Възможните команди са:
//Добавете: { lessonTitle} – добавете урока в края на графика, ако той не съществува.
//Вмъкване:{ lessonTitle}:{ index} – вмъкнете урока в дадения индекс, ако той не съществува.
//Премахване:{ lessonTitle} – премахнете урока, ако съществува.
//Разменени: { lessonTitle}:{ lessonTitle} – променете мястото на двата урока, ако съществуват.
//Упражнение:{ lessonTitle} – добавете Упражнение в графика веднага слединдекса на урока , ако урока съществува и няма вече никакво упражнение, в следния формат "{lessonTle}-Упражнение". Ако урокът не съществува, добавете урока в края на курса, следван от упражнението.
//Всеки път, когато разменяте или премахвате урок, трябва да направите същото с упражненията, ако има такива, които следват уроците.
//Вход / Ограничения
//•         първи ред – първоначалните уроци по график – низове, разделени със запетая и интервал ", "
//•         докато "курс старт" ще получите команди във формата, описан по-горе
//изход
//•         Отпечатайте целия курс график, всеки урок на нов ред с неговия номер(индекс) в графика:
//"{индекс на уроците}. {урок",
//•         Позволено работно време / памет: 100ms / 16MB.
