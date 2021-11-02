using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    class NameScoreTeam : AbstractTeam
    {
        public NameScoreTeam(string name, Dictionary<string, int> fixedByTeams = null, Dictionary<string, int> minimumByTeams = null, Dictionary<string, int> maximumByTeams = null, int modifier = 0, bool alwaysWinInProlongation = false, bool alwaysLooseInProlongation = false) : base(name, fixedByTeams, minimumByTeams, maximumByTeams, modifier, alwaysWinInProlongation, alwaysLooseInProlongation)
        {
        }

        protected override int CalculateScore(AbstractTeam adversary)
        {
            int result = 0;
            for (int i = 0; i < adversary.name.Length; i++)
            {
                char current = (char)adversary.name[i];
                int index = current < 97 ? current - 64 : current - 96;
                if (i%2 == 0)
                    result += index;
                else
                    result -= index;
            }

            result = Math.Clamp(result, 0, 10);
            return result;
        }
    }
}
