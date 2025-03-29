using SpainFootball.DAL;
namespace SpainFootball
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new TeamMenu();
            menu.ShowMenu();
        }
    }
}
