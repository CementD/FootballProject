using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpainFootball.DAL.Enteties
{
    public class Player
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public int? PlayerNum { get; set; }
        public string? Position { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public List<ScoringPlayer> ScoringPlayers { get; set; }
    }
}
