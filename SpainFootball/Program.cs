using SpainFootball.DAL;
using SpainFootball.DAL;

namespace SpainFootball
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TeamService teamService = new TeamService();
            PlayerService playerService = new PlayerService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Spain Football Management");
                Console.WriteLine("1 - Team Management");
                Console.WriteLine("2 - Player Management");
                Console.WriteLine("3 - Match Management");
                Console.WriteLine("4 - Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new TeamMenu().ShowMenu();
                        break;
                    case "2":
                        new PlayerMenu().ShowMenu();
                        break;
                    case "3":
                        var teams = teamService.GetAll();
                        if (teams.Count < 2)
                        {
                            Console.WriteLine("You must add at least TWO teams before managing matches!");
                            Thread.Sleep(2000);
                            break;
                        }
                        new MatchMenu().ShowMenu();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Incorrect input! Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
    }
}

