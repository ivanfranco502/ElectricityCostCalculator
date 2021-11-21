namespace ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate
{
    public class Nuclear: BaseLimitedEnergy, IEnergy
    {
        public Nuclear(decimal amount): base(amount, 30000)
        {
        }

        public decimal GetTotalCost()
        {
            return Amount * 56.1m;
        }
    }
}
