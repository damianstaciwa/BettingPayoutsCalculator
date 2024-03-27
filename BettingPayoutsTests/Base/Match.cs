namespace BettingPayoutsTests.Base
{
    public class Match
    {
        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeTeamBetsAmount { get; set; }

        public int AwayTeamBetsAmount { get; set; }

        public int DrawBetsAmount { get; set; }

        public double HomeTeamOdds { get; set; }

        public double AwayTeamOdds { get; set; }

        public double DrawOdds { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public Match()
        {
            HomeTeam = "Team A";
            AwayTeam = "Team B";
            HomeTeamOdds = 0.1;
            AwayTeamOdds = 0.1;
            DrawOdds = 0.1;
            HomeTeamBetsAmount = 0;
            AwayTeamBetsAmount = 0;
            DrawBetsAmount = 0;
            HomeTeamScore = 0;
            AwayTeamScore = 0;
        }

        public Match(string homeTeam, string awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }
    }
}
