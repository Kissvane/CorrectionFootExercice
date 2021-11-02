using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    class RandomScoreTeam : AbstractTeam
    {
        int minimumScore = 0;
        int maximumScore = 0;

        public RandomScoreTeam(string name, Dictionary<string, int> fixedByTeams = null, Dictionary<string, int> minimumByTeams = null, Dictionary<string, int> maximumByTeams = null, int modifier = 0, bool alwaysWinInProlongation = false, bool alwaysLooseInProlongation = false,int minimumScore = 0, int maximumScore = 10) : base(name, fixedByTeams, minimumByTeams, maximumByTeams, modifier, alwaysWinInProlongation, alwaysLooseInProlongation)
        {
            this.maximumScore = maximumScore;
            this.minimumScore = minimumScore;
        }

        protected override int CalculateScore(AbstractTeam adversary)
        {
            return random.Next(minimumScore,maximumScore+1);
        }
    }
}
