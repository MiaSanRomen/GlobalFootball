using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalFootball.Structure
{
    [Serializable]
    public class Player
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Position { get; set; }
            public string Image { get; set; }
            public int Years { get; set; }
            public int Goals { get; set; }
            public int[] Price { get; set; } = new int[5];
        }
    
}
