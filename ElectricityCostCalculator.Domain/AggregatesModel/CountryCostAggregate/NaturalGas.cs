namespace ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate
{
    public class NaturalGas : IEnergy
    {
        public NaturalGas(decimal amount, decimal materialPrice)
        {
            Amount = amount;
            MaterialPrice = materialPrice;
        }

        public decimal Amount { get; }
        public decimal MaterialPrice { get; }

        public decimal GetTotalCost()
        {
            return Amount * MaterialPrice * 1.2m;
        }
    }
}