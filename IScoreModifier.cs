using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    interface IScoreModifier
    {
        int modifier { get; set; }

        public int ModifyScore(int score)
        {
            return Math.Max(0,score + modifier);
        }
    }
}
