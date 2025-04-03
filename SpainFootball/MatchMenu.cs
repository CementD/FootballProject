using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SpainFootball.DAL;
using SpainFootball.DAL.Enteties;

namespace SpainFootball
{
    internal class MatchMenu
    {
        private TeamService teamService;
        private MatchService matchService;
        private PlayerService playerService;

        public MatchMenu()
        {
            matchService = new MatchService();
            teamService = new TeamService();
            playerService = new PlayerService();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Match Menu:");
                Console.WriteLine("1. Add match");
                Console.WriteLine("2. Update match");
                Console.WriteLine("3. Delete match");
                Console.WriteLine("4. Show all matches");
                Console.WriteLine("5. Show matches by date");
                Console.WriteLine("6. Show matches of a specific team");
                Console.WriteLine("7. Show players who scored on a specific date");
                Console.WriteLine("8. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMatch();
                        break;
                    case "2":
                        UpdateMatch();
                        break;
                    case "3":
                        DeleteMatch();
                        break;
                    case "4":
                        ShowAllMatches();
                        break;
                    case "5":
                        ShowMatchesByDate();
                        break;
                    case "6":
                        ShowMatchesByTeam();
                        break;
                    case "7":
                        ShowScoringPlayersByDate();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
                Thread.Sleep(2000);
            }
        }

        private void AddMatch()
        {
            Console.Clear();
            Console.WriteLine("Adding a match...");

            Console.Write("Enter the team1 id: ");
            int team1Id = int.Parse(Console.ReadLine());

            Team team1 = teamService.GetById(team1Id);
            if (team1 == null)
            {
                Console.WriteLine("There is no team with this Id.");
                return;
            }

            Console.Write("Enter the team2 id: ");
            int team2Id = int.Parse(Console.ReadLine());

            Team team2 = teamService.GetById(team2Id);
            if (team2 == null)
            {
                Console.WriteLine("There is no team with this Id.");
                return;
            }

            Console.Write("Enter the number of team1 goals: ");
            int team1Goals = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of team2 goals: ");
            int team2Goals = int.Parse(Console.ReadLine());

            Console.Write("Enter the match date (yyyy-MM-dd): ");
            DateTime matchDate;
            while (!DateTime.TryParse(Console.ReadLine(), out matchDate))
            {
                Console.Write("Invalid format! Enter the match date again (yyyy-MM-dd): ");
            }

            var match = new Match
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                Team1Goals = team1Goals,
                Team2Goals = team2Goals,
                Date = matchDate, // Сохраняем введенную дату
                ScoringPlayers = new List<ScoringPlayer>()
            };

            matchService.Add(match);

            Console.WriteLine("Players who scored for team 1:");
            for (int i = 0; i < team1Goals; i++)
            {
                Console.Write($"Enter the player ID for goal {i + 1}: ");
                int playerId = int.Parse(Console.ReadLine());

                Player player = playerService.GetById(playerId);
                if (player == null)
                {
                    Console.WriteLine("There is no player with this Id.");
                    continue;
                }

                var scoringPlayer = new ScoringPlayer
                {
                    PlayerId = playerId,
                    MatchId = match.Id.Value,
                };

                match.ScoringPlayers.Add(scoringPlayer);
            }

            Console.WriteLine("Players who scored for team 2:");
            for (int i = 0; i < team2Goals; i++)
            {
                Console.Write($"Enter the player ID for goal {i + 1}: ");
                int playerId = int.Parse(Console.ReadLine());

                Player player = playerService.GetById(playerId);
                if (player == null)
                {
                    Console.WriteLine("There is no player with this Id.");
                    continue;
                }

                var scoringPlayer = new ScoringPlayer
                {
                    PlayerId = playerId,
                    MatchId = match.Id.Value,
                };

                match.ScoringPlayers.Add(scoringPlayer);
            }

            Console.WriteLine($"Match was added successfully on {matchDate:yyyy-MM-dd}.");
        }


        private void UpdateMatch()
        {
            Console.Clear();
            Console.Write("Enter the match id to update: ");
            int matchId = int.Parse(Console.ReadLine());

            Match match = matchService.GetById(matchId);
            if (match == null)
            {
                Console.WriteLine("No match with this Id.");
                return;
            }

            Console.WriteLine("If you don't want to change, press Enter.");

            Console.Write($"Team1 Id ({match.Team1Id}): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) match.Team1Id = int.Parse(input);

            Console.Write($"Team2 Id ({match.Team2Id}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) match.Team2Id = int.Parse(input);

            Console.Write($"Team1 goals ({match.Team1Goals}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) match.Team1Goals = int.Parse(input);

            Console.Write($"Team2 goals ({match.Team2Goals}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) match.Team2Goals = int.Parse(input);

            Console.Write("Enter new scoring players (format: ID,ID,ID...): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                List<ScoringPlayer> newScoringPlayers = new List<ScoringPlayer>();
                var playerIds = input.Split(',').Select(int.Parse);

                foreach (var playerId in playerIds)
                {
                    Player player = playerService.GetById(playerId);
                    if (player == null)
                    {
                        Console.WriteLine($"No player found with ID {playerId}, skipping...");
                        continue;
                    }

                    newScoringPlayers.Add(new ScoringPlayer { PlayerId = playerId, Player = player });
                }

                match.ScoringPlayers = newScoringPlayers;
            }

            Console.Write($"Date ({match.Date}): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) match.Date = DateTime.Parse(input);

            matchService.Update(match);
            Console.WriteLine("Match was updated.");
        }


        private void DeleteMatch()
        {
            Console.Clear();
            Console.Write("Enter the match id to delete: ");
            int matchId = int.Parse(Console.ReadLine());

            Match match = matchService.GetById(matchId);
            if (match == null)
            {
                Console.WriteLine("No match with this Id.");
                return;
            }

            matchService.Delete(match);
            Console.WriteLine("Match was deleted.");
        }

        private void ShowAllMatches()
        {
            Console.Clear();
            var matches = matchService.GetAll();

            if (matches.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            PrintMatches(matches);
        }

        private void PrintMatches(List<Match> matches)
        {
            Console.WriteLine("The list of matches:");
            foreach (var match in matches)
            {
                var players = match.ScoringPlayers.Select(p => $"Player {p.PlayerId}").ToList();
                Console.WriteLine($"ID: {match.Id}, Team1 Id: {match.Team1Id}, Team2 Id: {match.Team2Id}, " +
                                  $"Team1 goals: {match.Team1Goals}, Team2 goals: {match.Team2Goals}, " +
                                  $"Scoring players: {string.Join(", ", players)}, Date: {match.Date:yyyy-MM-dd}");
            }
        }

        private void ShowMatchesByDate()
        {
            Console.Clear();
            Console.Write("Enter the date (yyyy-MM-dd): ");
            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            var matches = matchService.GetMatchesByDate(date);

            if (matches.Count == 0)
            {
                Console.WriteLine("No matches found on this date.");
                return;
            }

            PrintMatches(matches);
        }

        private void ShowMatchesByTeam()
        {
            Console.Clear();
            Console.Write("Enter the team id: ");
            int teamId;
            if (!int.TryParse(Console.ReadLine(), out teamId))
            {
                Console.WriteLine("Invalid team id.");
                return;
            }

            var matches = matchService.GetMatchesByTeam(teamId);

            if (matches.Count == 0)
            {
                Console.WriteLine("No matches found for this team.");
                return;
            }

            PrintMatches(matches);
        }

        private void ShowScoringPlayersByDate()
        {
            Console.Clear();
            Console.Write("Enter the date (yyyy-MM-dd): ");

            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            var players = matchService.GetScoringPlayersByDate(date) ?? new List<ScoringPlayer>(); // Если null, создаём пустой список

            if (players.Count == 0)
            {
                Console.WriteLine("No goals scored on this date.");
                return;
            }

            Console.WriteLine("Players who scored on this date:");
            foreach (var player in players)
            {

                Console.WriteLine($"Player ID: {player.Player.Id}, Name: {player.Player.Name}, Country: {player.Player.Country}");
            }
        }

    }
}

