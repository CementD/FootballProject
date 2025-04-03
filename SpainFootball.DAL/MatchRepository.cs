using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpainFootball.DAL.Enteties;

namespace SpainFootball.DAL
{
    public class MatchRepository
    {
        private readonly AppDbContext _context;
        public MatchRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void AddRange(List<Match> matches)
        {
            _context.AddRange(matches);
            _context.SaveChanges();
        }

        public void Update(Match match)
        {
            _context.Matches.Update(match);
            _context.SaveChanges();
        }

        public void Delete(Match match)
        {
            _context.Matches.Remove(match);
            _context.SaveChanges();
        }

        public Match GetById(int id)
        {
            return _context.Matches.FirstOrDefault(x => x.Id == id);
        }

        public Match GetByDate(DateTime date)
        {
            return _context.Matches.FirstOrDefault(x => x.Date == date);
        }

        public List<Match> GetAll()
        {
            return _context.Matches.Include(m => m.ScoringPlayers).ToList();
        }

        public List<Match> GetMatchesByDate(DateTime date)
        {
            return _context.Matches
                   .Where(m => m.Date.HasValue && m.Date.Value.Date == date.Date)
                   .ToList();
        }

        public List<Match> GetMatchesByTeam(int teamId)
        {
            return _context.Matches
                    .Where(m => m.Team1Id == teamId || m.Team2Id == teamId)
                    .ToList();
        }

        public List<ScoringPlayer> GetScoringPlayersByDate(DateTime date)
        {
            return _context.Matches
                .Where(m => m.Date.HasValue && m.Date.Value.Date == date.Date)
                .Include(m => m.ScoringPlayers)
                .ThenInclude(sp => sp.Player)
                .SelectMany(m => m.ScoringPlayers)
                .ToList();
        }
    }
}
