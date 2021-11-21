namespace ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate
{
    public interface IEnergy
    {
        decimal GetTotalCost();
    }
}