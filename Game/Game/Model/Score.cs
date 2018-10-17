using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    class Score
    {
        public string Name;
        public int PlayerScore;

        public Score(string n, int s)
        {
            Name = n;
            PlayerScore = s;
        }
        
    }
}
