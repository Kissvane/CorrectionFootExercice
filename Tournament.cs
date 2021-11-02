using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceFootCorrection
{
    class Tournament
    {
        private List<AbstractTeam> competitingTeams;
        private List<AbstractTeam> disqualifiedTeams = new List<AbstractTeam>();
        private AbstractTeam[] podium = new AbstractTeam[3];

        public Tournament(List<AbstractTeam> teams)
        {
            this.competitingTeams = new List<AbstractTeam>(teams);
        }

        public void RandomizeTeams()
        {
            Random random = new Random((int) DateTime.Now.Ticks);
            competitingTeams = (List<AbstractTeam>) ShuffleList(random, competitingTeams);
            Console.WriteLine("Tirage au sort");
            Program.printList(competitingTeams);
        }

        public void StartTournament()
        {
            RandomizeTeams();
            //PLAY MATCHS
            while (competitingTeams.Count > 0)
            {
                PlayThisRound();
            }

            //SHOW PODIUM
            ShowPodium();
        }

        void PlayThisRound()
        {
            //remove all previous disqualified teams from this round competiting teams
            foreach(AbstractTeam team in disqualifiedTeams)
            {
                competitingTeams.Remove(team);
            }

            //final round
            if (competitingTeams.Count == 2)
            {
                Console.WriteLine("-------------------Third place match--------------------");
                //third place match
                Match thirdPlaceMatch = new Match(disqualifiedTeams[0], disqualifiedTeams[1]);
                MatchResult thirdPlaceResult = thirdPlaceMatch.playMatch();
                podium[2] = thirdPlaceResult.winner;
                disqualifiedTeams.Clear();

                Console.WriteLine("-------------------Final match--------------------");
                //final
                Match finalMatch = new Match(competitingTeams[0], competitingTeams[1]);
                MatchResult finalResult = finalMatch.playMatch();
                podium[0] = finalResult.winner;
                podium[1] = finalResult.looser;
                competitingTeams.Clear();
            }
            else
            {
                Console.WriteLine("---------------------------------------");
                disqualifiedTeams.Clear();
                for (int i = 0; i < competitingTeams.Count; i = i + 2)
                {
                    Match current = new Match(competitingTeams[i], competitingTeams[i + 1]);
                    MatchResult result = current.playMatch();
                    disqualifiedTeams.Add(result.looser);
                }
            }
        }

        public void ShowPodium()
        {
            Console.WriteLine("\n-------------------PODIUM--------------------\n");
            Console.WriteLine("{0} est 1er", podium[0].name);
            Console.WriteLine("{0} est 2nd", podium[1].name);
            Console.WriteLine("{0} est 3eme", podium[2].name);
        }

        IList<T> ShuffleList<T>(Random r, IEnumerable<T> source)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                var i = r.Next(list.Count + 1);
                if (i == list.Count)
                {
                    list.Add(item);
                }
                else
                {
                    var temp = list[i];
                    list[i] = item;
                    list.Add(temp);
                }
            }
            return list;
        }

    }

    
}
