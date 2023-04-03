using BettingPayoutsTests.Base;
using BettingPayoutsTests.Calculators;
using FluentAssertions;
using NUnit.Framework;

namespace BettingPayoutsTests.Tests
{
    [TestFixture]
    public class PayoutCalculatorTests
    {
        private PayoutCalculator payoutCalculator;

        [SetUp]
        public void Setup()
        {
            payoutCalculator = new PayoutCalculator();
        }

        [Test]
        public void TestCalculatePayout_HomeTeamWins()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 2,
                AwayTeamScore = 1
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            payout.Should().Be(1.8);
        }

        [Test]
        public void TestCalculatePayout_AwayTeamWins()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 12500,
                AwayTeamBetsAmount = 14900,
                DrawBetsAmount = 7700,

                AwayTeamOdds = 1.7,

                HomeTeamScore = 0,
                AwayTeamScore = 1
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.AwayTeamOdds);

            payout.Should().Be(0.72);
        }

        [Test]
        public void TestCalculatePayout_Draw()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 34500,
                AwayTeamBetsAmount = 24900,
                DrawBetsAmount = 97700,

                DrawOdds = 6.7,

                HomeTeamScore = 3,
                AwayTeamScore = 3
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.DrawOdds);

            payout.Should().Be(4.17);
        }

        [Test]
        public void TestCalculatePayout_NoBets()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 0,
                AwayTeamBetsAmount = 0,
                DrawBetsAmount = 0,

                HomeTeamScore = 1,
                AwayTeamScore = 4
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore);

            payout.Should().Be(0);
        }

        [Test]
        public void TestCalculatePayout_EqualBetsForHomeAndAwayTeam()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 35000,
                AwayTeamBetsAmount = 35000,
                DrawBetsAmount = 6450,

                HomeTeamScore = 2,
                AwayTeamScore = 0
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore);

            payout.Should().Be(1.67);
        }

        [Test]
        public void TestCalculatePayout_EqualBetsForAllOutcomes()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 10000,
                AwayTeamBetsAmount = 10000,
                DrawBetsAmount = 10000,

                HomeTeamScore = 5,
                AwayTeamScore = 3
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore);

            payout.Should().Be(1.67);
        }

        [Test]
        public void TestCalculatePayout_AwayTeamWins_NoBetsOnDraw()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 100000,
                AwayTeamBetsAmount = 347000,
                DrawBetsAmount = 0,

                AwayTeamOdds = 1.9,

                HomeTeamScore = 2,
                AwayTeamScore = 3
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore);

            payout.Should().Be(3.88);
        }

        [Test]
        public void TestCalculatePayout_Draw_NoBetsOnAwayTeam()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 46000,
                AwayTeamBetsAmount = 0,
                DrawBetsAmount = 32450,

                DrawOdds = 4.4,

                HomeTeamScore = 0,
                AwayTeamScore = 0
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore);

            payout.Should().Be(2.07);
        }

        [Test]
        public void TestCalculatePayout_Draw_NoBetsOnHomeTeam()
        {
            var match = new Match
            {
                HomeTeamBetsAmount = 0,
                AwayTeamBetsAmount = 78600,
                DrawBetsAmount = 32450,

                DrawOdds = 6.7,

                HomeTeamScore = 0,
                AwayTeamScore = 0
            };

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore);

            payout.Should().Be(1.46);
        }
    }
}