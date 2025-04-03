using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpainFootball.DAL;
using SpainFootball.DAL.Enteties;

namespace SpainFootball
{
    internal class PlayerMenu
    {
        private PlayerService playerService;
        private TeamService teamService;

        public PlayerMenu()
        {
            playerService = new PlayerService();
            teamService = new TeamService();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player Menu:");
                Console.WriteLine("1. Add player");
                Console.WriteLine("2. Update player");
                Console.WriteLine("3. Delete player");
                Console.WriteLine("4. Show all players");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPlayer();
                        break;
                    case "2":
                        UpdatePlayer();
                        break;
                    case "3":
                        DeletePlayer();
                        break;
                    case "4":
                        ShowAllPlayers();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
                Thread.Sleep(2000);
            }
        }

        private void AddPlayer()
        {
            Console.Clear();
            Console.WriteLine("Adding a new player...");

            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            Console.Write("Enter player country: ");
            string country = Console.ReadLine();

            Console.Write("Enter player number: ");
            int playerNum = int.Parse(Console.ReadLine());

            Console.Write("Enter player position: ");
            string position = Console.ReadLine();

            Console.Write("Enter team ID: ");
            int teamId = int.Parse(Console.ReadLine());

            var team = teamService.GetById(teamId);

            if (team != null)
            {
                var player = new Player
                {
                    Name = name,
                    Country = country,
                    PlayerNum = playerNum,
                    Position = position,
                    TeamId = teamId
                };
                team.Players.Add(player);
                playerService.Add(player);
                Console.WriteLine("Player successfully added.");
            }
            else Console.WriteLine("Team was not found.");
        }

        private void UpdatePlayer()
        {
            Console.Clear();
            Console.Write("Enter the player ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int playerId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var player = playerService.GetById(playerId);
            if (player == null)
            {
                Console.WriteLine("No player found with this ID.");
                return;
            }

            Console.WriteLine("Press Enter to skip any field you don't want to change.");

            Console.Write($"Name ({player.Name}): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) player.Name = input;

            Console.Write($"Country ({player.Country}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) player.Country = input;

            Console.Write($"Player number ({player.PlayerNum}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int num))
                player.PlayerNum = num;

            Console.Write($"Position ({player.Position}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) player.Position = input;

            Console.Write($"Team ID ({player.TeamId?.ToString() ?? "None"}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int teamId))
            {
                var team = teamService.GetById(teamId);
                if (team == null)
                {
                    Console.WriteLine("No team found with this ID.");
                    return;
                }
                player.TeamId = teamId;
                player.Team = team;
            }

            playerService.Update(player);
            Console.WriteLine("Player updated successfully.");
        }

        private void DeletePlayer()
        {
            Console.Clear();
            Console.Write("Enter the player ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int playerId))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var player = playerService.GetById(playerId);
            if (player == null)
            {
                Console.WriteLine("No player found with this ID.");
                return;
            }

            playerService.Delete(player);
            Console.WriteLine("Player deleted successfully.");
        }

        private void ShowAllPlayers()
        {
            Console.Clear();
            var players = playerService.GetAll();
            Console.WriteLine($"Found {players.Count} players.");

            if (players.Count == 0)
            {
                Console.WriteLine("No players found.");
                return;
            }

            Console.WriteLine("List of Players:");
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Name: {player.Name}, Country: {player.Country}, " +
                                  $"Number: {player.PlayerNum}, Position: {player.Position}, " +
                                  $"Team: {(player.Team != null ? player.Team.Name : "No team")}");
            }
        }
    }
}

