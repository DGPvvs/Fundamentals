using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkProjects2_0
{
	class Team
	{
		public Team(string newTimeName, string newCreatorName)
		{
			TimeName = newTimeName;
			CreatorName = newCreatorName;
			Members = new List<string>();
		}

		private string timeName;
		public string TimeName
		{
			get
			{
				return timeName;
			}

			set
			{
				timeName = value;
			}
		}

		private string creatorName;
		public string CreatorName
		{
			get
			{
				return creatorName;
			}

			set
			{
				creatorName = value;
			}
		}

		public List<string> Members { get; set; }

	}// class Team

	class TeamworkProjects2_0
	{
		static void Main(string[] args)
		{
			int teamCount = int.Parse(Console.ReadLine());
			List<Team> teams = new List<Team>();

			for (int i = 0; i < teamCount; i++)
			{
				string[] newTeam = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
				string creatorName = newTeam[0];
				string teamName = newTeam[1];

				Team team = new Team(teamName, creatorName);
				bool isTeamNameExist = teams.Select(n => n.TimeName).Contains(teamName);
				bool isCreatorNameExist = teams.Select(n => n.CreatorName).Contains(creatorName);

				if (!isTeamNameExist)
				{
					if (!isCreatorNameExist)
					{
						teams.Add(team);
						Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
					}
					else
					{
						Console.WriteLine($"{creatorName} cannot create another team!");
					}
				}
				else
				{
					Console.WriteLine($"Team {teamName} was already created!");
				}
			}

			bool isExitLoop = false;

			while (!isExitLoop)
			{
				string teamMembers = Console.ReadLine();

				if (teamMembers == "end of assignment")
				{
					isExitLoop = true;
				}
				else
				{
					string[] commands = teamMembers.Split("->", StringSplitOptions.RemoveEmptyEntries);
					string newUser = commands[0];
					string teamName = commands[1];

					bool isTeamExist = teams.Select(a => a.TimeName).Contains(teamName);

					bool isCreatorExist = teams.Select(a => a.CreatorName).Contains(newUser);
					bool isMemberExist = teams.Select(a => a.Members).Any(x => x.Contains(newUser));

					if (!isTeamExist)
					{
						Console.WriteLine($"Team {teamName} does not exist!");
					}
					else if ((isCreatorExist) || (isMemberExist))
					{
						Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
					}
					else
					{
						int index = teams.FindIndex(a => a.TimeName == teamName);
						teams[index].Members.Add(newUser);

					}
				}
			}

			Team[] teamsToDisband = teams.OrderBy(n => n.TimeName).Where(a => a.Members.Count == 0).ToArray();
			Team[] fullTime = teams.OrderByDescending(n => n.Members.Count).ThenBy(m => m.TimeName).Where(a => a.Members.Count > 0).ToArray();

			StringBuilder sb = new StringBuilder();

			foreach (Team item in fullTime)
			{
				sb.AppendLine($"{item.TimeName}");
				sb.AppendLine($"- {item.CreatorName}");

				foreach (string member in item.Members.OrderBy(x => x))
				{
					sb.AppendLine($"-- {member}");
				}
			}

			sb.AppendLine("Teams to disband:");

			foreach (Team item in teamsToDisband)
			{
				sb.AppendLine(item.TimeName);
			}

			Console.WriteLine(sb.ToString());
		}
	}
}
