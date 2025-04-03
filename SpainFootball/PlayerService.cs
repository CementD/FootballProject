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
    public class PlayerService
    {
        private readonly PlayerRepository _playerRepos;
        public PlayerService()
        {
            _playerRepos = new PlayerRepository();
        }

        public void Add(Player player)
        {
            _playerRepos.Add(player);
        }

        public void AddRange(List<Player> players)
        {
            _playerRepos.AddRange(players);
        }

        public void Update(Player player)
        {
            _playerRepos.Update(player);
        }

        public void Delete(Player player)
        {
            _playerRepos.Delete(player);
        }

        public Player GetById(int id)
        {
            return _playerRepos.GetById(id);
        }

        public Player GetByName(string name)
        {
            return _playerRepos.GetByName(name);
        }
        public List<Player> GetAll()
        {
            return _playerRepos.GetAll();
        }
    }
}
