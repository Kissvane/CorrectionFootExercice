using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    abstract class AbstractTeam : IMinimumScoreAgainst, IMaximumScoreAgainst, IFixedScoreAgainst, IScoreModifier
    {
        public string name { get; protected set; }
        public Dictionary<string, int> minimumByTeams { get; set; }
        public Dictionary<string, int> maximumByTeams { get ; set; }
        public Dictionary<string, int> fixedByTeams { get; set; }
        public int modifier { get; set; }
        public bool alwaysWinInProlongation = false;
        public bool alwaysLooseInProlongation = false;

        protected Random random;

        public AbstractTeam(string name, Dictionary<string, int> fixedByTeams, Dictionary<string, int> minimumByTeams, Dictionary<string, int> maximumByTeams, int modifier, bool alwaysWinInProlongation, bool alwaysLooseInProlongation)
        {
            this.name = name;
            random = new Random(Program.NameToInt(name));
            this.minimumByTeams = minimumByTeams;
            this.maximumByTeams = maximumByTeams;
            this.fixedByTeams = fixedByTeams;
            this.modifier = modifier;
            this.alwaysWinInProlongation = alwaysWinInProlongation;
            this.alwaysLooseInProlongation = alwaysLooseInProlongation;
        }

        protected abstract int CalculateScore(AbstractTeam adversary);

        public int CalculateFinalScore(AbstractTeam adversary)
        {
            int score = CalculateScore(adversary);
            int result = score;

            IScoreModifier scoreModifier = this as IScoreModifier;
            if (scoreModifier != null)
            {
                result = scoreModifier.ModifyScore(result);
            }

            IMinimumScoreAgainst minimumScoreAgainst = this as IMinimumScoreAgainst;
            if (minimumScoreAgainst != null)
            {
                result = minimumScoreAgainst.ModifyScore(adversary, result);
            }

            IMaximumScoreAgainst maximumScoreAgainst = this as IMaximumScoreAgainst;
            if (maximumScoreAgainst != null)
            {
                result = maximumScoreAgainst.ModifyScore(adversary, result);
            }

            IFixedScoreAgainst fixedScoreAgainst = this as IFixedScoreAgainst;
            if (fixedScoreAgainst != null)
            {
                result = fixedScoreAgainst.ModifyScore(adversary, result);
            }


            return result;
        }
    }
}
