using Microsoft.EntityFrameworkCore;
using SpainFootball.DAL;
using SpainFootball.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpainFootball
{
    public class MatchService
    {
        private readonly MatchRepository _matchRepos;

        public MatchService()
        {
            _matchRepos = new MatchRepository();
        }

        public void Add(Match match)
        {
            _matchRepos.Add(match);
        }

        public void AddRange(List<Match> matches)
        {
            _matchRepos.AddRange(matches);
        }

        public void Update(Match match)
        {
            _matchRepos.Update(match);
        }

        public void Delete(Match match)
        {
            _matchRepos.Delete(match);
        }

        public Match GetById(int id)
        {
            return _matchRepos.GetById(id);
        }

        public Match GetByDate(DateTime date)
        {
            return _matchRepos.GetByDate(date);
        }

        public List<Match> GetAll()
        {
            return _matchRepos.GetAll();
        }

        public List<Match> GetMatchesByDate(DateTime date)
        {
            return _matchRepos.GetMatchesByDate(date);
        }

        public List<Match> GetMatchesByTeam(int teamId)
        {
            return _matchRepos.GetMatchesByTeam(teamId);
        }

        public List<ScoringPlayer> GetScoringPlayersByDate(DateTime date)
        {
            return _matchRepos.GetScoringPlayersByDate(date);
        }
    }
}
