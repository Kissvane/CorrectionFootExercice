using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    interface IMaximumScoreAgainst
    {
        Dictionary<string, int> maximumByTeams { get; set; }

        public int ModifyScore(AbstractTeam adversary, int score)
        {
            if (maximumByTeams != null && maximumByTeams.ContainsKey(adversary.name))
            {
                return Math.Min(maximumByTeams[adversary.name], score);
            }
            else
            {
                return score;
            }
        }
    }
}
