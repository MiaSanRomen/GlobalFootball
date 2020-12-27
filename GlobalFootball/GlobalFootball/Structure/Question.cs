using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalFootball.Structure
{
    class Question
    {
        public string MainQuestion { get; set; }
        public int Right { get; set; }
        public string[] Answers { get; set; } = new string[3];
    }
}
