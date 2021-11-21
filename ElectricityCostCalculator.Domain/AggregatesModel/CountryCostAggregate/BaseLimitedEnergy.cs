namespace ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate
{
    public abstract class BaseLimitedEnergy
    {
        protected BaseLimitedEnergy(decimal amount, decimal limit)
        {
            if (amount > limit)
            {
                Amount = limit;
            }
            else
            {
                Amount = amount;
            }
            Limit = limit;
        }

        public decimal Amount { get; }

        public decimal Limit { get; }
    }
}
