using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalFootball.Structure
{
    [Serializable]
    public class Team
    {
        public string Name { get; set; }
        public int Date { get; set; }
        public int EuroPlace { get; set; }
        public int Tropheys { get; set; }
        public string Image { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
