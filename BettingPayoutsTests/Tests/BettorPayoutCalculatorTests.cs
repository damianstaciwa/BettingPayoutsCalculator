using BettingPayoutsTests.Base;
using BettingPayoutsTests.Calculators;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace BettingPayoutsTests.Tests
{
    [TestFixture]
    public class BettorPayoutCalculatorTests
    {
        private BettorPayoutCalculator bettorPayoutCalculator;
        private PayoutCalculator payoutCalculator;

        [SetUp]
        public void Setup()
        {
            bettorPayoutCalculator = new BettorPayoutCalculator();
            payoutCalculator = new PayoutCalculator();
        }

        [Test]
        public void TestBettorCalculatePayout_HomeTeamWins_BettorWins()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 2,
                AwayTeamScore = 1
            };

            var bet = new Bet
            {
                BetType = BetType.HomeTeamWins,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(178.2);
        }

        [Test]
        public void TestBettorCalculatePayout_HomeTeamWins_BettorLoses()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 2,
                AwayTeamScore = 1
            };

            var bet = new Bet
            {
                BetType = BetType.AwayTeamWins,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(0);
        }

        [Test]
        public void TestBettorCalculatePayout_HomeTeamLoses_BettorWins()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 2,
                AwayTeamScore = 3
            };

            var bet = new Bet
            {
                BetType = BetType.AwayTeamWins,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(239.58);
        }

        [Test]
        public void TestBettorCalculatePayout_HomeTeamLoses_BettorLoses()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 2,
                AwayTeamScore = 3
            };

            var bet = new Bet
            {
                BetType = BetType.HomeTeamWins,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(0);
        }

        [Test]
        public void TestBettorCalculatePayout_Draw_BettorWins()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 3,
                AwayTeamScore = 3
            };

            var bet = new Bet
            {
                BetType = BetType.Draw,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(80.19);
        }

        [Test]
        public void TestBettorCalculatePayout_Draw_BettorLoses_HomeTeamWins()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 3,
                AwayTeamScore = 3
            };

            var bet = new Bet
            {
                BetType = BetType.HomeTeamWins,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(0);
        }

        [Test]
        public void TestBettorCalculatePayout_Draw_BettorLoses_AwayTeamWins()
        {
            // arrange
            var match = new Match
            {
                HomeTeamBetsAmount = 27000,
                AwayTeamBetsAmount = 30000,
                DrawBetsAmount = 10000,

                HomeTeamOdds = 5.4,

                HomeTeamScore = 3,
                AwayTeamScore = 3
            };

            var bet = new Bet
            {
                BetType = BetType.AwayTeamWins,
                BetAmount = 100
            };

            // act & assert
            using (new AssertionScope())
            {
                match.HomeTeam.Should().BeEquivalentTo(bet.HomeTeam);
                match.AwayTeam.Should().BeEquivalentTo(bet.AwayTeam);
            }

            var payout = payoutCalculator.CalculatePayout(match, match.HomeTeamScore, match.AwayTeamScore, match.HomeTeamOdds);

            var bettorPayout = bettorPayoutCalculator.CalculateBettorPayout(payout, match, bet);

            bettorPayout.Should().Be(0);
        }
    }
}
