using Assignment_IPL.Models;
using Assignment_IPL.Services;
namespace Assignment_IPL
{

    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            var data = LoadData.GetCSVData(@"C:\\Users\\Dell\\source\\repos\\dotnet_examples\\Assignment_IPL\\IPL_2021_data.csv");
            foreach (var d in data)
            {
                //Console.WriteLine($"{d.name}, {d.team}");
            }
            //Console.WriteLine("printing Teams");
            var teams = TeamServices.GetTeams(data);
            foreach (KeyValuePair<string, Team> t in teams)
            {
                //Console.WriteLine(t.Key + " Team --------------------------------------------");
                var players = t.Value.GetAllPlayers();
                //Console.WriteLine("printing players");
                foreach (var p in players)
                {
                    //Console.WriteLine(p.name);
                }
            }

            Query q = new Query(teams,data);

            Console.WriteLine(new String('=', 40)+" The Fixtures are as follows: " +new String('=',40));
            q.CreateFixtures();
            
            Console.WriteLine(new String('=', 40)+" getting bowlers with min 40 wickets from CSK team"+ new String('=', 40));
            var bowlers=q.GetBowlers("CSK");
            foreach(var bowler in bowlers)
            {
                Console.WriteLine(bowler);
            }

            Console.WriteLine(new String('=', 40)+" Serach player profile vi"+ new String('=', 40));
            var players_list = q.SerachPlayer("Vi");
            foreach(var p in players_list)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(new String('=', 40) + " getting GetHighest Wicket Taker And Scorer from CSK team" + new String('=', 40));
            players_list = q.GetHighestWicketTakerAndScorer("CSK");
            Console.WriteLine("Highest wicket taker");
            Console.WriteLine(players_list[0]);
            Console.WriteLine("Highest Run SCorer");
            Console.WriteLine(players_list[1]);

            Console.WriteLine("\n"+new String('=', 40) + " getting Top 3 bowlers & Batsmans & Allrounders of the season " + new String('=', 40));
            Console.WriteLine(new String('*', 40)+" Top 3 batsman "+ new String('*', 40));
            players_list = q.GetTop3Batsman();
            foreach(Player p in players_list)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(new String('*', 40) + " Top 3 bowlers " + new String('*', 40));
            players_list = q.GetTop3Bowlers();
            foreach (Player p in players_list)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(new String('*', 40) + " Top 3 allrounders " + new String('*', 40));
            players_list = q.GetTop3Allrounder();
            foreach (Player p in players_list)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(new String('=', 40) + @" if each team plays their 11 best batsmen in a match the two teams would score the highest and their predicted score. are as following "+ new String('=', 40) );
            q.Show11BestBatsmanMatchStatistics();

            Console.WriteLine(new String('=', 40) + "\nFinding the Next Generation of players from each team " + new String('=', 40) );
            q.FindNextGen();
        }
    }
}