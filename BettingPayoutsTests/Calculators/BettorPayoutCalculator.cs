using BettingPayoutsTests.Base;
using BettingPayoutsTests.Constants;
using BettingPayoutsTests.Helpers;

namespace BettingPayoutsTests.Calculators
{
    public class BettorPayoutCalculator
    {
        private BetSuccessChecker? betChecker;

        public double CalculateBettorPayout(double payout, Match match, Bet bet)
        {
            betChecker = new BetSuccessChecker();
            double bettorPayout;
            double totalPayout = payout * bet.BetAmount;

            if (BetSuccessChecker.IsBetSuccessfull(match, bet))
            {
                bettorPayout = totalPayout - (totalPayout * CommisionRates.BASIC_COMMISSION_RATE);
            }
            else
            {
                bettorPayout = 0;
            }

            return Math.Round(bettorPayout, 2);
        }
    }
}
