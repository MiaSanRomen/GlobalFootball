using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalFootball.Structure
{
    [Serializable]
    public class League
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Date { get; set; }
        public int EuroPlace { get; set; }
        public string Image { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
