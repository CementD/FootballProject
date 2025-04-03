using Microsoft.EntityFrameworkCore;
namespace SpainFootball.DAL
{
    public class TeamRepository
    {
        private readonly AppDbContext _context;
        public TeamRepository() {
            _context = new AppDbContext();
            //_context.Database.EnsureCreated();
        }

        public void Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void AddRange(List<Team> teams)
        {
            _context.AddRange(teams);
            _context.SaveChanges();
        }

        public void Update(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }

        public void Delete(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

        public Team GetById(int id)
        {
            return _context.Teams.FirstOrDefault(x => x.Id == id);
        }

        public Team GetByName(string name)
        {
            return _context.Teams.FirstOrDefault(x => x.Name == name);
        }

        public Team GetByCity(string city)
        {
            return _context.Teams.FirstOrDefault(x => x.City == city);
        }

        public Team GetByNameAndCity(string name, string city)
        {
            return _context.Teams.FirstOrDefault(x => x.Name == name && x.City == city);
        }

        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }
    }
}
