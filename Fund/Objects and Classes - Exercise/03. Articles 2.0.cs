using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles_2._0
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

	class Articles2_0
	{
		static void Main(string[] args)
		{
			int numCommands = int.Parse(Console.ReadLine());

			List<Article> articles = new List<Article>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < numCommands; i++)
			{
				sb.Clear();
				sb.Append(Console.ReadLine());
				List<string> commands = sb.ToString().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
				Article article = new Article(commands[0], commands[1], commands[2]);
				articles.Add(article);
			}

			foreach (Article item in articles)
			{
				Console.WriteLine(item.ToString());
			}
			
		}
	}
}
//Change the program in such a way, that you will be able to store a list of articles. You will not need to use the previous methods any more (except the ToString method). On the first line, you will receive the number of articles. On the next lines, you will receive the articles in the same format as in the previous problem: "{title}, {content}, {author}".Finally, you will receive a string: "title", "content" or an "author". You need to order the articles alphabetically, based on the given criteria. 
//	Променете програмата по такъв начин, че да можете да съхранявате списък със статии. Няма да е необходимо да използвате предишните методи повече (с изключение на метода на ToString ). На първия ред ще получите броя на статиите. На следващите редовеще получите статиите в същия формат като в предишния проблем: "{title}, {content}, {author}".И накрая, ще получите низ: "заглавие", "съдържание" или "автор".Трябва да поръчате статиите по азбучен ред, въз основа на дадените критерии.