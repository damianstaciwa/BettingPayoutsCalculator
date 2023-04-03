using BettingPayoutsTests.Base;

namespace BettingPayoutsTests.Helpers
{
    public class BetSuccessChecker
    {
        public bool IsBetSuccessfull(Match match, Bet bet)
        {
            if (match.HomeTeamScore > match.AwayTeamScore && bet.BetType.Equals(BetType.HomeTeamWins))
                return true;

            else if (match.HomeTeamScore > match.AwayTeamScore && (bet.BetType.Equals(BetType.AwayTeamWins) || bet.BetType.Equals(BetType.Draw)))
                return false;

            else if (match.HomeTeamScore == match.AwayTeamScore && bet.BetType.Equals(BetType.Draw))
                return true;

            else if (match.HomeTeamScore == match.AwayTeamScore && (bet.BetType.Equals(BetType.AwayTeamWins) || bet.BetType.Equals(BetType.AwayTeamWins)))
                return false;

            else if (match.HomeTeamScore < match.AwayTeamScore && bet.BetType.Equals(BetType.AwayTeamWins))
                return true;

            else if (match.HomeTeamScore < match.AwayTeamScore && (bet.BetType.Equals(BetType.HomeTeamWins) || bet.BetType.Equals(BetType.Draw)))
                return false;

            return false;
        }
    }
}