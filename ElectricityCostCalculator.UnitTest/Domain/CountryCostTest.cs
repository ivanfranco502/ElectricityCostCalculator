using ElectricityCostCalculator.Domain.AggregatesModel.CountryCostAggregate;
using Xunit;

namespace ElectricityCostCalculator.UnitTest.Domain
{
    public class CountryCostTest
    {
        [Fact]
        public void GetForecast_GivenAnAmountSmallerThanWindAvailability_ShouldSupplyOnlyWindWithRemainedAmount()
        {
            var countryCost = new CountryCost(10000, 50000, 0);

            var response = countryCost.GetForecastCost();

            Assert.Equal(75.3m, response);
        }
        
        [Fact]
        public void GetForecast_GivenAnAmountBiggerThanWindAvailability_ShouldSupplyWindAndNuclear()
        {
            var countryCost = new CountryCost(100000, 80000, 0);

            var response = countryCost.GetForecastCost();

            Assert.Equal(60.1m, response);
        }

        [Fact]
        public void GetForecast_GivenAnAmountBiggerThanWindAvailabilityAndNuclearCapacity_ShouldSupplyAllEnergyTypes()
        {
            var countryCost = new CountryCost(135000, 70000, 67.2m);

            var response = countryCost.GetForecastCost();

            Assert.Equal(65.05m, response);
        }
    }
}
