using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    class Match
    {
        public AbstractTeam team1;
        public AbstractTeam team2;

        public Match(AbstractTeam team1, AbstractTeam team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        public MatchResult playMatch()
        {
            int score1 = team1.CalculateFinalScore(team2);
            int score2 = team2.CalculateFinalScore(team1);
            if (score1 > score2) 
            {
                //team1 win
                return new MatchResult(team1, team2, score1, score2, false);
            }
            else if (score2 > score1)
            {
                //team2 win
                return new MatchResult(team2, team1, score2, score1, false);
            }
            else
            {
                return playProlongation(score1);
            }
        }

        public MatchResult playProlongation(int score)
        {
            if (team1.alwaysWinInProlongation && !team2.alwaysWinInProlongation)
            {
                return new MatchResult(team1, team2, score + 1, score, true);
            }
            else if (team2.alwaysWinInProlongation && !team1.alwaysWinInProlongation)
            {
                return new MatchResult(team2, team1, score + 1, score, true);
            }
            else if (team1.alwaysLooseInProlongation && !team2.alwaysLooseInProlongation)
            {
                return new MatchResult(team2, team1, score + 1, score, true);
            }
            else if (!team1.alwaysLooseInProlongation && team2.alwaysLooseInProlongation)
            {
                return new MatchResult(team1, team2, score + 1, score, true);
            }
            else
            {
                Random random = new Random(Program.NameToInt(team1.name + team2.name));
                int tossCoin = random.Next(0, 2);
                if (tossCoin == 0)
                {
                    return new MatchResult(team1, team2, score + 1, score, true);
                }
                else
                {
                    return new MatchResult(team2, team1, score + 1, score, true);
                }
            }
        }
    }

    class MatchResult
    {
        public AbstractTeam winner;
        public AbstractTeam looser;
        public int scoreWinner;
        public int scoreLooser;
        public bool prolongation;

        public MatchResult(AbstractTeam winner, AbstractTeam looser, int scoreWinner, int scoreLooser, bool prolongation)
        {
            this.winner = winner;
            this.looser = looser;
            this.scoreWinner = scoreWinner;
            this.scoreLooser = scoreLooser;
            this.prolongation = prolongation;

            if (!prolongation)
            {
                Console.WriteLine("{0} a gagné le match contre {1} avec un score de {2} à {3}",winner.name, looser.name, scoreWinner, scoreLooser);
            }
            else
            {
                Console.WriteLine("{0} a gagné le match contre {1} en prolongation avec un score de {2} à {3}", winner.name, looser.name, scoreWinner, scoreLooser);
            }
        }
    }

}
