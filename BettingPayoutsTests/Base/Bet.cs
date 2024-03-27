namespace BettingPayoutsTests.Base
{
    public class Bet
    {
        public string BettorName { get; set; }
        public BetType BetType { get; set; }
        public double BetAmount { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public Bet()
        {
            BettorName = "Test Bettor";
            HomeTeam = "Team A";
            AwayTeam = "Team B";
        }
    }
}
