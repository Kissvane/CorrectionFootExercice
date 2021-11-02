using System;
using System.Collections.Generic;

namespace ExerciceFootCorrection
{
    class Program
    {
        static void Main(string[] args)
        {
            //register participants
            List<AbstractTeam> participants = new List<AbstractTeam>();
            Dictionary<string, int> constraint = new Dictionary<string, int> 
            {
                {"Real",3}
            };
            participants.Add(new RandomScoreTeam("Barca", constraint));

            constraint = new Dictionary<string, int>
            {
                {"Barca",0}
            };
            participants.Add(new RandomScoreTeam("Real",constraint));
            participants.Add(new RandomScoreTeam("NewTeam", minimumScore:1));
            participants.Add(new RandomScoreTeam("PSG", maximumScore:4));

            participants.Add(new RandomScoreTeam("Toho", alwaysWinInProlongation:true,maximumScore:1));
            participants.Add(new RandomScoreTeam("Newpie", maximumScore:0));
            participants.Add(new RandomScoreTeam("Muppet",minimumScore:2, maximumScore:4));
            participants.Add(new RandomScoreTeam("Marseille", minimumScore:2,maximumScore:2));

            constraint = new Dictionary<string, int>
            {
                {"PSG",2}
            };
            participants.Add(new RandomScoreTeam("Toulouse", fixedByTeams:constraint, alwaysWinInProlongation:true));
            participants.Add(new RandomScoreTeam("Caen", modifier:-1));
            participants.Add(new RandomScoreTeam("Lille", modifier:-3, alwaysWinInProlongation:true));
            constraint = new Dictionary<string, int>
            {
                {"Lyon",0}
            };
            participants.Add(new RandomScoreTeam("Bordeaux", minimumScore:1, maximumScore:3, fixedByTeams:constraint));
            
            participants.Add(new NameScoreTeam("Lyon", alwaysLooseInProlongation:true));
            participants.Add(new NameScoreTeam("Avignon", modifier:1));
            constraint = new Dictionary<string, int>
            {
                {"Avignon",0}
            };
            participants.Add(new NameScoreTeam("Montpellier", maximumByTeams:constraint));
            constraint = new Dictionary<string, int>
            {
                {"PSG",2}
            };

            Dictionary<string, int> constraint2 = new Dictionary<string, int>
            {
                {"Toulouse",3}
            };
            participants.Add(new NameScoreTeam("Evian", fixedByTeams:constraint, maximumByTeams:constraint2));

            //start the tournament
            Tournament tournament = new Tournament(participants);
            tournament.StartTournament();
        }

        public static int NameToInt(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result += (int)s[i] * (i + 1) + (int)DateTime.Now.Ticks;
            }
            return result;
        }

        public static void printList(List<AbstractTeam> list)
        {
            string result = "";
            foreach (AbstractTeam team in list)
            {
                result = string.Concat(result, team.name, "-");
            }
            result = result.Substring(0, result.Length - 1);
            Console.WriteLine(result);
        }
    }
}
