using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles
{
	class Articles
	{
		public class Article
		{
			private string title;

			public string Title 
			{
				get
				{
					return title;
				}

				set
				{
					title = value;
				}
			}// public string Title

			private string content;

			public string Content
			{
				get
				{
					return content;
				}

				set
				{
					content = value;
				}
			}// public string Content

			private string author;

			public string Author
			{
				get
				{
					return author;
				}

				set
				{
					author = value;
				}
			}// public string Author

			public Article()
			{

			}// public Article()

			public Article(string newTitle, string newContent, string newAuthor)
			{
				this.Title = newTitle;
				this.Content = newContent;
				this.Author = newAuthor;
			}// public Article(string newTitle, string newContent, string newAuthor)

			public void Edit(string newContent)
			{
				this.Content = newContent;
			}// void Edit(string newContent)

			public void ChangeAuthor(string newAuthor)
			{
				this.Author = newAuthor;
			}//void ChangeAuthor(string newAuthor)

			public void Rename(string newTitle)
			{
				this.Title = newTitle;
			}// void Rename(string newTitle)

			public override string ToString()
			{
				return $"{this.Title} - {this.Content}: {this.Author}";
			}// override string ToString()

		}// class Article

		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder(Console.ReadLine());

			List<string> command = sb.ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

			Article article = new Article(command[0], command[1], command[2]);

			int numCommands = int.Parse(Console.ReadLine());

			for (int i = 0; i < numCommands; i++)
			{
				sb.Clear();
				command.Clear();
				sb = new StringBuilder(Console.ReadLine());
				command = sb.ToString().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();
				switch (command[0].ToLower())
				{
					case "edit":
						article.Edit(command[1]);
						break;
					case "changeauthor":
						article.ChangeAuthor(command[1]);
						break;
					case "rename":
						article.Rename(command[1]);
						break;
					default:
						break;
				}
			}

			Console.WriteLine(article.ToString());
		}
	}
}
//Create a class Article with the following properties:
//•	Title – a string
//•	Content – a string
//•	Author – a string
//The class should have a constructor and the following methods:
//•	Edit(new content) – change the old content with the new one
//•	ChangeAuthor(new author) – change the author
//•	Rename (new title) – change the title of the article
//•	Override the ToString method – print the article in the following format: 
//"{title} - {content}: {author}"
//Write a program that reads an article in the following format "{title}, {content}, {author}". On the next line, you will receive a number n, representing the number of commands, which will follow after it. On the next n lines, you will be receiving the following commands: "Edit: {new content}"; "ChangeAuthor: {new author}"; "Rename: {new title}".At the end, print the final state of the article.
//Създаване на клас статия със следните свойства:
//•         Заглавие – низ
//•         Съдържание – низ
//•         Автор – низ
//Класът трябва да има конструктор и следните методи:
//•         Редактиране(ново съдържание)) -променете старото съдържание с новото
//•         ChangeAuthor (нов автор) -промяна на автора
//•         Преименуване (ново заглавие) – промяна на заглавието на статията
//•         Заместване на метода tostring – отпечатайте статията в следния формат:
//"{заглавие} - {content}: {автор}"
//Напишете програма, която чете статия в следния формат "{title}, {content}, {author}". На следващия ред ще получите число n, представляващ броя команди, които ще последват след него. На следващите n редове ще получите следните команди: "Редактиране: {ново съдържание}"; "Промяна на автора: {нов автор}"; "Преименуване: {ново заглавие}" - Не, не, В крайна сметка отпечатайте окончателното състояние на статията.
