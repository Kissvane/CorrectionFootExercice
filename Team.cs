using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    class Team
    {
        public string name { get; private set; }
        Random random;
        
        public Team(string name)
        {
            this.name = name;
            random = new Random(Program.NameToInt(name));
        }

        public int CalculateScore()
        {
            return random.Next(0,11);
        }
    }
}
