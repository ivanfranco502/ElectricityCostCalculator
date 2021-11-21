namespace ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate
{
    public class Wind: BaseLimitedEnergy, IEnergy
    {
        public Wind(decimal amount) : base(amount, 100000)
        {
        }

        public decimal GetTotalCost()
        {
            if (Amount > (Limit * 0.4m))
            {
                // Wind is good
                return Amount * 61.1m;
            }

            // It's not enough to compensate investment.
            return Amount * 75.3m;
        }
    }
}
