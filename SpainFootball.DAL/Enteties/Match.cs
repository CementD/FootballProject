using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpainFootball.DAL.Enteties
{
    public class Match
    {
        public int? Id { get; set; }
        public int? Team1Id { get; set; }
        public Team? Team1 { get; set; }
        public int? Team2Id { get; set; }
        public Team? Team2 { get; set; }
        public int? Team1Goals { get; set; }
        public int? Team2Goals { get; set; }
        public DateTime? Date { get; set; }
        public List<ScoringPlayer> ScoringPlayers { get; set; } = new List<ScoringPlayer>();
    }
}
