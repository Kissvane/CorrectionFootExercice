using System;
using System.Collections.Generic;

namespace ExerciceFootCorrection
{
    class Program
    {
        static void Main(string[] args)
        {
            //register participants
            List<Team> participants = new List<Team>();
            participants.Add(new Team("Barca"));
            participants.Add(new Team("Real"));
            participants.Add(new Team("NewTeam"));
            participants.Add(new Team("PSG"));
            participants.Add(new Team("Toho"));
            participants.Add(new Team("Newpie"));
            participants.Add(new Team("Muppet"));
            participants.Add(new Team("Marseille"));

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

        public static void printList(List<Team> list)
        {
            string result = "";
            foreach (Team team in list)
            {
                result = string.Concat(result, team.name, "-");
            }
            result = result.Substring(0, result.Length - 1);
            Console.WriteLine(result);
        }
    }
}
