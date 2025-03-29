using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpainFootball.DAL
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int WinCount { get; set; }
        public int LoseCount { get; set; }
        public int DrawCount { get; set; }
        public int? GoalsScored {  get; set; }
        public int? GoalsLost { get; set; }
    }
}
