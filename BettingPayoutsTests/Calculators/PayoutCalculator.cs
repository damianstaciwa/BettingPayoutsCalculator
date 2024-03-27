using BettingPayoutsTests.Base;

namespace BettingPayoutsTests.Calculators
{
    public class PayoutCalculator
    {
        private static double CalculatePayoutForHomeTeamWin(Match match, double homeTeamOdds)
        {
            var totalBetsAmount = match.HomeTeamBetsAmount + match.HomeTeamBetsAmount + match.HomeTeamBetsAmount;

            if (totalBetsAmount == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(match.HomeTeamBetsAmount * homeTeamOdds / totalBetsAmount, 2);
            }
        }

        private static double CalculatePayoutForAwayTeamWin(Match match, double awayTeamOdds)
        {
            var totalBetsAmount = match.HomeTeamBetsAmount + match.AwayTeamBetsAmount + match.DrawBetsAmount;

            if (totalBetsAmount == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(match.AwayTeamBetsAmount * awayTeamOdds / totalBetsAmount, 2);
            }
        }

        private static double CalculatePayoutForDraw(Match match, double drawOdds)
        {
            var totalBetsAmount = match.HomeTeamBetsAmount + match.AwayTeamBetsAmount + match.DrawBetsAmount;

            if (totalBetsAmount == 0)
            {
                return 0;
            }
            else
            {
                return Math.Round(match.DrawBetsAmount * drawOdds / totalBetsAmount, 2);
            }
        }

        public double CalculatePayout(Match match, int homeTeamScore, int awayTeamScore, double optionOdds = 5.0)
        {
            if (homeTeamScore > awayTeamScore)
            {
                return CalculatePayoutForHomeTeamWin(match, optionOdds);
            }
            else if (homeTeamScore < awayTeamScore)
            {
                return CalculatePayoutForAwayTeamWin(match, optionOdds);
            }
            else
            {
                return CalculatePayoutForDraw(match, optionOdds);
            }
        }
    }
}
