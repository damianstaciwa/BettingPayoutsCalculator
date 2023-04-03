namespace BettingPayoutsTests.Helpers
{
    public class OddsGenerator
    {
        public static double GenerateRandomDouble()
        {
            var random = new Random();
            double value = random.NextDouble() * 9.8 + 0.1;

            return value;
        }
    }
}