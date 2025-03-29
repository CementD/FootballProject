using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpainFootball.DAL;
namespace SpainFootball
{
    internal class TeamMenu
    {
        TeamService teamService;
        public TeamMenu()
        {
            teamService = new TeamService();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add team");
                Console.WriteLine("2. Show teams");
                Console.WriteLine("3. Remove team");
                Console.WriteLine("4. Update team");
                Console.WriteLine("5. Search team");
                Console.WriteLine("6. Show high scores");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTeam();
                        break;
                    case "2":
                        ShowTeams();
                        break;
                    case "3":
                        RemoveTeam();
                        break;
                    case "4":
                        UpdateTeam();
                        break;
                    case "5":
                        SearchTeam();
                        break;
                    case "6":
                        ShowHighScores();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
                Thread.Sleep(2000);
            }
        }

        private void AddTeam()
        {
            Console.Clear();
            Console.WriteLine("Adding the teamm...\n");

            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the city: ");
            string city = Console.ReadLine();

            Console.Write("Enter the win count: ");
            int winCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the lose count: ");
            int loseCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the draw count: ");
            int drawCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the scored goals count: ");
            int goalsScored = int.Parse(Console.ReadLine());

            Console.Write("Enter the lost goals count: ");
            int goalsLost = int.Parse(Console.ReadLine());

            var team = new Team { Name = name, City = city, WinCount = winCount, LoseCount = loseCount, DrawCount = drawCount, GoalsScored = goalsScored, GoalsLost = goalsLost };

            teamService.Add(team);

            Console.WriteLine("Team is added");
        }
        private void ShowTeams()
        {
            Console.Clear();

            var teams = teamService.GetAll();

            if (teams.Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            PrintTeams(teams);
        }

        private void PrintTeams(List<Team> teams)
        {
            teams = teams.OrderBy(x => x.Name).ToList();
            Console.WriteLine("The list of users (sorted by name): ");
            foreach (var team in teams)
            {
                Console.WriteLine($"ID: {team.Id}, Name: {team.Name}, City: {team.City}, Win count: {team.WinCount}, Lose count: {team.LoseCount}, Draw count: {team.DrawCount}, Goals scored: {team.GoalsScored}, Goals lost {team.GoalsLost}");
            }
        }
        private void PrintTeam(Team team)
        {
            Console.WriteLine($"ID: {team.Id}, Name: {team.Name}, City: {team.City}, Win count: {team.WinCount}, Lose count: {team.LoseCount}, Draw count: {team.DrawCount}, Goals scored: {team.GoalsScored}, Goals lost {team.GoalsLost}");
        }
        private void RemoveTeam()
        {
            Console.Clear();
            Console.Write("Enter the Name to remove: ");
            string teamName = Console.ReadLine();

            var team = teamService.GetByName(teamName);

            if (team == null)
            {
                Console.WriteLine("Team is not found.");
                return;
            }

            teamService.Delete(team);

            Console.WriteLine("Team was removed!");
        }
        private void UpdateTeam()
        {
            Console.Clear();

            Console.Write("Enter the Name to remove: ");
            string teamName = Console.ReadLine();

            var team = teamService.GetByName(teamName);

            if (team == null)
            {
                Console.WriteLine("Team is not found.");
                return;
            }

            Console.WriteLine("Updating team...\n");

            Console.Write("Enter the name: ");
            team.Name = Console.ReadLine();

            Console.Write("Enter the city: ");
            team.City = Console.ReadLine();

            Console.Write("Enter the win count: ");
            team.WinCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the lose count: ");
            team.LoseCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the draw count: ");
            team.DrawCount = int.Parse(Console.ReadLine());

            Console.Write("Enter the scored goals count: ");
            team.GoalsScored = int.Parse(Console.ReadLine());

            Console.Write("Enter the lost goals count: ");
            team.GoalsLost = int.Parse(Console.ReadLine());

            teamService.Update(team);
        }

        private void SearchTeam()
        {
            Console.WriteLine("1. Search by name");
            Console.WriteLine("2. Search by city");
            Console.WriteLine("3. Search by name and city");
            Team team = null;

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    team = teamService.GetByName(name);
                    PrintTeam(team);
                    break;
                case "2":
                    Console.Write("Enter the city: ");
                    string city = Console.ReadLine();
                    team = teamService.GetByName(city);
                    PrintTeam(team);
                    break;
                case "3":
                    Console.Write("Enter the name: ");
                    string name2 = Console.ReadLine();
                    Console.Write("Enter the city: ");
                    string city2 = Console.ReadLine();
                    team = teamService.GetByNameAndCity(name2, city2);
                    PrintTeam(team);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        private void ShowHighScores()
        {
            List<Team> teams = teamService.GetAll();
            Team maxWins = teams[0], maxLosses = teams[0], maxDraws = teams[0], maxGoalsScored = teams[0], maxGoalsLost = teams[0];
            foreach (var team in teams)
            {
                if (team.WinCount > maxWins.WinCount) maxWins = team;
                if (team.LoseCount > maxWins.LoseCount) maxWins = team;
                if (team.DrawCount > maxWins.DrawCount) maxWins = team;
                if (team.GoalsScored > maxWins.GoalsScored) maxWins = team;
                if (team.GoalsLost > maxWins.GoalsLost) maxWins = team;
            }
            Console.WriteLine($"Team max wins:");
            PrintTeam(maxWins);
            Console.WriteLine($"Team max losses:");
            PrintTeam(maxLosses);
            Console.WriteLine($"Team max draws:");
            PrintTeam(maxDraws);
            Console.WriteLine($"Team max goals scored:");
            PrintTeam(maxGoalsScored);
            Console.WriteLine($"Team max goals lost:");
            PrintTeam(maxGoalsLost);
        }
    }
}
