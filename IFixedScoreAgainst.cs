using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    interface IFixedScoreAgainst
    {
        Dictionary<string, int> fixedByTeams { get; set; }

        public int ModifyScore(AbstractTeam adversary, int score)
        {
            if (fixedByTeams != null && fixedByTeams.ContainsKey(adversary.name))
            {
                return fixedByTeams[adversary.name];
            }
            else
            {
                return score;
            }
        }
    }
}
