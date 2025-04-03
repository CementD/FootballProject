using Microsoft.EntityFrameworkCore;
using SpainFootball.DAL.Enteties;

namespace SpainFootball.DAL
{
    public class PlayerRepository
    {
        private readonly AppDbContext _context;
        public PlayerRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void AddRange(List<Player> players)
        {
            _context.AddRange(players);
            _context.SaveChanges();
        }

        public void Update(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }

        public void Delete(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public Player GetById(int id)
        {
            return _context.Players.FirstOrDefault(x => x.Id == id);
        }

        public Player GetByName(string name)
        {
            return _context.Players.FirstOrDefault(x => x.Name == name);
        }
        public List<Player> GetAll()
        {
            return _context.Players.Include(t => t.Team).ToList();
        }
    }
}
