using Microsoft.EntityFrameworkCore;
using SpainFootball.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpainFootball
{
    internal class TeamService
    {
        private readonly TeamRepository _teamRepos;
        public TeamService()
        {
            _teamRepos = new TeamRepository();
        }
        public void Add(Team team)
        {
            _teamRepos.Add(team);
        }

        public void AddRange(List<Team> teams)
        {
            _teamRepos.AddRange(teams);
        }
        public void Update(Team team)
        {
            _teamRepos.Update(team);
        }

        public void Delete(Team team)
        {
            _teamRepos.Delete(team);
        }

        public Team GetByName(string name)
        {
            return _teamRepos.GetByName(name);
        }

        public Team GetByCity(string city)
        {
            return _teamRepos.GetByCity(city);
        }

        public Team GetByNameAndCity(string name, string city)
        {
            return _teamRepos.GetByNameAndCity(name, city);
        }

        public List<Team> GetAll()
        {
            return _teamRepos.GetAll();
        }
    }
}
