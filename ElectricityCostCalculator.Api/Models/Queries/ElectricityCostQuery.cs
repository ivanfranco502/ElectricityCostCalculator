namespace ElectricityCostCalculator.Api.Models.Queries
{
    public class ElectricityCostQuery
    {
        public long TotalElectricity { get; set; }
        public decimal WindSupply { get; set; }
        public decimal NaturalGasCost { get; set; }
    }
}
