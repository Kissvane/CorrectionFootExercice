using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    interface IMinimumScoreAgainst
    {
        Dictionary<string, int> minimumByTeams { get; set; }

        public int ModifyScore(AbstractTeam adversary, int score)
        {
            if (minimumByTeams!= null && minimumByTeams.ContainsKey(adversary.name))
            {
                return Math.Max(minimumByTeams[adversary.name], score);
            }
            else
            {
                return score;
            }
        }
    }
}
