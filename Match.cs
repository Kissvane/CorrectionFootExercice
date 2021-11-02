using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    class Match
    {
        public Team team1;
        public Team team2;

        public Match(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        public MatchResult playMatch()
        {
            int score1 = team1.CalculateScore();
            int score2 = team2.CalculateScore();
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
            Random random = new Random(Program.NameToInt(team1.name+team2.name));
            int tossCoin = random.Next(0,2);
            if (tossCoin == 0)
            {
                return new MatchResult(team1, team2, score+1, score, true);
            }
            else
            {
                return new MatchResult(team2, team1, score+1, score, true);
            }
        }
    }

    class MatchResult
    {
        public Team winner;
        public Team looser;
        public int scoreWinner;
        public int scoreLooser;
        public bool prolongation;

        public MatchResult(Team winner, Team looser, int scoreWinner, int scoreLooser, bool prolongation)
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
