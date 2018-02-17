using System;
using System.Text;
using YouthGenerator.Engine;

namespace YouthGeneratorConsole
{
    class OutputScreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Great Team Youth Generation");
            GenerateAndShowPlayers(5, 5, 5);
            Console.ReadKey();
            Console.WriteLine("Mediocre Team Youth Generation");
            GenerateAndShowPlayers(3, 3, 4);
            Console.ReadKey();
            Console.WriteLine("Bad Team Youth Generation");
            GenerateAndShowPlayers(1, 1, 5);
            Console.ReadKey();
        }

        private static void GenerateAndShowPlayers(int countryRating, int competitionRating, int teamRating)
        {
            var youthTeam = YouthTeamGeneratorEngine.GenerateYouthTeam(countryRating, competitionRating, teamRating);
            foreach (var player in youthTeam)
            {
                Console.WriteLine($"{player.LastName}, {player.FirstName} ({player.PersonNationality.ShortName}) :");
                StringBuilder sb1 = new StringBuilder();
                foreach (var position in player.Positions)
                    sb1.Append($"{position},");
                Console.WriteLine(sb1.ToString());
                StringBuilder sb2 = new StringBuilder();
                var counter = 0;
                foreach (var attr in player.PlayerAttributes)
                {
                    sb2.Append($"{attr.Key}: {attr.Value} - ");
                    counter++;
                    if (counter >= 15)
                    {
                        Console.WriteLine(sb2.ToString());
                        sb2.Clear();
                        counter = 0;
                    }
                }
            }
        }
    }
}
